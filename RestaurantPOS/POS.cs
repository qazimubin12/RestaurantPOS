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
                cmd = new SqlCommand("select Qty from Inventory where ProductID = '" + cboProducts.SelectedValue.ToString() + "'", MainClass.con);
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
                                    ProductsData[3] = dr[1].ToString();
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
                                    ProductsData[3] = dr[1].ToString();
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
            ptot = float.Parse(ProductsData[3]) * fqty;
        }

        private void FindGrossTotal()
        {
            float gross = 0;

            if (DGVSaleCart.Rows.Count > 0)
            {
                foreach (DataGridViewRow item in DGVSaleCart.Rows)
                {
                    gross += float.Parse(item.Cells[6].Value.ToString());
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
                    DGVSaleCart.Rows.Add(Convert.ToInt32(ProductsData[0]), Convert.ToString(ProductsData[1]), Convert.ToString(ProductsData[4]), float.Parse(ProductsData[2]), float.Parse(ProductsData[3]), fqty, ptot);
                }
                else
                {
                    foreach (DataGridViewRow item in DGVSaleCart.Rows)
                    {
                        if (Convert.ToInt32(ProductsData[0]) == int.Parse(item.Cells[0].Value.ToString())
                           && (Convert.ToString(ProductsData[4]) == Convert.ToString(item.Cells[2].Value)))
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
                            if (Convert.ToInt32(ProductsData[0]) == int.Parse(item.Cells[0].Value.ToString())
                                && (Convert.ToString(ProductsData[4]) == Convert.ToString(item.Cells[2].Value)))
                            {

                                fqty += float.Parse(item.Cells[5].Value.ToString());
                                CheckTotal();
                                item.Cells[5].Value = fqty.ToString();
                                item.Cells[6].Value = ptot.ToString();
                                break;

                            }
                        }
                        else
                        {
                            if (productcheck == false)
                            {
                                DGVSaleCart.Rows.Add(Convert.ToInt32(ProductsData[0]), Convert.ToString(ProductsData[1]), Convert.ToString(ProductsData[4]), float.Parse(ProductsData[2]), float.Parse(ProductsData[3]), fqty, ptot);
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
                change = gross - paying;
                txtWChange.Text = change.ToString();
            }

        }



        private void DGVSaleCart_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1 && e.ColumnIndex != -1)
            {
                if (e.ColumnIndex == 8)
                {
                    float qty = 0;
                    float ptot = 0;
                    qty = float.Parse(DGVSaleCart.CurrentRow.Cells[5].Value.ToString());
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
                        DGVSaleCart.CurrentRow.Cells[5].Value = qty.ToString();
                        ptot = qty * float.Parse(DGVSaleCart.CurrentRow.Cells[4].Value.ToString());
                        DGVSaleCart.CurrentRow.Cells[6].Value = ptot.ToString();
                    }


                }
                else
                {
                    if (e.ColumnIndex == 7)
                    {
                        float qty = 0;
                        float ptot = 0;
                        qty = float.Parse(DGVSaleCart.CurrentRow.Cells[5].Value.ToString());
                        qty += 1;
                        DGVSaleCart.CurrentRow.Cells[5].Value = qty.ToString();
                        ptot = qty * float.Parse(DGVSaleCart.CurrentRow.Cells[4].Value.ToString());
                        DGVSaleCart.CurrentRow.Cells[6].Value = ptot.ToString();
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
            else
            {
                SqlCommand cmd = null;
                string invoiceno = "SAL" + txtInvoiceNo.Text.ToString();
                float grantotal = float.Parse(txtGrandTotal.Text.ToString());
                string CustomerInvoiceID = "";
                string SaleID = "";
                int WalkingCustomerID = 0;





                try
                {
                    MainClass.con.Open();
                    cmd = new SqlCommand("insert into SalesTable(InvoiceNo,Discount,GrandTotal)" +
                        "values (@InvoiceNo,@Discount,@GrandTotal)", MainClass.con);
                    cmd.Parameters.AddWithValue("@InvoiceNo", invoiceno);
                    cmd.Parameters.AddWithValue("@Discount", txtDiscount.Text);
                    cmd.Parameters.AddWithValue("@GrandTotal", txtGrandTotal.Text);
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
                    object packunit = null;
                    int productId = 0;
                    float packqty = 0;

                    float finalqty = 0;
                    int mode = 0;
                    int unitId = 0;
                    bool pack = true;

                    MainClass.con.Open();
                    foreach (DataGridViewRow item in DGVSaleCart.Rows)
                    {

                        try
                        {
                            cmd = new SqlCommand("select InventoryMode from ModeSwitching", MainClass.con);
                            mode = int.Parse(cmd.ExecuteScalar().ToString());
                        }
                        catch (Exception ex)
                        {
                            MainClass.con.Close();
                            MessageBox.Show(ex.Message);
                        } //Mode Checking


                        if (mode == 0)
                        {

                        }
                        else
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
                        try
                        {
                            if (pack == true)
                            {
                                cmd = new SqlCommand("select PackUnitID from ProductsTable where ProductID = '" + item.Cells[0].Value.ToString() + "' ", MainClass.con);
                            }
                            else
                            {
                                cmd = new SqlCommand("select UnitID from ProductsTable where ProductID = '" + item.Cells[0].Value.ToString() + "' ", MainClass.con);
                            }
                            unitId = int.Parse(cmd.ExecuteScalar().ToString());
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                            MainClass.con.Close();
                        } // Unit ID

                        cmd = new SqlCommand("select PackQty from ProductsTable where ProductID = '" + productId + "'", MainClass.con);
                        packqty = float.Parse(cmd.ExecuteScalar().ToString());


                        try
                        {

                            cmd = new SqlCommand("insert into SalesInfo (Sales_ID,ProductID,Quantity,SalePrice,TotalOfProduct)" +
                            "values (@Sales_ID,@ProductID,@Quantity,@SalePrice,@TotalOfProduct)", MainClass.con);
                            cmd.Parameters.AddWithValue("Sales_ID", SaleID);
                            cmd.Parameters.AddWithValue("ProductID", productId);
                            cmd.Parameters.AddWithValue("Quantity", item.Cells[5].Value.ToString());
                            cmd.Parameters.AddWithValue("SalePrice", item.Cells[4].Value.ToString());
                            cmd.Parameters.AddWithValue("TotalOfProduct", item.Cells[6].Value.ToString());
                            cmd.ExecuteNonQuery();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                            MainClass.con.Close();
                        }

                        if (mode == 0)
                        {

                        }
                        else
                        {
                            if (pack == true)
                            {
                                float stock = float.Parse(stockqty.ToString());
                                finalqty = float.Parse(item.Cells[5].Value.ToString()) * float.Parse(packqty.ToString());
                                stock -= float.Parse(finalqty.ToString());
                                MainClass.UpdateInventory(productId, stock);
                            }
                            else
                            {
                                float qty = 0;
                                float.TryParse(stockqty.ToString(), out qty);
                                qty -= float.Parse(item.Cells[5].Value.ToString());
                                MainClass.UpdateInventory(productId, qty);
                            }
                        }


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
            PurchaseReceiptForm s = new PurchaseReceiptForm();
            s.ShowDialog();
            FullClear();

        }

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
    }
}
