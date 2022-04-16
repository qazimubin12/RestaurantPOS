using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Windows.Forms;
using System;
using System.Collections.Generic;
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
    class MainClass
    {
        public static string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        public static string s = File.ReadAllText(path + "\\posconnect");
        public static SqlConnection con = new SqlConnection(s);



        public static float CashInHand()
        {

            float cash = 0;
            try
            {
                MainClass.con.Open();
                SqlCommand cmd = new SqlCommand("select CashInHand from StoreTable ", MainClass.con);
                object ob = cmd.ExecuteScalar();
                if(ob!= null)
                {
                    if(ob.ToString() != "")
                    {
                        cash = float.Parse(ob.ToString());
                    }
                }
                MainClass.con.Close();
            }
            catch (Exception ex)
            {
                MainClass.con.Close();
                MessageBox.Show(ex.Message);
            }
            return cash;
        }

        public static void HideAllTabsOnTabControl(TabControl theTabControl)
        {
            theTabControl.Appearance = TabAppearance.FlatButtons;
            theTabControl.ItemSize = new Size(0, 1);
            theTabControl.SizeMode = TabSizeMode.Fixed;
        }


        public static void ShowRecentPurchases(DataGridView dgv, DataGridViewColumn SupplierInvoiceID,DataGridViewColumn PurchaseID, DataGridViewColumn InvoiceNo, DataGridViewColumn SupplierName, DataGridViewColumn PurchaseDate, DataGridViewColumn GrandTotal)
        {

            SqlCommand cmd = new SqlCommand("select st.SupplierInvoice_ID,st.PurchaseID,st.InvoiceNo,pt.Name,st.PurchaseDate,st.GrandTotal from PurchasesTable st inner join PersonsTable pt on pt.PersonID = st.Supplier_ID", MainClass.con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            PurchaseID.DataPropertyName = dt.Columns["SupplierInvoice_ID"].ToString();
            PurchaseID.DataPropertyName = dt.Columns["PurchaseID"].ToString();
            InvoiceNo.DataPropertyName = dt.Columns["InvoiceNo"].ToString();
            SupplierName.DataPropertyName = dt.Columns["Name"].ToString();
            PurchaseDate.DataPropertyName = dt.Columns["PurchaseDate"].ToString();
            GrandTotal.DataPropertyName = dt.Columns["GrandTotal"].ToString();
            dgv.DataSource = dt;

        }
        public static DataTable Retrieve(string query)
        {
            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(query, MainClass.con);
                da.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }

        public static void showWindow(Form OpenWin, Form clsWin, Form MDIWin)
        {
            clsWin.Close();
            OpenWin.MdiParent = MDIWin;
            OpenWin.WindowState = FormWindowState.Maximized;
            OpenWin.Show();
        }


        public static void showWindow(Form OpenWin, Form MDIWin)
        {
            OpenWin.MdiParent = MDIWin;
            OpenWin.WindowState = FormWindowState.Maximized;
            OpenWin.Show();
        }


        public static void FillCategories(ComboBox cmb)
        {
            DataTable dtCategoryName = new DataTable();
            dtCategoryName.Columns.Add("CategoryID");
            dtCategoryName.Columns.Add("Category");
            dtCategoryName.Rows.Add("0", "-----Select-----");
            try
            {
                DataTable dt = Retrieve("select CategoryID, Category from CategoriesTable");
                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        foreach (DataRow category in dt.Rows)
                        {
                            dtCategoryName.Rows.Add(category["CategoryID"], category["Category"]);
                        }
                    }

                }
                cmb.DisplayMember = "Category";
                cmb.ValueMember = "CategoryID";
                cmb.DataSource = dtCategoryName;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                cmb.DataSource = dtCategoryName;
            }

        }

        public static void FillUnits(ComboBox cmb)
        {
            DataTable dgUnits = new DataTable();
            dgUnits.Columns.Add("UnitID");
            dgUnits.Columns.Add("Unit");
            dgUnits.Rows.Add("0", "-----Select-----");
            try
            {
                DataTable dt = Retrieve("select UnitID, Unit from UnitsTable");
                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        foreach (DataRow units in dt.Rows)
                        {
                            dgUnits.Rows.Add(units["UnitID"], units["Unit"]);
                        }
                    }

                }
                cmb.DisplayMember = "Unit";
                cmb.ValueMember = "UnitID";

                cmb.DataSource = dgUnits;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                cmb.DataSource = dgUnits;
            }
        }

        public static string ShowPurchaseType(string InvoiceNo)
        {
            SqlCommand cmd = new SqlCommand("select PaymentType from SupplierInvoicesTable where InvoiceNo = '" + InvoiceNo + "' ", MainClass.con);
            string method = cmd.ExecuteScalar().ToString();

            return method;
        }

        public static void ShowBill(ReportDocument rd, CrystalReportViewer crv, string proc, string param1 = "", object val1 = null)
        {
            try
            {
                SqlCommand cmd = new SqlCommand(proc, MainClass.con);
                cmd.CommandType = CommandType.StoredProcedure;
                if (param1 != "")
                {
                    cmd.Parameters.AddWithValue(param1, val1);
                }
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                rd.Load(Application.StartupPath + "\\Reports\\Bill.rpt");
                rd.SetDataSource(dt);
                crv.ReportSource = rd;
                crv.RefreshReport();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        public static void ShowDeliveryBill(ReportDocument rd, CrystalReportViewer crv, string proc, string param1 = "", object val1 = null)
        {
            try
            {
                SqlCommand cmd = new SqlCommand(proc, MainClass.con);
                cmd.CommandType = CommandType.StoredProcedure;
                if (param1 != "")
                {
                    cmd.Parameters.AddWithValue(param1, val1);
                }
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                rd.Load(Application.StartupPath + "\\Reports\\DeliveryBill.rpt");
                rd.SetDataSource(dt);
                crv.ReportSource = rd;
                crv.RefreshReport();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static void ShowTokenNumber(ReportDocument rd, CrystalReportViewer crv, string proc, string param1 = "", object val1 = null)
        {
            try
            {
                SqlCommand cmd = new SqlCommand(proc, MainClass.con);
                cmd.CommandType = CommandType.StoredProcedure;
                if (param1 != "")
                {
                    cmd.Parameters.AddWithValue(param1, val1);
                }
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                rd.Load(Application.StartupPath + "\\Reports\\TokenNumber.rpt");
                rd.SetDataSource(dt);
                crv.ReportSource = rd;
                crv.RefreshReport();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }



        public static void ShowDineInBill(ReportDocument rd, CrystalReportViewer crv, string proc, string param1 = "", object val1 = null)
        {
            try
            {
                SqlCommand cmd = new SqlCommand(proc, MainClass.con);
                cmd.CommandType = CommandType.StoredProcedure;
                if (param1 != "")
                {
                    cmd.Parameters.AddWithValue(param1, val1);
                }
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                rd.Load(Application.StartupPath + "\\Reports\\DineInBill.rpt");
                rd.SetDataSource(dt);
                crv.ReportSource = rd;
                crv.RefreshReport();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static void ShowLedgerBill(ReportDocument rd, CrystalReportViewer crv, string proc, string param1 = "", object val1 = null)
        {
            try
            {
                SqlCommand cmd = new SqlCommand(proc, MainClass.con);
                cmd.CommandType = CommandType.StoredProcedure;
                if (param1 != "")
                {
                    cmd.Parameters.AddWithValue(param1, val1);
                }
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                rd.Load(Application.StartupPath + "\\Reports\\InLedgerBill.rpt");
                rd.SetDataSource(dt);
                crv.ReportSource = rd;
                crv.RefreshReport();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }




        public static void FillBrands(ComboBox cmb)
        {
            DataTable dgBrands = new DataTable();
            dgBrands.Columns.Add("BrandID");
            dgBrands.Columns.Add("Brand");
            dgBrands.Rows.Add("0", "-----Select-----");
            try
            {
                DataTable dt = Retrieve("select BrandID, Brand from BrandsTable");
                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        foreach (DataRow Brands in dt.Rows)
                        {
                            dgBrands.Rows.Add(Brands["BrandID"], Brands["Brand"]);
                        }
                    }

                }
                cmb.DisplayMember = "Brand";
                cmb.ValueMember = "BrandID";

                cmb.DataSource = dgBrands;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                cmb.DataSource = dgBrands;
            }
        }


        public static void FillSupplier(ComboBox cmb)
        {
            DataTable dgSupplier = new DataTable();
            dgSupplier.Columns.Add("PersonID");
            dgSupplier.Columns.Add("Name");
            dgSupplier.Rows.Add("0", "-----Select-----");
            try
            {
                DataTable dt = Retrieve("select PersonID, Name from PersonsTable where Type = 'Supplier'");
                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        foreach (DataRow supplier in dt.Rows)
                        {
                            dgSupplier.Rows.Add(supplier["PersonID"], supplier["Name"]);
                        }
                    }

                }
                cmb.DisplayMember = "Name";
                cmb.ValueMember = "PersonID";
                cmb.DataSource = dgSupplier;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                cmb.DataSource = dgSupplier;
            }
        }

        public static void FillCustomer(ComboBox cmb)
        {
            DataTable dgCustomer = new DataTable();
            dgCustomer.Columns.Add("PersonID");
            dgCustomer.Columns.Add("Name");
            dgCustomer.Rows.Add("0", "-----Select-----");
            try
            {
                DataTable dt = Retrieve("select PersonID, Name from PersonsTable where Type = 'Customer'");
                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        foreach (DataRow customer in dt.Rows)
                        {
                            dgCustomer.Rows.Add(customer["PersonID"], customer["Name"]);
                        }
                    }

                }
                cmb.DisplayMember = "Name";
                cmb.ValueMember = "PersonID";
                cmb.DataSource = dgCustomer;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                cmb.DataSource = dgCustomer;
            }
        }


        public static void FillDelivery(ComboBox cmb)
        {
            DataTable dgCustomer = new DataTable();
            dgCustomer.Columns.Add("PersonID");
            dgCustomer.Columns.Add("Name");
            dgCustomer.Rows.Add("0", "-----Select-----");
            try
            {
                DataTable dt = Retrieve("select PersonID, Name from PersonsTable where Type = 'Delivery Guy'");
                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        foreach (DataRow customer in dt.Rows)
                        {
                            dgCustomer.Rows.Add(customer["PersonID"], customer["Name"]);
                        }
                    }

                }
                cmb.DisplayMember = "Name";
                cmb.ValueMember = "PersonID";
                cmb.DataSource = dgCustomer;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                cmb.DataSource = dgCustomer;
            }
        }


        public static void FillProducts(ComboBox cmb)
        {
            DataTable dgProducts = new DataTable();
            dgProducts.Columns.Add("ProductID");
            dgProducts.Columns.Add("ProductName");
            dgProducts.Rows.Add("0", "-----Select-----");
            try
            {
                DataTable dt = Retrieve("select ProductID, ProductName from ProductsTable");
                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        foreach (DataRow products in dt.Rows)
                        {
                            dgProducts.Rows.Add(products["ProductID"], products["ProductName"]);
                        }
                    }

                }
                cmb.DisplayMember = "ProductName";
                cmb.ValueMember = "ProductID";
                cmb.DataSource = dgProducts;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                cmb.DataSource = dgProducts;
            }
        }

        public static void FillProductsForPurchase(ComboBox cmb)
        {
            DataTable dgProducts = new DataTable();
            dgProducts.Columns.Add("ProductID");
            dgProducts.Columns.Add("ProductName");
            dgProducts.Rows.Add("0", "-----Select-----");
            try
            {
                DataTable dt = Retrieve("select ProductID, ProductName from ProductsTable where StockControl = 1");
                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        foreach (DataRow products in dt.Rows)
                        {
                            dgProducts.Rows.Add(products["ProductID"], products["ProductName"]);
                        }
                    }

                }
                cmb.DisplayMember = "ProductName";
                cmb.ValueMember = "ProductID";
                cmb.DataSource = dgProducts;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                cmb.DataSource = dgProducts;
            }
        }

        public static void ShowPurchaseReceipt(ReportDocument rd, CrystalReportViewer crv, string proc, string param1 = "", object val1 = null)
        {
            try
            {
                SqlCommand cmd = new SqlCommand(proc, MainClass.con);
                cmd.CommandType = CommandType.StoredProcedure;
                if (param1 != "")
                {
                    cmd.Parameters.AddWithValue(param1, val1);
                }
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                
                rd.Load(Application.StartupPath + "\\Reports\\PurchaseReciept.rpt");
                 rd.SetDataSource(dt);
                crv.ReportSource = rd;
                crv.RefreshReport();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        public static DataTable FillProductsInTextBox()
        {
            DataTable dgProducts = new DataTable();
            dgProducts.Columns.Add("ProductID");
            dgProducts.Columns.Add("ProductName");
            dgProducts.Rows.Add("0", "-----Select-----");
            try
            {
                DataTable dt = Retrieve("select ProductID, ProductName from ProductsTable");
                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        foreach (DataRow products in dt.Rows)
                        {
                            dgProducts.Rows.Add(products["ProductID"], products["ProductName"]);
                        }
                    }

                }
           
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return dgProducts;
        }

        public static void FillProductsPOS(ComboBox cmb)
        {
            DataTable dgProducts = new DataTable();
            dgProducts.Columns.Add("ProductID");
            dgProducts.Columns.Add("ProductName");
            dgProducts.Rows.Add("0", "-----Select-----");
            try
            {
                DataTable dt = Retrieve("select p.ProductID, p.ProductName from ProductsTable p ");
                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        foreach (DataRow products in dt.Rows)
                        {
                            dgProducts.Rows.Add(products["ProductID"], products["ProductName"]);
                        }
                    }

                }
                cmb.DisplayMember = "ProductName";
                cmb.ValueMember = "ProductID";
                cmb.DataSource = dgProducts;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                cmb.DataSource = dgProducts;
            }
        }

        public static void ShowProducts(DataGridView dgv, DataGridViewColumn ID, DataGridViewColumn Product, DataGridViewColumn Qty, string data = null)
        {
            try
            {
                SqlCommand cmd = null;
                MainClass.con.Open();

                if (data != "")
                {
                    cmd = new SqlCommand("select p.ProductID, p.ProductName, i.Qty from ProductsTable p inner join Inventory i on i.ProductID = p.ProductID   where p.ProductName like '%" + data + "%' and  i.Qty > 0", MainClass.con);
                }
                else
                {
                    cmd = new SqlCommand("select p.ProductID, p.ProductName, i.Qty from ProductsTable p inner join Inventory i on i.ProductID = p.ProductID where i.Qty > 0", MainClass.con);
                }

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                ID.DataPropertyName = dt.Columns["ProductID"].ToString();
                Product.DataPropertyName = dt.Columns["ProductName"].ToString();
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



        public static void UpdateInventory(Int32 ProductID, float Qty)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("update Inventory set Qty = @Qty where ProductID = @ProductID", MainClass.con);
                cmd.Parameters.AddWithValue("@ProductID", ProductID);
                cmd.Parameters.AddWithValue("@Qty", Qty);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MainClass.con.Close();
                MessageBox.Show(ex.Message);
            }
        }


        public static void ShowSaleReciept(ReportDocument rd, CrystalReportViewer crv, string proc, string param1 = "", object val1 = null)
        {
            try
            {
                SqlCommand cmd = new SqlCommand(proc, MainClass.con);
                cmd.CommandType = CommandType.StoredProcedure;
                if (param1 != "")
                {
                    cmd.Parameters.AddWithValue(param1, val1);
                }
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                rd.Load(Application.StartupPath + "\\Reports\\SaleReciept.rpt");
                rd.SetDataSource(dt);
                crv.ReportSource = rd;
                crv.RefreshReport();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        public static void ShowSaleRecieptSavedCustomer(ReportDocument rd, CrystalReportViewer crv, string proc, string param1 = "", object val1 = null)
        {
            try
            {
                SqlCommand cmd = new SqlCommand(proc, MainClass.con);
                cmd.CommandType = CommandType.StoredProcedure;
                if (param1 != "")
                {
                    cmd.Parameters.AddWithValue(param1, val1);
                }
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                rd.Load(Application.StartupPath + "\\Reports\\SaleReciept_SavedCustomer.rpt");
                rd.SetDataSource(dt);
                crv.ReportSource = rd;
                crv.RefreshReport();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

    }
}
