using DGVPrinterHelper;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RestaurantPOS
{
    public partial class Reports : Form
    {
        int saledate = 0;
        int purchasedate = 0;
        public Reports()
        {
            InitializeComponent();
        }




        private void btnPurchaseReports_Click(object sender, EventArgs e)
        {
                tabControl1.SelectedIndex = 0;
        }

        private void Reports_Load(object sender, EventArgs e)
        {
            lblLoggedUser.Text = "Admin";

            tabControl1.SelectedIndex = 1;
            MainClass.FillSupplier(cboSupplierLedger);
            MainClass.HideAllTabsOnTabControl(tabControl1);
            ShowPurchases(DGVPurchases, PurchaseIDGV, InvoiceNoGv, InvoiceDateGV, RemarksGV, GrandTotalGV);
            ShowSales(DGVSales, SaleIDGV, SaleInvoiceNoGV, OrderDateGV, OrderTimeGV, CashierGV, SaleGrandTotalGV);
        }

        private void ShowPurchases(DataGridView dgv, DataGridViewColumn PurchaseID, DataGridViewColumn InvoiceNo, DataGridViewColumn InvoiceDate, DataGridViewColumn Remarks, DataGridViewColumn GrandTotal )
        {
            MainClass.con.Open();
            SqlCommand cmd = null;
            if(purchasedate == 1)
            {
                cmd = new SqlCommand("select PurchaseID,InvoiceNo,GrandTotal,format(PurchaseDate, 'dd/MM/yyyy') as 'Date',Remarks from PurchasesTable where PurchaseDate between '" + dtPurchase1.Value.ToShortDateString() + "' and '" + dtPurchase2.Value.ToShortDateString() + "'", MainClass.con);
            }
            else
            {
                if (txtSearchPurhcaseInvoice.Text == "")
                {
                    cmd = new SqlCommand("select PurchaseID,InvoiceNo,GrandTotal,format(PurchaseDate, 'dd/MM/yyyy') as 'Date',Remarks from PurchasesTable", MainClass.con);
                }
                else
                {
                    cmd = new SqlCommand("select PurchaseID,InvoiceNo,GrandTotal,format(PurchaseDate, 'dd/MM/yyyy') as 'Date',Remarks from PurchasesTable where InvoiceNo  like '%" + txtSearchPurhcaseInvoice.Text + "%' ", MainClass.con);

                }
            }   
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            PurchaseID.DataPropertyName = dt.Columns["PurchaseID"].ToString();
            InvoiceNo.DataPropertyName = dt.Columns["InvoiceNo"].ToString();
            InvoiceDate.DataPropertyName = dt.Columns["Date"].ToString();
            Remarks.DataPropertyName = dt.Columns["Remarks"].ToString();
            GrandTotal.DataPropertyName = dt.Columns["GrandTotal"].ToString();
            dgv.DataSource = dt;
            MainClass.con.Close();
        }





        




        private void CalculateProvidedTotal()
        {
            float total = 0;
            foreach (DataGridViewRow item in DGVSales.Rows)
            {
                total += float.Parse(item.Cells["SaleGrandTotalGV"].Value.ToString());
            }
            txtTotalSales.Text = total.ToString();
        }


        private void btnSaleReports_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 1;

        }

        private void btnLedgerReports_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 2;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 3;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 4;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            HomeScreen hs = new HomeScreen();
            hs.lblLoggedUser.Text = "Admin";
            MainClass.showWindow(hs, this, MDI.ActiveForm);
        }

        private void txtSearchPurhcaseInvoice_TextChanged(object sender, EventArgs e)
        {
            ShowPurchases(DGVPurchases, PurchaseIDGV, InvoiceNoGv, InvoiceDateGV, RemarksGV, GrandTotalGV);
        }



        private void ShowSales(DataGridView dgv, DataGridViewColumn SaleID, DataGridViewColumn InvoiceNo, DataGridViewColumn InvoiceDate, DataGridViewColumn OrderTime, DataGridViewColumn Cashier, DataGridViewColumn GrandTotal)
        {
            MainClass.con.Open();
            SqlCommand cmd = null;
            if (saledate == 1)
            {
                cmd = new SqlCommand("select SaleID,InvoiceNo,format(SaleDate, 'dd/MM/yyyy') as 'Date',SaleTime,GrandTotal,Cashier from SalesTable where SaleDate between '" + dtSale1.Value.ToShortDateString() + "' and '" + dtSale2.Value.ToShortDateString() + "' ", MainClass.con);
            }
            else
            {
                if (txtSearchSaleInvoice.Text == "")
                {
                    cmd = new SqlCommand("select SaleID,InvoiceNo,format(SaleDate, 'dd/MM/yyyy') as 'Date',SaleTime,GrandTotal,Cashier from SalesTable ", MainClass.con);

                }
                else
                {
                    cmd = new SqlCommand("select SaleID,InvoiceNo,format(SaleDate, 'dd/MM/yyyy') as 'Date',SaleTime,GrandTotal,Cashier from SalesTable where InvoiceNo  like '%" + txtSearchSaleInvoice.Text + "%'", MainClass.con);

                }
            }
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            SaleID.DataPropertyName = dt.Columns["SaleID"].ToString();
            OrderTime.DataPropertyName = dt.Columns["SaleTime"].ToString();
            InvoiceNo.DataPropertyName = dt.Columns["InvoiceNo"].ToString();
            InvoiceDate.DataPropertyName = dt.Columns["Date"].ToString();
            Cashier.DataPropertyName = dt.Columns["Cashier"].ToString();
            GrandTotal.DataPropertyName = dt.Columns["GrandTotal"].ToString();
            dgv.DataSource = dt;
            MainClass.con.Close();
        }




        private void button11_Click(object sender, EventArgs e)
        {
            ShowPurchases(DGVPurchases, PurchaseIDGV, InvoiceNoGv, InvoiceDateGV, RemarksGV, GrandTotalGV);
        }

        private void PurchaseDate(object sender, EventArgs e)
        {
            if (dtPurchase1.Value == DateTime.Now && dtPurchase2.Value == DateTime.Now)
            {
                purchasedate = 0;

            }
            else
            {
                purchasedate = 1;

            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            purchasedate = 0;
            dtPurchase1.Value = DateTime.Now;
            dtPurchase2.Value = DateTime.Now;
            ShowPurchases(DGVPurchases, PurchaseIDGV, InvoiceNoGv, InvoiceDateGV, RemarksGV, GrandTotalGV);

        }

        private void SaleDate(object sender, EventArgs e)
        {
            if (dtSale2.Value == DateTime.Now && dtSale1.Value == DateTime.Now)
            {
                saledate = 0;

            }
            else
            {
                saledate = 1;
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            ShowSales(DGVSales, SaleIDGV, SaleInvoiceNoGV, OrderDateGV, OrderTimeGV, CashierGV, SaleGrandTotalGV);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            saledate = 0;
            dtSale1.Value = DateTime.Now;
            dtSale2.Value = DateTime.Now;
            ShowSales(DGVSales, SaleIDGV, SaleInvoiceNoGV, OrderDateGV, OrderTimeGV, CashierGV, SaleGrandTotalGV);
        }

        private void txtSearchSaleInvoice_TextChanged(object sender, EventArgs e)
        {
            ShowSales(DGVSales, SaleIDGV, SaleInvoiceNoGV, OrderDateGV, OrderTimeGV,CashierGV, SaleGrandTotalGV);

        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = null;
            string customerInvoiceID;
            string customerLedgerID;
            if (DGVSales.SelectedRows.Count == 1)
            {
                try
                {
                    MainClass.con.Open();

                    
                        cmd = new SqlCommand("delete from SalesInfo where Sales_ID = '" + DGVSales.CurrentRow.Cells["SaleIDGV"].Value.ToString() + "'", MainClass.con);
                        cmd.ExecuteNonQuery();

                        cmd = new SqlCommand("delete from SalesTable where SaleID = '" + DGVSales.CurrentRow.Cells["SaleIDGV"].Value.ToString() + "'", MainClass.con);
                        cmd.ExecuteNonQuery();
                    

                    



                    MainClass.con.Close();

                    MessageBox.Show("Sale Deleted Successfully");
                    ShowSales(DGVSales, SaleIDGV, SaleInvoiceNoGV, OrderDateGV, OrderTimeGV, CashierGV, SaleGrandTotalGV);

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    MainClass.con.Close();
                }
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void CboCustomerLedger_SelectedIndexChanged(object sender, EventArgs e)
        {
            //ShowLedgersInfo(DGVLedgersReports, CustomerGV, PayingDateGV, LedgerInvoiceNoGV, LedgerTotalGv, PreviousPaidGV, TodaysPaidGV, NewBalanceGV, cboSupplierLedger.SelectedValue.ToString());
        }

        private void btnExportPdF_Click(object sender, EventArgs e)
        {
            DGVPrinter printer = new DGVPrinter();
            printer.Title = "TFC - LEDGER REPORTS";
            if(cboSupplierLedger.SelectedIndex == 0)
            {
                printer.SubTitle = "Customer : ALL CUSTOMERS";
            }
            else
            {
                printer.SubTitle = "Customer : " + cboSupplierLedger.Text;
            }
            
            printer.SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
            printer.PageNumbers = true;
            printer.PorportionalColumns = true;
            printer.PageNumberInHeader = false;
            printer.HeaderCellAlignment = StringAlignment.Center;
            printer.Footer = "Developed by Cyber Soft Services  Contact: +92 300 9259266";
            printer.FooterSpacing = 15;
            printer.PrintDataGridView(DGVLedgersReports);

            
            MessageBox.Show("PDF SAVED SUCCESSFULLY");
        }

        public static int ReportsSaleID = 0;
        public static int ReportOrderTypeID = 0;
        private void DGVSales_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex != -1 || e.ColumnIndex != -1)
            {
                if(e.ColumnIndex == 0)
                {
                    if(DGVSales.CurrentRow.Cells["OrderTypeGV"].Value.ToString() == "Dine In")
                    {
                        ReportOrderTypeID = 1;
                        ReportsSaleID = int.Parse(DGVSales.CurrentRow.Cells["SaleIDGV"].Value.ToString());
                        BillForm bf = new BillForm();
                        bf.Show();

                    }
                    else if (DGVSales.CurrentRow.Cells["OrderTypeGV"].Value.ToString() == "Take Away")
                    {
                        ReportOrderTypeID = 2;
                        ReportsSaleID = int.Parse(DGVSales.CurrentRow.Cells["SaleIDGV"].Value.ToString());
                        BillForm bf = new BillForm();
                        bf.Show();
                    }
                    else if(DGVSales.CurrentRow.Cells["OrderTypeGV"].Value.ToString() == "Credit")
                    {
                        ReportOrderTypeID = 3;
                        ReportsSaleID = int.Parse(DGVSales.CurrentRow.Cells["SaleIDGV"].Value.ToString());
                        BillForm bf = new BillForm();
                        bf.Show();
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
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
            for (int i = 1; i < DGVPurchases.Columns.Count + 1; i++)
            {
                worksheet.Cells[1, i] = DGVPurchases.Columns[i - 1].HeaderText;
            }
            // storing Each row and column value to excel sheet  
            for (int i = 0; i < DGVPurchases.Rows.Count; i++)
            {
                for (int j = 0; j < DGVPurchases.Columns.Count; j++)
                {
                    worksheet.Cells[i + 2, j + 1] = DGVPurchases.Rows[i].Cells[j].Value.ToString();
                }
            }
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
            for (int i = 1; i < DGVSales.Columns.Count + 1; i++)
            {
                worksheet.Cells[1, i] = DGVSales.Columns[i - 1].HeaderText;
            }
            // storing Each row and column value to excel sheet  
            for (int i = 0; i < DGVSales.Rows.Count; i++)
            {
                for (int j = 0; j < DGVSales.Columns.Count; j++)
                {
                    worksheet.Cells[i + 2, j + 1] = DGVSales.Rows[i].Cells[j].Value.ToString();
                }
            }
        }

        private void button5_Click_1(object sender, EventArgs e)
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
            for (int i = 1; i < DGVLedgersReports.Columns.Count + 1; i++)
            {
                worksheet.Cells[1, i] = DGVLedgersReports.Columns[i - 1].HeaderText;
            }
            // storing Each row and column value to excel sheet  
            for (int i = 0; i < DGVLedgersReports.Rows.Count; i++)
            {
                for (int j = 0; j < DGVLedgersReports.Columns.Count; j++)
                {
                    worksheet.Cells[i + 2, j + 1] = DGVLedgersReports.Rows[i].Cells[j].Value.ToString();
                }
            }
        }

      

        private void button4_Click_1(object sender, EventArgs e)
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
            for (int i = 1; i < DGVReturnDetails.Columns.Count + 1; i++)
            {
                worksheet.Cells[1, i] = DGVReturnDetails.Columns[i - 1].HeaderText;
            }
            // storing Each row and column value to excel sheet  
            for (int i = 0; i < DGVReturnDetails.Rows.Count; i++)
            {
                for (int j = 0; j < DGVReturnDetails.Columns.Count; j++)
                {
                    worksheet.Cells[i + 2, j + 1] = DGVReturnDetails.Rows[i].Cells[j].Value.ToString();
                }
            }
        }

        private void btnIncomeReports_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 4;

        }

        private void button7_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = null;
            try
            {
                MainClass.con.Open();
                cmd = new SqlCommand("select sum(GrandTotal) from SalesTable where SaleDate between '" + dateTimePicker2.Value.ToShortDateString() + "' and '" + dateTimePicker1.Value.ToShortDateString() + "'", MainClass.con);
                object salegrandtotal = cmd.ExecuteScalar();
                if (salegrandtotal != null)
                {
                    if (salegrandtotal.ToString() != "")
                    {
                        txtSalesAll.Text = salegrandtotal.ToString();
                    }
                    else
                    {
                        txtSalesAll.Text = "0";
                    }
                }


                cmd = new SqlCommand("select sum(GrandTotal) from PurchasesTable where PurchaseDate between '" + dateTimePicker2.Value.ToShortDateString() + "' and '" + dateTimePicker1.Value.ToShortDateString() + "'", MainClass.con);
                object purchasetotal = cmd.ExecuteScalar();
                if (purchasetotal != null)
                {
                    if (purchasetotal.ToString() != "")
                    {
                        txtPurchasesAll.Text = purchasetotal.ToString();
                    }
                    else
                    {
                        txtPurchasesAll.Text = "0";
                    }
                }

                cmd = new SqlCommand("select sum(ExpensePrice) from ExpensesTable where ExpenseDate between '" + dateTimePicker2.Value.ToShortDateString() + "' and '" + dateTimePicker1.Value.ToShortDateString() + "'", MainClass.con);
                object expenseall = cmd.ExecuteScalar();
                if (expenseall != null)
                {
                    if (expenseall.ToString() != "")
                    {
                        txtExpensesAll.Text = expenseall.ToString();
                    }
                    else
                    {
                        txtExpensesAll.Text = "0";
                    }
                }

                float income = float.Parse(txtPurchasesAll.Text) + float.Parse(txtExpensesAll.Text);
                income = float.Parse(txtSalesAll.Text) - income;
               
                txtIncomeAll.Text = income.ToString();

                

                MainClass.con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                MainClass.con.Close();
            }
        }
    }
}
