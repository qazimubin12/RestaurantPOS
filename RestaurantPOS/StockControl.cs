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
    public partial class StockControl : Form
    {
        private void ShowStocks(DataGridView dgv, DataGridViewColumn ProductID, DataGridViewColumn Product, DataGridViewColumn Unit, DataGridViewColumn Qty, string data = null)
        {
            try
            {
                SqlCommand cmd = null;
                if (data != null)
                {
                    cmd = new SqlCommand("select p.ProductID,p.ProductName,u.Unit,i.Qty from Inventory i inner join ProductsTable p on p.ProductID = i.ProductID inner join UnitsTable u on u.UnitID = i.Unit where p.ProductName like '%" + data + "%'", MainClass.con);
                }
                else
                {
                    cmd = new SqlCommand("select p.ProductID,p.ProductName,u.Unit,i.Qty from Inventory i inner join ProductsTable p on p.ProductID = i.ProductID inner join UnitsTable u on u.UnitID = i.Unit", MainClass.con);
                }
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                ProductID.DataPropertyName = dt.Columns["ProductID"].ToString();
                Product.DataPropertyName = dt.Columns["ProductName"].ToString();
                Unit.DataPropertyName = dt.Columns["Unit"].ToString();
                Qty.DataPropertyName = dt.Columns["Qty"].ToString();
                dgv.DataSource = dt;
                MainClass.con.Close();
            }
            catch (Exception ex)
            {
                MainClass.con.Close();
                MessageBox.Show(ex.Message);
            }
        }
        public StockControl()
        {
            InitializeComponent();
        }

        private void StockControl_Load(object sender, EventArgs e)
        {
            ShowStocks(DgvCategory, ID, Product, Unit, Quantity, txtSearch.Text);
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            ShowStocks(DgvCategory, ID, Product, Unit, Quantity, txtSearch.Text);
        }

        private void DgvCategory_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(DgvCategory.SelectedRows.Count == 1)
            {
                if(e.ColumnIndex == 0)
                {
                    lblID.Text = DgvCategory.CurrentRow.Cells["ID"].Value.ToString();
                    txtProduct.Text = DgvCategory.CurrentRow.Cells["Product"].Value.ToString();
                    txtUnit.Text = DgvCategory.CurrentRow.Cells["Unit"].Value.ToString();
                    lblstockqty.Text = DgvCategory.CurrentRow.Cells["Quantity"].Value.ToString();
                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(txtReason.Text != "" && txtProduct.Text != "" && comboBox1.Text != "")
            {
                SqlCommand cmd = null;
                try
                {
                    MainClass.con.Open();
                    cmd = new SqlCommand("insert into StockControl(ProductID,Quantity,Reason,StockStatus) values(@ProductID,@Quantity,@Reason,@StockStatus) ", MainClass.con);
                    cmd.Parameters.AddWithValue("@ProductID", lblID.Text);
                    cmd.Parameters.AddWithValue("@Quantity", txtQuantity.Text);
                    cmd.Parameters.AddWithValue("@Reason", txtReason.Text);
                    cmd.Parameters.AddWithValue("@StockStatus", comboBox1.Text);
                    cmd.ExecuteNonQuery();
                    float stockqty = float.Parse(lblstockqty.Text);
                    float finalqty = 0;
                    if (comboBox1.Text == "Stock Out")
                    {
                        finalqty = stockqty - float.Parse(txtQuantity.Text);
                    }
                    else
                    {
                         finalqty = stockqty + float.Parse(txtQuantity.Text);
                    }
                    MainClass.UpdateInventory(int.Parse(lblID.Text), finalqty);
                    MessageBox.Show("Stock Updated Successfully");
                    MainClass.con.Close();
                    ShowStocks(DgvCategory, ID, Product, Unit, Quantity, txtSearch.Text);
                }
                catch (Exception ex)
                {
                    MainClass.con.Close();
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Please Select and Fill Details");
                return;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            HomeScreen hs = new HomeScreen();
            MainClass.showWindow(hs, this, MDI.ActiveForm);
        }
    }
}
