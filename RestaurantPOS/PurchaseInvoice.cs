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
    public partial class PurchaseInvoice : Form
    {
        public PurchaseInvoice()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            HomeScreen hs = new HomeScreen();
            hs.lblLoggedUser.Text = "Admin";
            MainClass.showWindow(hs, this, MDI.ActiveForm);
        }

        private void GenerateInvoiceNo()
        {
            try
            {
                MainClass.con.Open();
                SqlDataAdapter da = new SqlDataAdapter("select InvoiceNo from InvoiceNo order by InvoiceNo desc", MainClass.con);
                DataSet ds = new DataSet();
                da.Fill(ds);

                if(ds.Tables[0].Rows.Count > 0)
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
                SqlCommand cmd = new SqlCommand("insert into InvoiceNo (InvoiceNo) values ('" + txtInvoiceNo.Text + "')", MainClass.con);
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


        

        private void PurchaseInvoice_Load(object sender, EventArgs e)
        {
            GenerateInvoiceNo();
            MainClass.FillProductsForPurchase(cboProducts);
        }
            
        private void FillUnitComboBox(ComboBox cmb)
        {
            try
            {
                DataTable dtUnits = new DataTable();
                dtUnits.Columns.Add("Unit");
                dtUnits.Columns.Add("UnitID");
              
                DataTable dt = MainClass.Retrieve("select u.Unit,u.UnitID from UnitsTable u join ProductsTable p on p.UnitID = u.UnitID  where ProductID = '" + cboProducts.SelectedValue.ToString() + "'");
                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        foreach (DataRow units in dt.Rows)
                        {
                            dtUnits.Rows.Add(units["Unit"], units["UnitID"]);
                        }
                    }
                }
                cmb.DisplayMember = "Unit";
                cmb.ValueMember = "UnitID";
                cmb.DataSource = dtUnits;
                
            }
            catch (Exception ex)
            {
                MainClass.con.Close();
                MessageBox.Show(ex.Message);
            }
        }


        bool found = false;
        object item = false;
        private string[] ProductsData = new string[3];
        private void cboProducts_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cboProducts.SelectedIndex == 0)
            {
                txtSalePrice.Text = "";
                return;
            }
            SqlCommand cmd = null;
            GetPrice();
        }


        private void GetPrice()
        {
            SqlCommand cmd = null;
            SqlDataReader dr;
           

            try
            {
                MainClass.con.Open();
                DataTable dt = new DataTable();


                cmd = new SqlCommand("select SalePrice from ProductsTable where ProductID = '" + cboProducts.SelectedValue.ToString() + "'  ", MainClass.con);
                dr = cmd.ExecuteReader();



                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        ProductsData[0] = dr[0].ToString();
                        txtSalePrice.Text = ProductsData[0].ToString();
                    }
                }
                MainClass.con.Close();

            }
            catch (Exception ex)
            {
                MainClass.con.Close();
                MessageBox.Show(ex.Message);
            }
        }
        private void cboUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboProducts.SelectedIndex != 0)
            {
                GetPrice();
            }
        }

        private void txtQuantity_TextChanged(object sender, EventArgs e)
        {
            if(txtQuantity.Text != "" && txtQuantity.Text != "0")
            {
                float rate = float.Parse(txtSalePrice.Text);
                float qty = float.Parse(txtQuantity.Text);
                float ptot = rate * qty;
                txtProductTotal.Text = ptot.ToString();
            }
            else
            {
                txtProductTotal.Text = "0";
            }
        }

        private void GBClear()
        {
            txtProductTotal.Text = "";
            txtQuantity.Text = "";
            txtSalePrice.Text = "";
            txtQuantity.Text = "";
            txtDiscount.Text = "";
            cboProducts.SelectedIndex = 0;
            cboProducts.Focus();
        }

        private void FullClear()
        {
            GBClear();
            txtGrossTotal.Text = "";
            txtPaymentTotal.Text = "";
            txtBalance.Text = "";
            dtInvoiceDate.Value = DateTime.Now;
            DGVPurchaseCart.Rows.Clear();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            bool productalready = false;
            if(txtProductTotal.Text == "" || txtProductTotal.Text == "0")
            {
                if (txtQuantity.Text == "")
                {
                    MessageBox.Show("Please Enter Quantity", "Input Fields", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
               
            }
            else
            {
                float discount;
                float qty = float.Parse(txtQuantity.Text);
                float salerate = float.Parse(txtSalePrice.Text);
                float producttotal = float.Parse(txtProductTotal.Text);
                if (txtDiscount.Text != "")
                {
                     discount = float.Parse(txtDiscount.Text);
                }
                else
                {
                    txtDiscount.Text = "0";

                }

                if (DGVPurchaseCart.Rows.Count == 0)
                {
                    DataGridViewRow createrow = new DataGridViewRow();
                    createrow.CreateCells(DGVPurchaseCart);
                    createrow.Cells[0].Value = cboProducts.SelectedValue.ToString();
                    createrow.Cells[1].Value = cboProducts.Text.ToString();
                    createrow.Cells[2].Value = txtSalePrice.Text.ToString();
                    createrow.Cells[3].Value = txtQuantity.Text.ToString();
                    createrow.Cells[4].Value = txtDiscount.Text.ToString();
                    createrow.Cells[5].Value = txtProductTotal.Text.ToString();
                    DGVPurchaseCart.Rows.Add(createrow);
                    GBClear();
                }
                else
                {
                    foreach (DataGridViewRow check in DGVPurchaseCart.Rows)
                    {
                        if (Convert.ToString(check.Cells[0].Value) == Convert.ToString(cboProducts.SelectedValue))
                        {
                            productalready = true;
                            break;
                        }
                        else
                        {
                            productalready = false;
                        }

                    }
                    if (productalready == true)
                    {
                        foreach (DataGridViewRow row in DGVPurchaseCart.Rows)
                        {
                            if (Convert.ToString(row.Cells[0].Value) == Convert.ToString(cboProducts.SelectedValue))
                            {
                                row.Cells[3].Value = float.Parse(row.Cells[3].Value.ToString()) + qty;
                                row.Cells[5].Value = float.Parse(row.Cells[2].Value.ToString()) * float.Parse(row.Cells[3].Value.ToString());
                                GBClear();
                            }
                        }
                    }

                    else
                    {
                        if (productalready == false)
                        {
                            DataGridViewRow createrow = new DataGridViewRow();
                            createrow.CreateCells(DGVPurchaseCart);
                            createrow.Cells[0].Value = cboProducts.SelectedValue.ToString();
                            createrow.Cells[1].Value = cboProducts.Text.ToString();
                            createrow.Cells[2].Value = txtSalePrice.Text.ToString();
                            createrow.Cells[3].Value = txtQuantity.Text.ToString();
                            createrow.Cells[4].Value = txtDiscount.Text.ToString();
                            createrow.Cells[5].Value = txtProductTotal.Text.ToString();
                            DGVPurchaseCart.Rows.Add(createrow);
                            GBClear();
                        }
                    }
                }
            }
            CalculateTotal();
        }

        private void txtDiscount_TextChanged(object sender, EventArgs e)
        {
            if (txtDiscount.Text == "" || txtQuantity.Text == "")
            {
                txtDiscount.Text = "0";
            }
            else
            {
                if (txtDiscount.Text != "")
                {
                    float qty = float.Parse(txtQuantity.Text);
                    float dis = float.Parse(txtDiscount.Text);
                    float rate = float.Parse(txtSalePrice.Text);
                    txtProductTotal.Text = Convert.ToString((qty * rate) - dis);
                }
                else
                {
                    float rate = float.Parse(txtSalePrice.Text);
                    float qty;
                    float.TryParse(txtQuantity.Text.Trim(), out qty);
                    txtProductTotal.Text = Convert.ToString(qty * rate);
                }
            }
        }

      
        private void DGVPurchaseCart_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1 && e.ColumnIndex != -1)
            {
                if (e.ColumnIndex == 6)
                {
                    DGVPurchaseCart.Rows.RemoveAt(DGVPurchaseCart.CurrentRow.Index);
                }
            }
            CalculateTotal();

            if(DGVPurchaseCart.Rows.Count == 0)
            {
                FullClear();
            }
        }

        private void CalculateTotal()
        {
            float gross = 0;
            if (DGVPurchaseCart.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in DGVPurchaseCart.Rows)
                {
                    gross += float.Parse(row.Cells[5].Value.ToString());
                }
                txtGrossTotal.Text = Convert.ToString(gross);
            }
           
            txtPaymentTotal.Text = txtGrossTotal.Text;
            if (txtPaying.Text == "0" || txtPaying.Text == "")
            {
                txtBalance.Text = gross.ToString();
            }

            
        }
        private void DGVPurchaseCart_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            CalculateTotal();
        }

        private void txtPaying_TextChanged(object sender, EventArgs e)
        {

            if (txtPaying.Text != "" || txtPaying.Text == "0")
            {
                float tot = Convert.ToInt32(txtPaymentTotal.Text);
                float paying = Convert.ToInt32(txtPaying.Text);
                txtBalance.Text = Convert.ToString(tot - paying);
            }
            else
            {
                txtBalance.Text = txtPaymentTotal.Text;
            }
        }

       

        private void btnCancel_Click(object sender, EventArgs e)
        {
            FullClear();
        }

        public static int PURCHASE_ID = 0;
      
        public static int Purchase_ID = 0;

        private void btnFinalize_Click(object sender, EventArgs e)
        {
            string[] PurchaseInfos = new string[4];

            if (DGVPurchaseCart.Rows.Count == 0)
            {
                MessageBox.Show("Please Check Info");
                return;
            }
            else
            {
                if (btnFinalize.Text == "UPDATE")
                {
                    MainClass.con.Open();
                    SqlCommand cmd = null;


                    cmd = new SqlCommand("select GrandTotal from PurchasesTable where InvoiceNo = '"+lblInvoiceNo.Text+"'", MainClass.con);
                    float totalamount = float.Parse(cmd.ExecuteScalar().ToString());
                   




                    cmd = new SqlCommand("select si.Product_ID,si.Quantity,si.SalePrice from PurchasesInfo si inner join ProductsTable p on p.ProductID = si.Product_ID where Purchase_ID =  '" + lblPurchaseID.Text + "' ", MainClass.con);
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            PurchaseInfos[0] = dr[0].ToString();    //ID
                            PurchaseInfos[1] = dr[1].ToString();    //Qty
                            PurchaseInfos[2] = dr[2].ToString();    //Rate
                        }
                    }
                    dr.Close();
                    MainClass.con.Close();
                    foreach (DataGridViewRow item in DGVPurchaseCart.Rows)
                    {
                        MainClass.con.Open();
                        cmd = new SqlCommand("select Qty from Inventory where ProductID = '" + item.Cells["PcodeGV"].Value.ToString() + "'", MainClass.con);
                        object ob = cmd.ExecuteScalar();
                        if (ob == null)
                        {
                      

                            cmd = new SqlCommand("insert into Inventory (ProductID,Qty,Rate) values (@ProductID,@Qty,@Rate)", MainClass.con);
                            cmd.Parameters.AddWithValue("@ProductID", item.Cells["PcodeGV"].Value.ToString());
                            cmd.Parameters.AddWithValue("@Qty", item.Cells["QuantityGV"].Value.ToString());
                            cmd.Parameters.AddWithValue("@Rate", item.Cells["SalePriceGV"].Value.ToString());
                            cmd.ExecuteNonQuery();
                        }
                        else
                        {
                            float quantity = float.Parse(item.Cells["QuantityGV"].Value.ToString());
                            if (float.Parse(PurchaseInfos[1]) == quantity)
                            {
                                quantity = float.Parse(item.Cells["QuantityGV"].Value.ToString());
                            }
                            else
                            {
                                quantity = float.Parse(PurchaseInfos[1]) - float.Parse(PurchaseInfos[1]);
                            }
                            int ProductID = int.Parse(item.Cells["PcodeGV"].Value.ToString());
                            MainClass.UpdateInventory(ProductID, quantity);
                        }
                    } //Inventory Insert / Update

                    cmd = new SqlCommand("delete from PurchasesInfo where Purchase_ID = '" + lblPurchaseID.Text + "'", MainClass.con);
                    cmd.ExecuteNonQuery();

                    

                    MainClass.con.Close();

                    string invoiceno = lblInvoiceNo.Text;
                    float grantotal = float.Parse(txtGrossTotal.Text.ToString());
                    string SupplierInvoiceID = "";
                    string PurchaseID = "";

               
                    try
                    {
                        MainClass.con.Open();

                        cmd = new SqlCommand("update PurchasesTable set GrandTotal = @GrandTotal,PurchaseDate=@PurchaseDate where  PurchaseID = '" + lblPurchaseID.Text + "'", MainClass.con);
                        cmd.Parameters.AddWithValue("@GrandTotal", grantotal);
                        cmd.Parameters.AddWithValue("@PurchaseDate", dtInvoiceDate.Value.ToShortDateString());
                        cmd.ExecuteNonQuery();
                        MainClass.con.Close();
                    }
                    catch (Exception ex)
                    {
                        MainClass.con.Close();
                        MessageBox.Show(ex.Message);
                    } // Inserting into Purchases
                    try
                    {
                        
                        PurchaseID = lblPurchaseID.Text;
                        Purchase_ID = int.Parse(PurchaseID.ToString());
                       
                    }
                    catch (Exception ex)
                    {
                        MainClass.con.Close();
                        MessageBox.Show(ex.Message);
                    } // Get Purchase ID
                    try
                    {
                        MainClass.con.Open();
                        foreach (DataGridViewRow item in DGVPurchaseCart.Rows)
                        {
                            int ProductID = 0;
                            int UnitID = 0;
                            try
                            {
                                cmd = new SqlCommand("select ProductID from ProductsTable where ProductName = '" + item.Cells[1].Value.ToString() + "'", MainClass.con);
                                ProductID = int.Parse(cmd.ExecuteScalar().ToString());
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                                MainClass.con.Close();
                            } // ProductID


                            float qty = float.Parse(item.Cells[3].Value.ToString());
                            float sale = float.Parse(item.Cells[2].Value.ToString());
                            float discount = float.Parse(item.Cells[4].Value.ToString());
                            float totofprodcut = float.Parse(item.Cells[5].Value.ToString());


                            string insertPurchaseInfo = "insert into PurchasesInfo (Purchase_ID,Product_ID,Quantity,SalePrice,Discount,TotalOfProduct) values (@Purchase_ID,@Product_ID,@Quantity,@SalePrice,@Discount,@TotalOfProduct)";
                            cmd = new SqlCommand(insertPurchaseInfo, MainClass.con);
                            cmd.Parameters.AddWithValue("@Purchase_ID", int.Parse(PurchaseID.ToString()));
                            cmd.Parameters.AddWithValue("@Product_ID", ProductID);
                            cmd.Parameters.AddWithValue("@Quantity", qty);
                            cmd.Parameters.AddWithValue("@SalePrice", sale);
                            cmd.Parameters.AddWithValue("@Discount", discount);
                            cmd.Parameters.AddWithValue("@TotalOfProduct", totofprodcut);
                            cmd.ExecuteNonQuery();
                        }
                        MainClass.con.Close();
                    }
                    catch (Exception ex)
                    {
                        MainClass.con.Close();
                        MessageBox.Show(ex.Message);
                    } // Inserting Purchase Info
                    try
                    {

                        int productId = 0;
                        int unitId = 0;
                        object stockqty = null;

                        MainClass.con.Open();
                        foreach (DataGridViewRow item in DGVPurchaseCart.Rows)
                        {
                            try
                            {
                                cmd = new SqlCommand("select Qty from Inventory where ProductID = '" + item.Cells[0].Value.ToString() + "'", MainClass.con);
                                stockqty = cmd.ExecuteScalar();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                                MainClass.con.Close();
                            }


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
                            

                            float finalqty = 0;
                            float costprice = float.Parse(item.Cells[4].Value.ToString());
                            if (stockqty == null)
                            {

                                cmd = new SqlCommand("insert into Inventory (ProductID,Qty,CostPrice) values (@ProductID,@Qty,@Rate)", MainClass.con);

                                cmd.Parameters.AddWithValue("@ProductID", productId);
                                cmd.Parameters.AddWithValue("@Qty", item.Cells[3].Value.ToString());
                                cmd.Parameters.AddWithValue("@Rate", costprice);
                                cmd.ExecuteNonQuery();

                            } // Inserting 
                            else
                            {
                                float qty = 0;
                                float.TryParse(stockqty.ToString(), out qty);
                                qty += float.Parse(item.Cells[3].Value.ToString());
                                MainClass.UpdateInventory(productId, qty);

                            } //Updating
                        }
                        MainClass.con.Close();

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                        MainClass.con.Close();
                    } // Inserting and Updating Inventory
                    
                    int SupplierLedgerID = 0;
                    
                    

                }
                
                
                else{

                    SqlCommand cmd = null;
                    string invoiceno = "PUR" + txtInvoiceNo.Text.ToString();
                    float grantotal = float.Parse(txtGrossTotal.Text.ToString());
                    string SupplierInvoiceID = "";
                    string PurchaseID = "";

                  
                    
                    try
                    {
                        MainClass.con.Open();
                        cmd = new SqlCommand("insert into PurchasesTable (InvoiceNo,GrandTotal,PurchaseDate) values (" +
                            "@InvoiceNo,@GrandTotal,@PurchaseDate)", MainClass.con);
                        cmd.Parameters.AddWithValue("@InvoiceNo", invoiceno);
                        cmd.Parameters.AddWithValue("@GrandTotal", grantotal);
                        cmd.Parameters.AddWithValue("@PurchaseDate", dtInvoiceDate.Value.ToShortDateString());
                        cmd.ExecuteNonQuery();
                        MainClass.con.Close();
                    }
                    catch (Exception ex)
                    {
                        MainClass.con.Close();
                        MessageBox.Show(ex.Message);
                    } // Inserting into Purchases
                   
                    try
                    {
                        MainClass.con.Open();
                        PurchaseID = Convert.ToString(MainClass.Retrieve("select MAX(PurchaseID) from PurchasesTable").Rows[0][0]);
                        if (string.IsNullOrEmpty(PurchaseID))
                        {
                            MessageBox.Show("Please Check The Error or Try Again");
                            return;
                        }
                        PURCHASE_ID = int.Parse(PurchaseID);
                        MainClass.con.Close();
                    }
                    catch (Exception ex)
                    {
                        MainClass.con.Close();
                        MessageBox.Show(ex.Message);
                    } // Get Purchase ID
                    try
                    {
                        MainClass.con.Open();
                        foreach (DataGridViewRow item in DGVPurchaseCart.Rows)
                        {
                            int ProductID = 0;
                            int UnitID = 0;
                            try
                            {
                                cmd = new SqlCommand("select ProductID from ProductsTable where ProductName = '" + item.Cells[1].Value.ToString() + "'", MainClass.con);
                                ProductID = int.Parse(cmd.ExecuteScalar().ToString());
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                                MainClass.con.Close();
                            } // ProductID
                            

                            float qty = float.Parse(item.Cells[3].Value.ToString());
                            float sale = float.Parse(item.Cells[2].Value.ToString());
                            float discount = float.Parse(item.Cells[4].Value.ToString());
                            float totofprodcut = float.Parse(item.Cells[5].Value.ToString());


                            string insertPurchaseInfo = "insert into PurchasesInfo (Purchase_ID,Product_ID,Quantity,SalePrice,Discount,TotalOfProduct) values (@Purchase_ID,@Product_ID,@Quantity,@SalePrice,@Discount,@TotalOfProduct)";
                            cmd = new SqlCommand(insertPurchaseInfo, MainClass.con);
                            cmd.Parameters.AddWithValue("@Purchase_ID", PurchaseID);
                            cmd.Parameters.AddWithValue("@Product_ID", ProductID);
                            cmd.Parameters.AddWithValue("@Quantity", qty);
                            cmd.Parameters.AddWithValue("@SalePrice", sale);
                            cmd.Parameters.AddWithValue("@Discount", discount);
                            cmd.Parameters.AddWithValue("@TotalOfProduct", totofprodcut);
                            cmd.ExecuteNonQuery();
                        }
                        MainClass.con.Close();
                    }
                    catch (Exception ex)
                    {
                        MainClass.con.Close();
                        MessageBox.Show(ex.Message);
                    } // Inserting Purchase Info
                    try
                    {

                        int productId = 0;
                        int unitId = 0;
                        object stockqty = null;

                        MainClass.con.Open();
                        foreach (DataGridViewRow item in DGVPurchaseCart.Rows)
                        {
                            try
                            {
                                cmd = new SqlCommand("select Qty from Inventory where ProductID = '" + item.Cells[0].Value.ToString() + "'", MainClass.con);
                                stockqty = cmd.ExecuteScalar();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                                MainClass.con.Close();
                            }


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



                          
                            float costprice = 0;
                            float finalqty = 0;
                            if (stockqty == null)
                            {


                

                                cmd = new SqlCommand("insert into Inventory (ProductID,Unit,Qty,Rate) values (@ProductID,@Unit,@Qty,@Rate)", MainClass.con);

                                cmd.Parameters.AddWithValue("@ProductID", productId);
                                cmd.Parameters.AddWithValue("@Unit", unitId);
                                cmd.Parameters.AddWithValue("@Qty", item.Cells[3].Value.ToString());
                                cmd.Parameters.AddWithValue("@Rate", item.Cells[2].Value.ToString());
                                cmd.ExecuteNonQuery();

                            } // Inserting 
                            else
                            {

                                float qty = 0;
                                float.TryParse(stockqty.ToString(), out qty);
                                qty += float.Parse(item.Cells[5].Value.ToString());
                                MainClass.UpdateInventory(productId, qty);

                            } //Updating
                        }
                        MainClass.con.Close();

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);

                        MainClass.con.Close();
                    } // Inserting and Updating Inventory
                   
                }
                btnGenerate_Click(sender, e);
                MessageBox.Show("Purchase Successfuly");
                PurchaseReceiptForm pr = new PurchaseReceiptForm();
                pr.Show();
            }
            
         
            FullClear();
        }

        private void btnRecentPurchases_Click(object sender, EventArgs e)
        {
            RecentPurchases rec = new RecentPurchases(this);
            rec.Show();
        }
    }
}
