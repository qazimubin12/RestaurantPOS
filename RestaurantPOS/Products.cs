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
        private void ShowProductSID(DataGridView dgv2, DataGridViewColumn ID, DataGridViewColumn Name,
            DataGridViewColumn Sale, DataGridViewColumn Remarks,DataGridViewColumn Barcode,string data = null)
        {
            try
            {
                SqlCommand cmd = null;
                MainClass.con.Open();

                if (data != "")
                {
                    cmd = new SqlCommand("select p.ProductID,p.ProductName,p.SalePrice,p.Remarks,p.Barcode from ProductsTable p   where p.ProductName like '%" + data + "%'", MainClass.con);
                }
                else
                {
                    cmd = new SqlCommand("select p.ProductID,p.ProductName,p.SalePrice,p.Remarks,p.Barcode from ProductsTable p   order by p.ProductName", MainClass.con);
                }
           
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                ID.DataPropertyName = dt.Columns["ProductID"].ToString();
                Name.DataPropertyName = dt.Columns["ProductName"].ToString();
                Barcode.DataPropertyName = dt.Columns["Barcode"].ToString();
                Sale.DataPropertyName = dt.Columns["SalePrice"].ToString();
                Remarks.DataPropertyName = dt.Columns["Remarks"].ToString();
                dgv2.DataSource = dt;
                MainClass.con.Close();
            }
            catch (Exception ex)
            {
                MainClass.con.Close();
                MessageBox.Show(ex.Message);
            }
        }

        
        private void Products_Load(object sender, EventArgs e)
        {
            lblLoggedUser.Text = "Admin";
            ShowProductSID(DGVSomeProducts, ProSID, NameSID, SaleSID, RemarksSID, BarcodeGV);
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {

            ShowProductSID(DGVSomeProducts, ProSID, NameSID, SaleSID, RemarksSID,BarcodeGV,txtSearch.Text);
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
            txtSalePrice.Text = "";
            txtRemarks.Text = "";
            txtBarcode.Text = "";
            pedit = 0;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = null;
            SqlDataReader dr;

            

            MainClass.con.Open();

          

   
            
          
            
            MainClass.con.Close();

            if (pedit == 0)
            {
                if (txtProductName.Text == "" || txtSalePrice.Text == "" )
                {
                    MessageBox.Show("Please Input Details");
                }
                else
                {
                    try
                    {
                        MainClass.con.Open();
                        cmd = new SqlCommand("insert into ProductsTable (ProductName,SalePrice,Remarks,Barcode) values(@ProductName,@SalePrice,@Remarks,@Barcode)", MainClass.con);
                       
                        
                      
                        cmd.Parameters.AddWithValue("@ProductName", txtProductName.Text);
                        cmd.Parameters.AddWithValue("@Barcode", txtBarcode.Text);
                        cmd.Parameters.AddWithValue("@SalePrice", txtSalePrice.Text);
                        cmd.Parameters.AddWithValue("@Remarks", txtRemarks.Text);
                   
                        cmd.ExecuteNonQuery();
                        MainClass.con.Close();
                        MessageBox.Show("Product Inserted Successfully.");
                        Clear();
                        ShowProductSID(DGVSomeProducts, ProSID, NameSID, SaleSID, RemarksSID, BarcodeGV);
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
                        cmd = new SqlCommand("UPDATE ProductsTable SET ProductName =@ProductName,SalePrice =@SalePrice,Barcode=@Barcode, Remarks =@Remarks where ProductID = @ProductID", MainClass.con);
                        cmd.Parameters.AddWithValue("@ProductID", lblID.Text);
                        cmd.Parameters.AddWithValue("@ProductName", txtProductName.Text);
                        cmd.Parameters.AddWithValue("@Barcode", txtBarcode.Text);
                        cmd.Parameters.AddWithValue("@SalePrice", txtSalePrice.Text);
                        cmd.Parameters.AddWithValue("@Remarks", txtRemarks.Text);
   


                    
                        

                        
                        cmd.ExecuteNonQuery();
                        MainClass.con.Close();
                        MessageBox.Show("Product Updated Successfully.");
                        btnSave.Text = "SAVE";
                        btnSave.BackColor = Color.FromArgb(39, 174, 96);
                        Clear();
                        ShowProductSID(DGVSomeProducts, ProSID, NameSID, SaleSID, RemarksSID, BarcodeGV);
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
           
            txtSalePrice.Text = DGVSomeProducts.CurrentRow.Cells[2].Value.ToString();
            txtRemarks.Text = DGVSomeProducts.CurrentRow.Cells[3].Value.ToString();
           txtBarcode.Text = DGVSomeProducts.CurrentRow.Cells[4].Value.ToString();
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
                            ShowProductSID(DGVSomeProducts, ProSID, NameSID, SaleSID, RemarksSID, BarcodeGV);
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
                txtSalePrice.Text == "" && 
                txtBarcode.Text == "" &&
                txtRemarks.Text == ""  )
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

   

        private void DGVSomeProducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void DGVSomeProducts_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
