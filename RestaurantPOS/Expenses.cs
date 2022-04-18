using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using iTextSharp.text;
using System.IO;
using iTextSharp.text.pdf;
using DGVPrinterHelper;

namespace RestaurantPOS
{
    public partial class Expenses : Form
    {
        int edit = 0;
        int date = 0;
        public Expenses()
        {
            InitializeComponent();
        }

        private void ShowExpense(DataGridView dgv, DataGridViewColumn expid, DataGridViewColumn Expense, DataGridViewColumn expenseprice, DataGridViewColumn dates, string search = "")
        {
            SqlCommand cmd;
            try
            {
                string sdate = DateTime.Now.ToShortDateString();
                MainClass.con.Open();
                if (date == 1)
                {
                    cmd = new SqlCommand("select * from ExpensesTable  where ExpenseDate between '" + dt1.Value.ToShortDateString() + "' and '" + dt2.Value.ToShortDateString() + "' ", MainClass.con);
                }
                else if (search != null)
                {
                    cmd = new SqlCommand("select * from ExpensesTable  where ExpenseName like '%"+search+"%'  ", MainClass.con);
                }
                else
                {
                    cmd = new SqlCommand("select * from ExpensesTable order by ExpenseName", MainClass.con);
                }
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                expid.DataPropertyName = dt.Columns["ExpenseID"].ToString();
                Expense.DataPropertyName = dt.Columns["ExpenseName"].ToString();
                expenseprice.DataPropertyName = dt.Columns["ExpensePrice"].ToString();
                dates.DataPropertyName = dt.Columns["ExpenseDate"].ToString();
                dgv.DataSource = dt;
                MainClass.con.Close();
            }
            catch (Exception ex)
            {
                MainClass.con.Close();
                MessageBox.Show(ex.Message);
            }
            ShowTotal();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            edit = 1;
            lblID.Text = DGVExpenses.CurrentRow.Cells[0].Value.ToString();
            txtExpenseName.Text = DGVExpenses.CurrentRow.Cells[1].Value.ToString();
            txtPrice.Text = DGVExpenses.CurrentRow.Cells[2].Value.ToString();
            dt1.Value = Convert.ToDateTime(DGVExpenses.CurrentRow.Cells[3].Value);
        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            if (edit == 0)
            {
                if (txtExpenseName.Text != "")
                {
                    try
                    {
                        MainClass.con.Open();
                        SqlCommand cmd = new SqlCommand("insert into ExpensesTable (ExpenseName,ExpensePrice,ExpenseDate) values (@ExpenseName,@ExpensePrice,@ExpenseDate)", MainClass.con);
                        cmd.Parameters.AddWithValue("@ExpenseName", txtExpenseName.Text);
                        cmd.Parameters.AddWithValue("@ExpensePrice", txtPrice.Text);
                        cmd.Parameters.AddWithValue("@ExpenseDate", dt1.Value.ToShortDateString());
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Expense Add Successfully");
                        
                        MainClass.con.Close();
                        ShowExpense(DGVExpenses, ExpenseID, ExpenseNameGV, ExpensePriceGV, DateGV);
                        ShowTotal();
                    }
                    catch (Exception ex)
                    {
                        MainClass.con.Close();
                        MessageBox.Show(ex.Message);
                    }
                    try
                    {
                        float handcash = MainClass.CashInHand();
                        float cash = handcash - float.Parse(txtPrice.Text);

                        MainClass.con.Open();
                        SqlCommand cmd = new SqlCommand("update StoreTable set CashInHand = @CashInHand", MainClass.con);
                        cmd.Parameters.AddWithValue("@CashInHand", cash);
                        cmd.ExecuteNonQuery();
                        MainClass.con.Close();
                    }
                    catch (Exception ex)
                    {
                        MainClass.con.Close();
                        MessageBox.Show(ex.Message);
                    } //UpdateCash Flow
                    txtExpenseName.Text = "";
                    txtPrice.Text = "";
                }
            }
            else
            {
                if (edit == 1)
                {
                    if (txtExpenseName.Text == "" || txtPrice.Text == "")
                    {
                        MessageBox.Show("Field Required");
                    }
                    else
                    {
                        try
                        {
                            SqlCommand cmd = null;
                            float lastexpenseminusfromcashflow = 0;
                            MainClass.con.Open();
                            cmd = new SqlCommand("select ExpensePrice from ExpensesTable where ExpenseID = '" + lblID.Text + "'", MainClass.con);
                            lastexpenseminusfromcashflow = float.Parse(cmd.ExecuteScalar().ToString());
                            MainClass.con.Close();

                            try
                            {
                                float handcash = MainClass.CashInHand();
                                float cash = handcash + lastexpenseminusfromcashflow; 
                                cash -= float.Parse(txtPrice.Text);

                                MainClass.con.Open();
                                cmd = new SqlCommand("update StoreTable set CashInHand = @CashInHand", MainClass.con);
                                cmd.Parameters.AddWithValue("@CashInHand", cash);
                                cmd.ExecuteNonQuery();
                                MainClass.con.Close();
                            }
                            catch (Exception ex)
                            {
                                MainClass.con.Close();
                                MessageBox.Show(ex.Message);
                            } //UpdateCash Flow



                            MainClass.con.Open();
                            cmd = new SqlCommand("update ExpensesTable set ExpenseName = @ExpenseName,ExpensePrice = @ExpensePrice, ExpenseDate= @ExpenseDate where ExpenseID = @ExpenseID", MainClass.con);
                            cmd.Parameters.AddWithValue("@ExpenseName", txtExpenseName.Text);
                            cmd.Parameters.AddWithValue("@ExpensePrice", txtPrice.Text);
                            cmd.Parameters.AddWithValue("@ExpenseDate", dt1.Value.ToShortDateString());
                            cmd.Parameters.AddWithValue("@ExpenseID", lblID.Text);
                            cmd.ExecuteNonQuery();
                            MainClass.con.Close();
                            MessageBox.Show("Expense Updated Successfully.");
                            txtExpenseName.Text = "";
                            txtPrice.Text = "";

                            ShowExpense(DGVExpenses, ExpenseID, ExpenseNameGV, ExpensePriceGV, DateGV);
                            ShowTotal();
                            edit = 0;
                        }
                        catch (Exception ex)
                        {
                            MainClass.con.Close();
                            MessageBox.Show(ex.Message);
                        }
                    }
                }
            }
        }

        private void Expenses_Load(object sender, EventArgs e)
        {
            lblLoggedUser.Text = "Admin";
            ShowExpense(DGVExpenses, ExpenseID, ExpenseNameGV, ExpensePriceGV, DateGV);
          //  ShowTotal();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            HomeScreen hs = new HomeScreen();
            hs.lblLoggedUser.Text = "Admin";
            MainClass.showWindow(hs, this, MDI.ActiveForm);
        }

        private void ShowTotal()
        {
            if (DGVExpenses.Rows.Count > 0)
            {
                int total = 0;
                for (int i = 0; i < DGVExpenses.Rows.Count; i++)
                {
                    total += Convert.ToInt32(DGVExpenses.Rows[i].Cells[2].Value);
                }
                txtTotal.Text = total.ToString();
            }
            else
            {
                txtTotal.Text = "0";
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lblID.Text = DGVExpenses.CurrentRow.Cells[0].Value.ToString();
            if (DGVExpenses != null)
            {
                if (DGVExpenses.Rows.Count > 0)
                {
                    if (DGVExpenses.SelectedRows.Count == 1)
                    {
                        try
                        {
                            MainClass.con.Open();
                            SqlCommand cmd = new SqlCommand("delete from ExpensesTable where ExpenseID = @ExpenseID", MainClass.con);
                            cmd.Parameters.AddWithValue("@ExpenseID", lblID.Text);
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Expense Deleted Successfully");
                            MainClass.con.Close();
                            ShowExpense(DGVExpenses, ExpenseID, ExpenseNameGV, ExpensePriceGV, DateGV);
                        }
                        catch (Exception ex)
                        {
                            MainClass.con.Close();
                            MessageBox.Show(ex.Message);
                        }
                    }
                }
            }
            ShowTotal();
        }

        private void dt1_ValueChanged(object sender, EventArgs e)
        {
            date = 1;
            ShowExpense(DGVExpenses, ExpenseID, ExpenseNameGV, ExpensePriceGV, DateGV);
            ShowTotal();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            ShowExpense(DGVExpenses, ExpenseID, ExpenseNameGV, ExpensePriceGV, DateGV, txtSearch.Text.ToString());
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if(txtExpenseName.Text != "" || txtPrice.Text != "")
            {
                txtExpenseName.Text = "";
                txtPrice.Text = "";
            }
            else
            {
                HomeScreen hs = new HomeScreen();
                hs.lblLoggedUser.Text = "Admin";
                MainClass.showWindow(hs, this, MDI.ActiveForm);

            }
        }

        private void dt1_ValueChanged_1(object sender, EventArgs e)
        {
            date = 1;
            ShowExpense(DGVExpenses, ExpenseID, ExpenseNameGV, ExpensePriceGV, DateGV);
            ShowTotal();
        }

        private void Expenses_FormClosed(object sender, FormClosedEventArgs e)
        {
           
        }


        private void button2_Click(object sender, EventArgs e)
        {
            Microsoft.Office.Interop.Excel._Application app = new Microsoft.Office.Interop.Excel.Application();
            // creating new WorkBook within Excel application  
            Microsoft.Office.Interop.Excel._Workbook workbook = app.Workbooks.Add(Type.Missing);
            // creating new Excelsheet in workbook  
            Microsoft.Office.Interop.Excel._Worksheet worksheet = null;
            // see the excel sheet behind the program  
            app.Visible = true;
            // get the reference of first sheet. By default its name is Sheet1.  
            // store its reference to worksheet  
            worksheet = workbook.Sheets["Sheet1"];
            worksheet = workbook.ActiveSheet;
            // changing the name of active sheet  
            worksheet.Name = "Exported from gridview";
            // storing header part in Excel  
            for (int i = 1; i < DGVExpenses.Columns.Count + 1; i++)
            {
                worksheet.Cells[1, i] = DGVExpenses.Columns[i - 1].HeaderText;
            }
            // storing Each row and column value to excel sheet  
            for (int i = 0; i < DGVExpenses.Rows.Count; i++)
            {
                for (int j = 0; j < DGVExpenses.Columns.Count; j++)
                {
                    worksheet.Cells[i + 2, j + 1] = DGVExpenses.Rows[i].Cells[j].Value.ToString();
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DGVPrinter printer = new DGVPrinter();
            printer.Title = "EXPENSES REPORTS";
            

            printer.SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
            printer.PageNumbers = true;
            printer.PorportionalColumns = true;
            printer.PageNumberInHeader = false;
            printer.HeaderCellAlignment = StringAlignment.Center;
            printer.Footer = "Developed by Cyber Soft Services  Contact: +92 300 9259266";
            printer.FooterSpacing = 15;
            printer.PrintDataGridView(DGVExpenses);


            MessageBox.Show("PDF SAVED SUCCESSFULLY");
        }
    }
}
