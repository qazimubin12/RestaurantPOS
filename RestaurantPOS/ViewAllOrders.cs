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
    public partial class ViewAllOrders : Form
    {
        RestaurantPOS rsp;
        public ViewAllOrders()
        {
            InitializeComponent();
        }

        public ViewAllOrders(RestaurantPOS rp)
        {
            InitializeComponent();
            this.rsp = rp;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ViewAllOrders_Load(object sender, EventArgs e)
        {
            ShowAllOrders(DGVOrders, SaleIDGV, InvoiceNoGV, OrderDateGV, OrderTimeGV, AmountGV, TableDataGV);
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

        private void DGVOrders_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(DGVOrders.SelectedRows.Count == 1)
            {
                if(e.ColumnIndex == 0)
                {
                    MainClass.con.Open();
                    SqlCommand cmd = new SqlCommand("select BillGst from SalesTable where SaleID = '" + DGVOrders.CurrentRow.Cells["SaleIDGV"].Value.ToString() + "'",MainClass.con);
                    float ob = float.Parse(cmd.ExecuteScalar().ToString());
                    MainClass.con.Close();

                    if(ob == 0)
                    {
                        rsp.cbGST.Checked = false;
                    }
                    else
                    {
                        rsp.cbGST.Checked = true;
                    }

                    rsp.lblOrderID.Text = DGVOrders.CurrentRow.Cells["SaleIDGV"].Value.ToString();
                    rsp.txtTableName.Text = DGVOrders.CurrentRow.Cells["TableDataGV"].Value.ToString();
                    rsp.lblGrandTotal.Text = DGVOrders.CurrentRow.Cells["AmountGV"].Value.ToString();
                    rsp.txtInvoiceNo.Text = DGVOrders.CurrentRow.Cells["InvoiceNoGV"].Value.ToString();
                    rsp.dateTimePicker1.Value = Convert.ToDateTime(DGVOrders.CurrentRow.Cells["OrderDateGV"].Value);
                    rsp.btnSaveOrder.Text = "UPDATE";
                    rsp.btnSaveandPrintOrder.Enabled = false;
                    this.Close();
                }
            }
        }
    }
}
