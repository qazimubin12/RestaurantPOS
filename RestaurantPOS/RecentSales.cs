using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RestaurantPOS
{
    public partial class RecentSales : Form
    {
        POS pr;
        public RecentSales()
        {
            InitializeComponent();
        }

        public RecentSales(POS p)
        {
            InitializeComponent();
            this.pr = p;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ViewAllOrders_Load(object sender, EventArgs e)
        {
            ShowRestaurantSales(DGVSales, SaleIDGV, SaleInvoiceNoGV, OrderDateGV, OrderTimeGV, SaleGrandTotalGV);
        }
        private void ShowRestaurantSales(DataGridView dgv, DataGridViewColumn SaleID, DataGridViewColumn InvoiceNo, DataGridViewColumn SaleDate, DataGridViewColumn SaleTime, DataGridViewColumn GrandTotal, string search = null)
        {
            MainClass.con.Open();
            SqlCommand cmd = null;
            cmd = new SqlCommand("select SaleID,InvoiceNo,format(SaleDate, 'dd/MM/yyyy') as 'Date', SaleTime,round(GrandTotal,0) as 'GrandTotal'  from SalesTable", MainClass.con);
            
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            SaleID.DataPropertyName = dt.Columns["SaleID"].ToString();
            InvoiceNo.DataPropertyName = dt.Columns["InvoiceNo"].ToString();
            SaleDate.DataPropertyName = dt.Columns["Date"].ToString();
            SaleTime.DataPropertyName = dt.Columns["SaleTime"].ToString();
            GrandTotal.DataPropertyName = dt.Columns["GrandTotal"].ToString();
            dgv.DataSource = dt;
            MainClass.con.Close();

        }

        private void ShowAllOrders(DataGridView dgv, DataGridViewColumn SaleID,DataGridViewColumn InvoiceNo,DataGridViewColumn SaleDate, DataGridViewColumn SaleTime, DataGridViewColumn GrandTotal, DataGridViewColumn Table)
        {
            try
            {
                SqlCommand cmd = null;
                MainClass.con.Open();

                cmd = new SqlCommand("select SaleID,InvoiceNo,SaleDate,SaleTime,Round(GrandTotal,0) as 'GrandTotal',TableData from SalesTable where OrderStatus = 'Pending'", MainClass.con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                SaleID.DataPropertyName = dt.Columns["SaleID"].ToString();
                InvoiceNo.DataPropertyName = dt.Columns["InvoiceNo"].ToString();
                SaleDate.DataPropertyName = dt.Columns["SaleDate"].ToString();
                SaleTime.DataPropertyName = dt.Columns["SaleTime"].ToString();
                GrandTotal.DataPropertyName = dt.Columns["GrandTotal"].ToString();
                Table.DataPropertyName = dt.Columns["TableData"].ToString();
                dgv.DataSource = dt;
                MainClass.con.Close();
            }
            catch (Exception ex)
            {
                MainClass.con.Close();
                MessageBox.Show(ex.Message);
            }
        }


        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = null;
            string customerInvoiceID;
            string customerLedgerID;
            float grandtotaltobeupdatedincashflow = 0;
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
                    ShowRestaurantSales(DGVSales, SaleIDGV, SaleInvoiceNoGV, OrderDateGV, OrderTimeGV, SaleGrandTotalGV);

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    MainClass.con.Close();
                }
            }
        }

        public static int RecentReportsSaleID = 0;
        public static int SALEID = 0;
       
        private void DGVSales_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1 || e.ColumnIndex != -1)
            {
                if (e.ColumnIndex == 0)
                {
                   
                        RecentReportsSaleID = int.Parse(DGVSales.CurrentRow.Cells["SaleIDGV"].Value.ToString());
                        BillForm bf = new BillForm();
                        bf.Show();
                    
                }
            }

        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SALEID = int.Parse(DGVSales.CurrentRow.Cells["SaleIDGV"].Value.ToString());
            pr.lblID.Text = SALEID.ToString();
            this.Close();
        }
    }
}
