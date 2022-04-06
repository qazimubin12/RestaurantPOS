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
    public partial class Products : Form
    {
        int show = 0;
        int pedit = 0;
        public Products()
        {
            InitializeComponent();
        }
        private void ShowProductSID(DataGridView dgv2, DataGridViewColumn ID, DataGridViewColumn Name, DataGridViewColumn Cat, DataGridViewColumn Cost,
            DataGridViewColumn Sale, DataGridViewColumn Remarks, DataGridViewColumn Unit,string data = null)
        {
            try
            {
                SqlCommand cmd = null;
                MainClass.con.Open();

                if (data != "")
                {
                    cmd = new SqlCommand("select p.ProductID,p.ProductName,c.Category,u.Unit,p.CostPrice,p.SalePrice,p.Remarks from ProductsTable p inner join CategoriesTable c on c.CategoryID = p.CatID  join UnitsTable u on u.UnitID = p.UnitID  where p.ProductName like '%" + data + "%'", MainClass.con);
                }
                else
                {
                    cmd = new SqlCommand("select p.ProductID,p.ProductName,c.Category,u.Unit,p.CostPrice,p.SalePrice,p.Remarks from ProductsTable p inner join CategoriesTable c on c.CategoryID = p.CatID  join UnitsTable u on u.UnitID = p.UnitID  order by p.ProductName", MainClass.con);
                }
           
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                ID.DataPropertyName = dt.Columns["ProductID"].ToString();
                Name.DataPropertyName = dt.Columns["ProductName"].ToString();
                Cat.DataPropertyName = dt.Columns["Category"].ToString();
                Cost.DataPropertyName = dt.Columns["CostPrice"].ToString();
                Sale.DataPropertyName = dt.Columns["SalePrice"].ToString();
                Remarks.DataPropertyName = dt.Columns["Remarks"].ToString();
                Unit.DataPropertyName = dt.Columns["Unit"].ToString();
                dgv2.DataSource = dt;
                MainClass.con.Close();
            }
            catch (Exception ex)
            {
                MainClass.con.Close();
                MessageBox.Show(ex.Message);
            }
        }

        byte[] ConvertImageToBytes(Image img)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                img.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                return ms.ToArray();
            }
        }

        public Image ConvertByteArraytoImage(byte[] data)
        {
            using (MemoryStream ms = new MemoryStream(data))
            {
                return Image.FromStream(ms);
            }
        }

        private void Products_Load(object sender, EventArgs e)
        {
            lblLoggedUser.Text = "Admin";
            MainClass.FillCategories(cboCategory);
            MainClass.FillUnits(cboUnits);
            ShowProductSID(DGVSomeProducts, ProSID, NameSID, CategorySID, CostSID, SaleSID, RemarksSID, UnitSID);
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
          
                ShowProductSID(DGVSomeProducts, ProSID, NameSID, CategorySID, CostSID, SaleSID, RemarksSID, UnitSID,txtSearch.Text.ToString());
        }


        private void button3_Click(object sender, EventArgs e)
        {
            HomeScreen hs = new HomeScreen();
            hs.lblLoggedUser.Text = "Admin";
            MainClass.showWindow(hs, this, MDI.ActiveForm);
        }

        private void Clear()
        {
            txtProductName.Text = "";
            txtCostPrice.Text = "";
            txtSalePrice.Text = "";
            txtRemarks.Text = "";
            cboUnits.SelectedIndex = 0;
            pedit = 0;
            cboCategory.SelectedIndex = 0;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = null;
            SqlDataReader dr;

            string catId = "";
            string unitid = "";

            MainClass.con.Open();

            //CatUnit
            cmd = new SqlCommand("select CategoryID from CategoriesTable where Category like '" + cboCategory.Text + "'", MainClass.con);
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    catId = dr[0].ToString();
                }
            }
            dr.Close();

            
            //Unit
            cmd = new SqlCommand("select UnitID from UnitsTable where Unit like '" + cboUnits.Text + "'", MainClass.con);
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    unitid = dr[0].ToString();
                }
            }
            dr.Close();
            
          
            
            MainClass.con.Close();

            if (pedit == 0)
            {
                if (txtProductName.Text == "" || txtSalePrice.Text == "" ||
                    cboCategory.SelectedIndex == 0 || cboUnits.SelectedIndex == 0)
                {
                    MessageBox.Show("Please Input Details");
                }
                else
                {
                    try
                    {
                        MainClass.con.Open();
                        cmd = new SqlCommand("insert into ProductsTable (ProductName,CatID,UnitID,CostPrice,SalePrice,Remarks,StockControl,Image) values(@ProductName,@CatID,@UnitID,@CostPrice,@SalePrice,@Remarks,@StockControl,@Image)", MainClass.con);
                       
                        
                        if(txtCostPrice.Text == "")
                        {
                            cmd.Parameters.AddWithValue("@CostPrice", txtSalePrice.Text);
                        }

                        else 
                        {
                            cmd.Parameters.AddWithValue("@CostPrice", txtCostPrice.Text);
                        }
                        cmd.Parameters.AddWithValue("@ProductName", txtProductName.Text);
                        cmd.Parameters.AddWithValue("@CatID", catId);
                        cmd.Parameters.AddWithValue("@UnitID", unitid);
                        cmd.Parameters.AddWithValue("@SalePrice", txtSalePrice.Text);
                        cmd.Parameters.AddWithValue("@Remarks", txtRemarks.Text);
                        cmd.Parameters.AddWithValue("@StockControl", cbStockControl.Checked);
                        cmd.Parameters.AddWithValue("Image", ConvertImageToBytes(pictureBox1.Image));
                        cmd.ExecuteNonQuery();
                        MainClass.con.Close();
                        MessageBox.Show("Product Inserted Successfully.");
                        Clear();
                        ShowProductSID(DGVSomeProducts, ProSID, NameSID, CategorySID, CostSID, SaleSID, RemarksSID, UnitSID);
                    }
                    catch (Exception ex)
                    {
                        MainClass.con.Close();
                        MessageBox.Show(ex.Message);
                    }

                }
            }
            else
            {
                if (pedit == 1)
                {                    
                    try
                    {
                        MainClass.con.Open();
                        cmd = new SqlCommand("UPDATE ProductsTable SET ProductName =@ProductName,Image=@Image,CatID =@CatID,UnitID =@UnitID,CostPrice =@CostPrice,SalePrice =@SalePrice, Remarks =@Remarks,StockControl =@StockControl where ProductID = @ProductID", MainClass.con);
                        cmd.Parameters.AddWithValue("@ProductID", lblID.Text);
                        cmd.Parameters.AddWithValue("@ProductName", txtProductName.Text);
                        cmd.Parameters.AddWithValue("@CatID", catId);
                        cmd.Parameters.AddWithValue("@UnitID", unitid);
                        cmd.Parameters.AddWithValue("@SalePrice", txtSalePrice.Text);
                        cmd.Parameters.AddWithValue("@Remarks", txtRemarks.Text);
                        cmd.Parameters.AddWithValue("@StockControl", cbStockControl.Checked);
                        cmd.Parameters.AddWithValue("Image", ConvertImageToBytes(pictureBox1.Image));


                        if (txtCostPrice.Text == "")
                        {
                            cmd.Parameters.AddWithValue("@CostPrice", txtSalePrice.Text);
                        }

                        else
                        {
                            cmd.Parameters.AddWithValue("@CostPrice", txtCostPrice.Text);

                        }

                        

                        
                        cmd.ExecuteNonQuery();
                        MainClass.con.Close();
                        MessageBox.Show("Product Updated Successfully.");
                        btnSave.Text = "SAVE";
                        btnSave.BackColor = Color.FromArgb(39, 174, 96);
                        Clear();
                        ShowProductSID(DGVSomeProducts, ProSID, NameSID, CategorySID,  CostSID, SaleSID, RemarksSID, UnitSID);
                    }
                    catch (Exception ex)
                    {
                        MainClass.con.Close();
                        MessageBox.Show(ex.Message);
                    }

                }
            }
        }



     

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pedit = 1;
            lblID.Text = DGVSomeProducts.CurrentRow.Cells[0].Value.ToString();
            txtProductName.Text = DGVSomeProducts.CurrentRow.Cells[1].Value.ToString();
            cboCategory.Text = DGVSomeProducts.CurrentRow.Cells[2].Value.ToString();
            cboUnits.Text = DGVSomeProducts.CurrentRow.Cells[3].Value.ToString();
            txtCostPrice.Text = DGVSomeProducts.CurrentRow.Cells[4].Value.ToString();
            txtSalePrice.Text = DGVSomeProducts.CurrentRow.Cells[5].Value.ToString();
            txtRemarks.Text = DGVSomeProducts.CurrentRow.Cells[6].Value.ToString();
            MainClass.con.Open();
            SqlCommand cmd = new SqlCommand("select StockControl from ProductsTable where ProductID = '" + lblID.Text + "'", MainClass.con);
            bool cheched = bool.Parse(cmd.ExecuteScalar().ToString());
            if(cheched == true)
            {
                cbStockControl.Checked = true;
            }
            else
            {
                cbStockControl.Checked = false;
            }
            MainClass.con.Close();
            btnSave.Text = "UPDATE";
            btnSave.BackColor = Color.Orange;
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (DGVSomeProducts != null)
            {
                if (DGVSomeProducts.Rows.Count > 0)
                {
                    if (DGVSomeProducts.SelectedRows.Count == 1)
                    {
                        try
                        {
                            MainClass.con.Open();
                            SqlCommand cmd = new SqlCommand("delete from ProductsTable where ProductID = @ProductID", MainClass.con);
                            cmd.Parameters.AddWithValue("@ProductID", DGVSomeProducts.CurrentRow.Cells[0].Value.ToString());
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Record Deleted Successfully");
                            MainClass.con.Close();
                            ShowProductSID(DGVSomeProducts, ProSID, NameSID, CategorySID, CostSID, SaleSID, RemarksSID, UnitSID);
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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            pedit = 0;
            if (btnSave.BackColor == Color.Orange)
            {
                btnSave.Text = "SAVE";
                btnSave.BackColor = Color.FromArgb(39, 174, 96);
                Clear();
            }
            else
            {
                if (txtProductName.Text == "" &&
                txtCostPrice.Text == "" &&
                txtSalePrice.Text == "" &&               
                txtRemarks.Text == "" &&
                cboUnits.SelectedIndex == 0 &&
                cboCategory.SelectedIndex == 0 )
                {
                    HomeScreen hs = new HomeScreen();
                    hs.lblLoggedUser.Text = "Admin";
                    MainClass.showWindow(hs, this, MDI.ActiveForm);
                }
                else
                {
                    Clear();
                }
            }
        }

        private void txtCostPrice_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

     

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog odf = new OpenFileDialog() { Filter = "Image files(*.jpg;*.jpeg)|*.jpg;*jpeg", Multiselect = false })
                if (odf.ShowDialog() == DialogResult.OK)
                {
                    pictureBox1.Image = Image.FromFile(odf.FileName);
                }
        }

        private void DGVSomeProducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void DGVSomeProducts_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (DGVSomeProducts.SelectedRows.Count == 1)
            {
                try
                {
                    MainClass.con.Open();
                    SqlCommand cmd = new SqlCommand("select Image from ProductsTable where ProductID = '" + DGVSomeProducts.CurrentRow.Cells[0].Value.ToString() + "'", MainClass.con);
                    object ob = cmd.ExecuteScalar();
                    if (ob.ToString() != "")
                    {
                        pictureBox1.Image = ConvertByteArraytoImage((byte[])ob);
                    }
                    else
                    {
                        pictureBox1.Image = null;
                        MessageBox.Show("No Picture Found");
                    }
                    MainClass.con.Close();
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
