﻿using System;
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
    public partial class POS : Form
    {
        //  QuantityForm quantity;
        bool productcheck = false;
        int combosearch = 0;
        public static bool savedcustomercheck = false;
        public POS()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Login ls = new Login();
            MainClass.showWindow(ls, this, MDI.ActiveForm);
        }

        private void POS_Load(object sender, EventArgs e)
        {
            MainClass.FillProductsPOS(cboProducts);
            GenerateInvoiceNo();
            ShowStore();
        }

        private void ShowStore()
        {
            MainClass.con.Open();
            SqlCommand cmd = new SqlCommand("select * from StoreTable ", MainClass.con);
            SqlDataReader dr = cmd.ExecuteReader();
            dr.Read();
            if (dr.HasRows)
            {

                lblStore.Text = dr["StoreName"].ToString();
                // lblStoreAddress.Text = dr["StoreAddress"].ToString();
            }
            else
            {
                lblStore.Text = "";
                lblStoreAddress.Text = "";
            }

            dr.Close();
            MainClass.con.Close();
        }

        private void cboProducts_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F3)
            {
                SearchProducts sp = new SearchProducts(this);
                sp.ShowDialog();
            }
            else
            {
                if (e.KeyCode == Keys.Enter)
                {
                    SqlCommand cmd = null;
                    if (cboProducts.Text != "" && cboProducts.SelectedIndex != 0)
                    {
                        try
                        {
                            MainClass.con.Open();
                            cmd = new SqlCommand("select ProductID,ProductName from ProductsTable where ProductName = '" + cboProducts.Text + "'", MainClass.con);
                            SqlDataReader dr = cmd.ExecuteReader();
                            if (dr.HasRows)
                            {
                                while (dr.Read())
                                {
                                    ProductsData[0] = dr[0].ToString(); // pro id
                                    ProductsData[1] = dr[1].ToString(); // Pro Nmae
                                }
                            }
                            else
                            {
                                Array.Clear(ProductsData, 0, ProductsData.Length);
                            }
                            MainClass.con.Close();
                        }
                        catch (Exception ex)
                        {
                            MainClass.con.Close();
                            MessageBox.Show(ex.Message);
                        } //Get Product Info
                        QuantityForm qty2 = new QuantityForm(this);
                        qty2.ShowDialog();
                        combosearch = 1;
                        btnAdd_Click(sender, e);
                        cboProducts.SelectedIndex = 0;
                        txtSearhBarcode.Focus();
                    }
                    else
                    {
                        MessageBox.Show("Please Select Any Item");
                        return;
                    }
                }

            }
        }



        private string[] ProductsData = new string[5];
        float fqty = 0;
        int error = 0;
        int proceed = 1;
        int mode2 = 0;
        float ptot = 0;
        private void GatheringData()
        {
            SqlCommand cmd = null;
            fqty = 0;
            fqty = float.Parse(QuantityForm.ControlID.TextData);
            error = 0;




            try
            {
                MainClass.con.Open();
                if (combosearch == 0)
                {
                    cmd = new SqlCommand("select ProductID from ProductsTable where Barcode = '" + txtSearhBarcode.Text + "'", MainClass.con);
                    object ProductID = cmd.ExecuteScalar();
                    cmd = new SqlCommand("select Qty from Inventory where ProductID = '" + ProductID + "'", MainClass.con);

                }
                else
                {
                    cmd = new SqlCommand("select Qty from Inventory where ProductID = '" + cboProducts.SelectedValue.ToString() + "'", MainClass.con);
                }
                object ob = cmd.ExecuteScalar();
                if (ob != null)
                {
                    if (int.Parse(ob.ToString()) != 0)
                    {
                        proceed = 1;
                    }
                    else
                    {
                        MessageBox.Show("NO STOCKS");
                        proceed = 0;
                        MainClass.con.Close();
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("NO STOCKS");
                    proceed = 0;
                    MainClass.con.Close();
                    return;
                }
                MainClass.con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                MainClass.con.Close();
            } //checking qty


            if (proceed == 1)
            {

                if (combosearch == 0)
                {
                    if (error == 0)
                    {

                        try
                        {
                            MainClass.con.Open();
                            cmd = new SqlCommand("select SalePrice from ProductsTable  where Barcode = '" + txtSearhBarcode.Text + "'", MainClass.con);
                            SqlDataReader dr = cmd.ExecuteReader();
                            if (dr.HasRows)
                            {
                                while (dr.Read())
                                {
                                    ProductsData[2] = dr[0].ToString();
                                }
                            }
                            MainClass.con.Close();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                            MainClass.con.Close();
                        } //FindingRAtes
                    }


                    else
                    {

                    }
                }
                else
                {
                    if (error == 0)
                    {

                        try
                        {
                            MainClass.con.Open();
                            cmd = new SqlCommand("select SalePrice from ProductsTable  where ProductName = '" + cboProducts.Text + "'", MainClass.con);
                            SqlDataReader dr = cmd.ExecuteReader();
                            if (dr.HasRows)
                            {
                                while (dr.Read())
                                {
                                    ProductsData[2] = dr[0].ToString();
                                }
                            }
                            MainClass.con.Close();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                            MainClass.con.Close();
                        } //FindingRAtes
                    }


                }



            }
        }
        private void CheckTotal()
        {
            ptot = 0;
            ptot = float.Parse(ProductsData[2]) * fqty;
        }

        private void FindGrossTotal()
        {
            float gross = 0;

            if (DGVSaleCart.Rows.Count > 0)
            {
                foreach (DataGridViewRow item in DGVSaleCart.Rows)
                {
                    gross += float.Parse(item.Cells[4].Value.ToString());
                }
                txtGrandTotal.Text = gross.ToString();
                txtWPaying.Enabled = true;
            }
            else
            {
                gross = 0;
                txtGrandTotal.Text = gross.ToString();
                txtWPaying.Enabled = false;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

           
            GatheringData();
            if (proceed == 1)
            {
                CheckTotal();

                if (DGVSaleCart.Rows.Count == 0)
                {
                    int ID = Convert.ToInt32(ProductsData[0]);
                    string Name = ProductsData[1];
                    float Price = float.Parse(ProductsData[2]);
                    float Qty = fqty;
                    float Total = ptot;
                    DGVSaleCart.Rows.Add(ID, Name, Price, Qty, Total);
                }
                else
                {
                    foreach (DataGridViewRow item in DGVSaleCart.Rows)
                    {
                        if (Convert.ToInt32(ProductsData[0]) == int.Parse(item.Cells[0].Value.ToString()))

                        {
                            productcheck = true;
                            break;
                        }
                        else
                        {
                            productcheck = false;

                        }
                    }

                    foreach (DataGridViewRow item in DGVSaleCart.Rows)
                    {
                        if (productcheck == true)
                        {
                            if (Convert.ToInt32(ProductsData[0]) == int.Parse(item.Cells[0].Value.ToString()))

                            {

                                fqty += float.Parse(item.Cells[3].Value.ToString());
                                CheckTotal();
                                item.Cells[3].Value = fqty.ToString();
                                item.Cells[4].Value = ptot.ToString();
                                break;

                            }
                        }
                        else
                        {
                            if (productcheck == false)
                            {
                                int ID = Convert.ToInt32(ProductsData[0]);
                                string Name = ProductsData[1];
                                float Price = float.Parse(ProductsData[2]);
                                float Qty = fqty;
                                float Total = ptot;
                                DGVSaleCart.Rows.Add(ID, Name, Price, Qty, Total);
                                break;
                            }
                        }
                    }
                }
                FindGrossTotal();
            }
        }

        private void txtSearhBarcode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SqlCommand cmd = null;
                SqlDataReader dr = null;
                if (txtSearhBarcode.Text != "")
                {
                    try
                    {
                        MainClass.con.Open();
                        cmd = new SqlCommand("select * from ProductsTable where Barcode = '" + txtSearhBarcode.Text + "'", MainClass.con);
                        dr = cmd.ExecuteReader();
                        if (dr.HasRows)
                        {
                            MainClass.con.Close();
                            try
                            {
                                MainClass.con.Open();
                                cmd = new SqlCommand("select ProductID,ProductName from ProductsTable where Barcode = '" + txtSearhBarcode.Text + "'", MainClass.con);
                                dr = cmd.ExecuteReader();
                                if (dr.HasRows)
                                {
                                    while (dr.Read())
                                    {
                                        ProductsData[0] = dr[0].ToString(); // pro id
                                        ProductsData[1] = dr[1].ToString(); // Pro Nmae
                                    }
                                }

                                else
                                {
                                    Array.Clear(ProductsData, 0, ProductsData.Length);
                                }
                                MainClass.con.Close();
                            }
                            catch (Exception ex)
                            {
                                MainClass.con.Close();
                                MessageBox.Show(ex.Message);
                            }//Get Product Info
                            QuantityForm qty2 = new QuantityForm(this);
                            qty2.ShowDialog();
                            btnAdd_Click(sender, e);
                            txtSearhBarcode.Text = "";
                            txtSearhBarcode.Focus();
                        }
                        else
                        {
                            MainClass.con.Close();
                            MessageBox.Show("No Product Found");
                            return;
                        }

                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show(ex.Message);
                        MainClass.con.Close();
                    }

                }
                else
                {
                    MessageBox.Show("Please Enter Barcode First");
                    return;
                }
            }
        }



        private void txtWPaying_TextChanged(object sender, EventArgs e)
        {
            float gross;
            if (txtGrandTotal.Text == "")
            {
                gross = 0;
            }
            else
            {
                gross = float.Parse(txtGrandTotal.Text.ToString());

            }

            if (txtWPaying.Text == "" || txtWPaying.Text == "0")
            {
                txtWChange.Text = gross.ToString();
            }
            else
            {
                float paying = 0;
                float change = 0;
                paying = float.Parse(txtWPaying.Text);
                change = paying - gross;
                txtWChange.Text = change.ToString();
            }

        }



        private void DGVSaleCart_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1 && e.ColumnIndex != -1)
            {
                if (e.ColumnIndex == 5)
                {
                    float qty = 0;
                    float ptot = 0;
                    qty = float.Parse(DGVSaleCart.CurrentRow.Cells[3].Value.ToString());
                    qty += 1;
                    DGVSaleCart.CurrentRow.Cells[3].Value = qty.ToString();
                    ptot = qty * float.Parse(DGVSaleCart.CurrentRow.Cells["SalePriceGV"].Value.ToString());
                    DGVSaleCart.CurrentRow.Cells[4].Value = ptot.ToString();


                }
                else
                {
                    if (e.ColumnIndex == 6)
                    {

                        float qty = 0;
                        float ptot = 0;
                        qty = float.Parse(DGVSaleCart.CurrentRow.Cells[3].Value.ToString());
                        if (qty == 1)
                        {
                            DGVSaleCart.Rows.RemoveAt(DGVSaleCart.CurrentRow.Index);
                        }
                        else
                        {
                            qty -= 1;
                        }

                        if (DGVSaleCart.Rows.Count != 0)
                        {
                            DGVSaleCart.CurrentRow.Cells[3].Value = qty.ToString();
                            ptot = qty * float.Parse(DGVSaleCart.CurrentRow.Cells["SalePriceGV"].Value.ToString());
                            DGVSaleCart.CurrentRow.Cells[4].Value = ptot.ToString();
                        }


                       
                    }
                }

            }
            FindGrossTotal();

        }

        private void GenerateInvoiceNo()
        {
            try
            {
                MainClass.con.Open();
                SqlDataAdapter da = new SqlDataAdapter("select InvoiceNo from SaleInvoiceNo order by InvoiceNo desc", MainClass.con);
                DataSet ds = new DataSet();
                da.Fill(ds);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    txtInvoiceNo.Text = (int.Parse(ds.Tables[0].Rows[0][0].ToString()) + 1).ToString();
                }
                else
                {
                    txtInvoiceNo.Text = "1";
                }
                MainClass.con.Close();
            }
            catch (Exception ex)
            {
                MainClass.con.Close();
                MessageBox.Show(ex.Message);
            }
        }


        private void btnGenerate_Click(object sender, EventArgs e)
        {
            try
            {
                MainClass.con.Open();
                SqlCommand cmd = new SqlCommand("insert into SaleInvoiceNo (InvoiceNo) values ('" + txtInvoiceNo.Text + "')", MainClass.con);
                cmd.ExecuteNonQuery();
                MainClass.con.Close();
                GenerateInvoiceNo();
            }
            catch (Exception ex)
            {
                MainClass.con.Close();
                MessageBox.Show(ex.Message);
            }
        }



        private void FullClear()
        {
            txtGrandTotal.Text = "";
            txtWPaying.Text = "";
            txtWChange.Text = "";
            dtInvoiceDate.Value = DateTime.Now;
            DGVSaleCart.Rows.Clear();
            txtDiscount.Text = "";
            cboProducts.SelectedIndex = 0;
        }


        private void btnFinalize_Click(object sender, EventArgs e)
        {
            if (DGVSaleCart.Rows.Count == 0)
            {
                MessageBox.Show("Please Enter Items");
                return;
            }
            else if (float.Parse(txtWChange.Text) < 0) 
            {
                MessageBox.Show("Please Enter Correct Value");
                return;
            }
            else
            {
                SqlCommand cmd = null;
                string invoiceno = "SAL" + txtInvoiceNo.Text.ToString();
                float grantotal = float.Parse(txtGrandTotal.Text.ToString());
                string SaleID = "";
                string saletime = "";




                try
                {
                    MainClass.con.Open();

                    cmd = new SqlCommand("SELECT CONVERT(varchar(15),  CAST(GETDATE() AS TIME), 100) as SaleTime", MainClass.con);
                    saletime = cmd.ExecuteScalar().ToString();

                    cmd = new SqlCommand("insert into SalesTable(InvoiceNo,Discount,GrandTotal,SaleDate,Paying,Change,SaleTime,Cashier)" +
                        "values (@InvoiceNo,@Discount,@GrandTotal,@SaleDate,@Paying,@Change,@SaleTime,@Cashier)", MainClass.con);
                    cmd.Parameters.AddWithValue("@InvoiceNo", invoiceno);
                    cmd.Parameters.AddWithValue("@Discount", txtDiscount.Text);
                    cmd.Parameters.AddWithValue("@GrandTotal", txtGrandTotal.Text);
                    cmd.Parameters.AddWithValue("@SaleDate", dtInvoiceDate.Value.ToShortDateString());
                    cmd.Parameters.AddWithValue("@Paying", float.Parse(txtWPaying.Text));
                    cmd.Parameters.AddWithValue("@Change", float.Parse(txtWChange.Text));
                    cmd.Parameters.AddWithValue("@SaleTime", saletime);
                    cmd.Parameters.AddWithValue("@Cashier", lblLoggedInUser.Text);
                    cmd.ExecuteNonQuery();
                    MainClass.con.Close();
                }
                catch (Exception ex)
                {
                    MainClass.con.Close();
                    MessageBox.Show(ex.Message);
                } // Inseeting Ssales
                try
                {
                    MainClass.con.Open();
                    SaleID = Convert.ToString(MainClass.Retrieve("select MAX(SaleID) from SalesTable").Rows[0][0]);
                    if (string.IsNullOrEmpty(SaleID))
                    {
                        MessageBox.Show("Please Check The Error or Try Again");
                        return;
                    }
                    SALEID = int.Parse(SaleID);
                    MainClass.con.Close();
                }
                catch (Exception ex)
                {
                    MainClass.con.Close();
                    MessageBox.Show(ex.Message);
                } // Get Sale ID
                try
                {
                    object stockqty = null;
                    int productId = 0;
                    MainClass.con.Open();
                    foreach (DataGridViewRow item in DGVSaleCart.Rows)
                    {




                        try
                        {
                            cmd = new SqlCommand("select Qty from Inventory where ProductID = '" + item.Cells[0].Value.ToString() + "'", MainClass.con);
                            stockqty = cmd.ExecuteScalar();
                        }
                        catch (Exception ex)
                        {
                            MainClass.con.Close();
                            MessageBox.Show(ex.Message);
                        } //Finding StockQty




                        try
                        {
                            cmd = new SqlCommand("select ProductID from ProductsTable where ProductName = '" + item.Cells[1].Value.ToString() + "' ", MainClass.con);
                            productId = int.Parse(cmd.ExecuteScalar().ToString());
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                            MainClass.con.Close();
                        } // Product ID


                        try
                        {

                            cmd = new SqlCommand("insert into SalesInfo (Sales_ID,ProductID,Quantity,SalePrice,TotalOfProduct)" +
                            "values (@Sales_ID,@ProductID,@Quantity,@SalePrice,@TotalOfProduct)", MainClass.con);
                            cmd.Parameters.AddWithValue("Sales_ID", SaleID);
                            cmd.Parameters.AddWithValue("ProductID", productId);
                            cmd.Parameters.AddWithValue("Quantity", item.Cells["QuantityGV"].Value.ToString());
                            cmd.Parameters.AddWithValue("SalePrice", item.Cells["SalePriceGV"].Value.ToString());
                            cmd.Parameters.AddWithValue("TotalOfProduct", item.Cells["TotalOfProductGV"].Value.ToString());
                            cmd.ExecuteNonQuery();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                            MainClass.con.Close();
                        }


                        float qty = 0;
                        float.TryParse(stockqty.ToString(), out qty);
                        qty -= float.Parse(item.Cells["QuantityGV"].Value.ToString());
                        MainClass.UpdateInventory(productId, qty);




                    }
                    MainClass.con.Close();
                }
                catch (Exception ex)
                {
                    MainClass.con.Close();
                    MessageBox.Show(ex.Message);
                } //Updating Inventory

            }

            btnGenerate_Click(sender, e);
            MessageBox.Show("Sale Successfuly");
            
            savedcustomercheck = false;
            BillForm s = new BillForm();
            s.ShowDialog();
            FullClear();

        }

        public static int SALEID = 0;

        private void txtDiscount_TextChanged(object sender, EventArgs e)
        {
            if (txtDiscount.Text == "")
            {
                txtDiscount.Text = "0";
            }
            else
            {
                float gross = 0;
                float dis = 0;
                foreach (DataGridViewRow item in DGVSaleCart.Rows)
                {
                    gross += float.Parse(item.Cells[6].Value.ToString());
                }
                dis = float.Parse(txtDiscount.Text);
                gross -= dis;
                txtGrandTotal.Text = gross.ToString();

            }
        }

        private void cboProducts_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnRecentSales_Click(object sender, EventArgs e)
        {
            RecentSales rc = new RecentSales(this);
            rc.ShowDialog();
        }

        private void lblID_TextChanged(object sender, EventArgs e)
        {
            
            if(lblID.Text != "")
            {
                try
                {
                    lblID.Text = RecentSales.SALEID.ToString();
                    MainClass.con.Open();
                    SqlCommand cmd = null;
                    SqlDataReader dr;
                    cmd = new SqlCommand("select p.ProductID,p.ProductName,s.Quantity,s.SalePrice,s.TotalOfProduct from SalesInfo s inner join ProductsTable p on p.ProductID = s.ProductID where s.Sales_ID = " + lblID.Text + "", MainClass.con);
                    dr = cmd.ExecuteReader();
                    if(dr.HasRows)
                    {
                        while(dr.Read())
                        {
                            DGVSaleCart.Rows.Add(dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString());
                        }
                        dr.Close();
                    }


                    cmd = new SqlCommand("select GrandTotal from SalesTable where SaleID = '" + lblID.Text + "' ", MainClass.con);
                    txtGrandTotal.Text = cmd.ExecuteScalar().ToString();

                    cmd = new SqlCommand("select InvoiceNo from SalesTable where SaleID = '" + lblID.Text + "' ", MainClass.con);
                    txtInvoiceNo.Text = cmd.ExecuteScalar().ToString();

                    cmd = new SqlCommand("select Paying from SalesTable where SaleID = '" + lblID.Text + "' ", MainClass.con);
                    txtWPaying.Text = cmd.ExecuteScalar().ToString();

                    cmd = new SqlCommand("select Change from SalesTable where SaleID = '" + lblID.Text + "' ", MainClass.con);
                    txtWChange.Text = cmd.ExecuteScalar().ToString();


                    MainClass.con.Close();


                  
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    MainClass.con.Close();
                }
         
            }
        }

        private void lblID_Click(object sender, EventArgs e)
        {

        }
    }
}
