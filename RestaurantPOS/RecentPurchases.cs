using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RestaurantPOS
{
    public partial class RecentPurchases : Form
    {
        PurchaseInvoice pr;
        public RecentPurchases()
        {
            InitializeComponent();
        }
        public RecentPurchases(PurchaseInvoice p)
        {
            InitializeComponent();
            this.pr = p;
        }


        private void RecentPurchases_Load(object sender, EventArgs e)
        { 
            MainClass.ShowRecentPurchases(DGVRecentPurchases, PurchaseIDGV, InvoiceNoGV, PurchaseDateGV, GrandTotalGV);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DGVRecentPurchases_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            CultureInfo provider = CultureInfo.InvariantCulture;
            SqlCommand cmd = null;
            SqlDataReader dr;

            if (DGVRecentPurchases.Rows.Count != 0)
            {
                if (DGVRecentPurchases.SelectedRows.Count == 1)
                {
                    if (e.RowIndex != -1 && e.ColumnIndex != -1)
                    {

                        if (e.ColumnIndex == 0)
                        {
                            pr.lblInvoiceNo.Text = DGVRecentPurchases.CurrentRow.Cells["InvoiceNoGV"].Value.ToString();
                            pr.lblPurchaseID.Text = DGVRecentPurchases.CurrentRow.Cells["PurchaseIDGV"].Value.ToString();
                            MainClass.con.Open();
                            MainClass.con.Close();

                            pr.dtInvoiceDate.Value = Convert.ToDateTime(DGVRecentPurchases.CurrentRow.Cells["PurchaseDateGV"].Value);
                            try
                            {
                                MainClass.con.Open();
                                
                                cmd = new SqlCommand("selecT si.Product_ID,p.ProductName,si.SalePrice,si.Quantity,si.Discount,si.TotalOfProduct from PurchasesTable st inner join PurchasesInfo si on si.Purchase_ID = st.PurchaseID inner join ProductsTable p on p.ProductID = si.Product_ID  where st.InvoiceNo = '" + DGVRecentPurchases.CurrentRow.Cells["InvoiceNoGV"].Value.ToString() + "'", MainClass.con);
                                dr = cmd.ExecuteReader();
                                while (dr.Read())
                                {
                                    pr.DGVPurchaseCart.Rows.Add(dr["Product_ID"].ToString(), dr["ProductName"].ToString(), float.Parse(dr["SalePrice"].ToString()), dr["Quantity"].ToString(), float.Parse(dr["Discount"].ToString()), float.Parse(dr["TotalOfProduct"].ToString()));
                                }
                                MainClass.con.Close();


                            }
                            catch (Exception ex)
                            {
                                MainClass.con.Close();
                                MessageBox.Show(ex.Message);
                            } //Product getting

                            pr.btnFinalize.Text = "UPDATE";
                            this.Close();




                        }
                    }
                }

            }
        }
    }
}
