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
namespace RestaurantPOS
{
    public partial class Inventory : Form
    {
        private void ShowStocks(DataGridView dgv, DataGridViewColumn Product,DataGridViewColumn Unit, DataGridViewColumn Qty, DataGridViewColumn Rate, string data = null)
        {
            try
            {
                SqlCommand cmd = null;
                if (data != null)
                {
                    cmd = new SqlCommand("select p.ProductName,u.Unit,i.Qty,i.Rate from Inventory i inner join ProductsTable p on p.ProductID = i.ProductID inner join UnitsTable u on u.UnitID = i.Unit where p.ProductName like '%" + data + "%'", MainClass.con);
                }
                else
                {
                    cmd = new SqlCommand("select p.ProductName,u.Unit,i.Qty,i.Rate from Inventory i inner join ProductsTable p on p.ProductID = i.ProductID inner join UnitsTable u on u.UnitID = i.Unit", MainClass.con);
                }
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                Product.DataPropertyName = dt.Columns["ProductName"].ToString();
                Unit.DataPropertyName = dt.Columns["Unit"].ToString();
                Qty.DataPropertyName = dt.Columns["Qty"].ToString();
                Rate.DataPropertyName = dt.Columns["Rate"].ToString();
                dgv.DataSource = dt;
                MainClass.con.Close();
            }
            catch (Exception ex)
            {
                MainClass.con.Close();
                MessageBox.Show(ex.Message);
            }
        }
        public Inventory()
        {
            InitializeComponent();
        }

        private void Inventory_Load(object sender, EventArgs e)
        {
            ShowStocks(DGVInventory, ProductGV ,UnitGV, QuantityGV, RateGV);
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            ShowStocks(DGVInventory, ProductGV,UnitGV, QuantityGV, RateGV, txtSearch.Text.ToString());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            HomeScreen hs = new HomeScreen();
            hs.lblLoggedUser.Text = "Admin";
            MainClass.showWindow(hs, this, MDI.ActiveForm);
        }

        private void DGVInventory_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            DGVInventory.ClearSelection();
        }

      
    }
}
