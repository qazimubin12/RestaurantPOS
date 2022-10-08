using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace RestaurantPOS
{
    public partial class RestaurantPOS : Form
    {
        private Button foodbutton;
        private Label foodprice;
        private Button categoryButton;
        private Label foodname;
        int tokengeneration = 0;
        public RestaurantPOS()
        {
            InitializeComponent();

        }


        private void CalculateTotal()
        {
            float total = 0;
            foreach (DataGridViewRow item in DGVCartProduct.Rows)
            {
                total += float.Parse(item.Cells["TotalGV"].Value.ToString());
                lblGrandTotal.Text = total.ToString();
            }
        }
     

        private void GetCategoryData()
        {
            fpCategory.Controls.Clear();
            SqlCommand cmd = null;
            SqlDataReader dr;
            try
            {
                MainClass.con.Open();
                cmd = new SqlCommand("select CategoryID,Category from CategoriesTable", MainClass.con);
                dr = cmd.ExecuteReader();
                while(dr.Read())
                {
                    categoryButton = new Button();
                    categoryButton.Width = 150;
                    categoryButton.Height = 50;
                    categoryButton.Font = new Font("Arial", 10);
                    categoryButton.FlatStyle = FlatStyle.Flat;
                    categoryButton.BackColor = Color.FromArgb(39, 174, 96);
                    categoryButton.BackgroundImageLayout = ImageLayout.Stretch;
                    categoryButton.Text = dr["Category"].ToString();
                    categoryButton.ForeColor = Color.White;
                    categoryButton.Tag = dr["CategoryID"].ToString();
                    fpCategory.Controls.Add(categoryButton);

                    
                    categoryButton.Click += new EventHandler(OnCategoryButtonClick);
                }

                MainClass.con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                MainClass.con.Close();
            }
        }


        public void OnCategoryButtonClick(object sender, EventArgs e)
        {
            string tag = ((Button)sender).Tag.ToString();
            GetProductData(null,tag);
        }


        public void OnProductButtonClick(object sender, EventArgs e)
        {
            SqlCommand cmd = null;
            SqlDataReader dr;
            bool productcheck = false;
            string unitname = "";
            string tag = "";
            int unitId = 0;
            if (sender.GetType().Name == "Label")
            {
                tag = ((Label)sender).Tag.ToString();

            }
            else if (sender.GetType().Name == "Button")
            {
                tag = ((Button)sender).Tag.ToString();
            }

            try
            {

                MainClass.con.Open();
                cmd = new SqlCommand("select UnitID from ProductsTable where ProductID = '" + tag + "'", MainClass.con);
                unitId = int.Parse(cmd.ExecuteScalar().ToString());

                cmd = new SqlCommand("select Unit from UnitsTable where UnitID = '" + unitId + "'", MainClass.con);
                unitname = cmd.ExecuteScalar().ToString();
                float qty = 0;

                cmd = new SqlCommand("select StockControl from ProductsTable where ProductID = '" + tag + "'", MainClass.con);
                bool checkstockcontrol = bool.Parse(cmd.ExecuteScalar().ToString());

                if(checkstockcontrol == true)
                {
                    cmd = new SqlCommand("select Qty from Inventory where ProductID = '" + tag + "'", MainClass.con);
                    object ob = cmd.ExecuteScalar();
                    if(ob != null)
                    {
                        if(ob.ToString() == "0")
                        {
                            MessageBox.Show("Not Enough Stocks");
                            MainClass.con.Close();
                            return;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Not Enough Stocks");
                        MainClass.con.Close();
                        return;
                    }
                }



                cmd = new SqlCommand("select ProductID,ProductName,SalePrice from ProductsTable where ProductID = '" + tag + "'", MainClass.con);
                dr = cmd.ExecuteReader();
                dr.Read();
                if(dr.HasRows)
                {
                    if (DGVCartProduct.Rows.Count != 0)
                    {
                        foreach (DataGridViewRow item in DGVCartProduct.Rows)
                        {
                            if (item.Cells["ProductID"].Value.ToString() == dr["ProductID"].ToString())
                            {
                                productcheck = true;
                                break;
                            }
                            else
                            {
                                productcheck = false;
                            }
                        }

                        if (productcheck == true)
                        {
                            foreach (DataGridViewRow item in DGVCartProduct.Rows)
                            {
                                if (item.Cells["ProductID"].Value.ToString() == dr["ProductID"].ToString())
                                {
                                    item.Cells["QTYGV"].Value = float.Parse(item.Cells["QTYGV"].Value.ToString()) + 1;
                                    item.Cells["TotalGV"].Value = float.Parse(dr["SalePrice"].ToString()) * float.Parse(item.Cells["QTYGV"].Value.ToString());
                                }
                            }
                        }
                        else
                        {
                            DGVCartProduct.Rows.Add(DGVCartProduct.Rows.Count + 1, dr["ProductID"].ToString(), dr["ProductName"].ToString(), unitname, float.Parse(dr["SalePrice"].ToString()), ++qty, float.Parse(dr["SalePrice"].ToString()) * qty);
                        }

                    }
                    else
                    {
                        DGVCartProduct.Rows.Add(DGVCartProduct.Rows.Count + 1, dr["ProductID"].ToString(), dr["ProductName"].ToString(), unitname, float.Parse(dr["SalePrice"].ToString()), ++qty, float.Parse(dr["SalePrice"].ToString()) * qty);
                    }
                }
                MainClass.con.Close();
            }
            catch (Exception ex)
            {
                MainClass.con.Close();
                MessageBox.Show(ex.Message);
            }
            txtDiscount.Text = "0";
            CalculateTotal();
        }

        private void GetProductData(string search = null, string catID = null)
        {
            fpFoods.Controls.Clear();
            SqlCommand cmd = null;
            SqlDataReader dr;
            try
            {
                MainClass.con.Open();
                if (search == "" || search == null)
                {
                    if (catID == "" || catID == null)
                    {
                        cmd = new SqlCommand("select Image,ProductID,ProductName,SalePrice from ProductsTable", MainClass.con);
                    }
                    else
                    {
                        cmd = new SqlCommand("select Image,ProductID,ProductName,SalePrice from ProductsTable where CatID = '"+catID+"'", MainClass.con);
                    }
                }
                else
                {
                    cmd = new SqlCommand("select Image,ProductID,ProductName,SalePrice from ProductsTable where ProductName like '%" + search + "%'", MainClass.con);
                }
                dr = cmd.ExecuteReader();
                while(dr.Read())
                {
                    long len = dr.GetBytes(0, 0, null, 0, 0);
                    byte[] array = new byte[Convert.ToInt32(len) + 1];
                    dr.GetBytes(0, 0, array, 0, Convert.ToInt32(len));
                    MemoryStream ms = new MemoryStream(array);
                    Bitmap bitmap = new Bitmap(ms);

                    foodbutton = new Button();
                    foodbutton.Width = 130;
                    foodbutton.Height = 130;
                    foodbutton.Font = new Font("Arial", 10);
                    foodbutton.FlatStyle = FlatStyle.Flat;
                    foodbutton.BackColor = Color.FromArgb(39, 174, 96);
                    foodbutton.BackgroundImageLayout = ImageLayout.Stretch;

                   
                    foodbutton.BackgroundImage = bitmap;

                    foodname = new Label();
                    foodname.Text = dr["ProductName"].ToString();
                    foodname.BackColor = Color.DarkGreen;
                    foodname.TextAlign = ContentAlignment.MiddleCenter;
                    foodname.ForeColor = Color.White;
                    foodname.Dock = DockStyle.Top;


                    foodbutton.ForeColor = Color.White;
                    foodbutton.Tag = dr["ProductID"].ToString();
                    fpFoods.Controls.Add(foodbutton);

                    foodprice = new Label();
                    foodprice.Text = "Rs "+dr["SalePrice"].ToString();
                    foodprice.Width = 100;
                    foodprice.BackColor = Color.DarkGreen;
                    foodprice.TextAlign = ContentAlignment.MiddleCenter;
                    foodprice.ForeColor = Color.White;
                    foodprice.Dock = DockStyle.Bottom;
                    foodprice.Tag = dr["ProductID"].ToString();


                    foodbutton.Controls.Add(foodprice);
                    foodbutton.Controls.Add(foodname);
                    foodbutton.Click += new EventHandler(OnProductButtonClick);
                    foodprice.Click += new EventHandler(OnProductButtonClick);

                }
                dr.Close();
                MainClass.con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                MainClass.con.Close();
                
            }

         
        }

      

        private string CurrencyRetrival()
        {
            string Currency = "";
            try
            {
                MainClass.con.Open();
                SqlCommand cmd = new SqlCommand("select Currency from StoreTable", MainClass.con);
                object curr = cmd.ExecuteScalar();
                if (curr != null)
                {
                    if (curr.ToString() != "")
                    {
                        Currency = curr.ToString();
                    }
                }
                MainClass.con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                MainClass.con.Close();

            }
            return Currency;
        }

        private void CheckTokenDate()
        {
            SqlCommand cmd = null;
            MainClass.con.Open();
            cmd = new SqlCommand("select CAST(StartDate AS DATE) as 'StartDate' from TokenNumber order by ID DESC", MainClass.con);
            DateTime date = DateTime.Parse(cmd.ExecuteScalar().ToString());
            
            string today =  dateTimePicker1.Value.ToShortDateString();
            if (date.ToShortDateString() != today)
            {
                cmd = new SqlCommand("insert into TokenNumber (Number,StartDate) values ('" + 1 + "','" +  dateTimePicker1.Value.ToShortDateString() + "')", MainClass.con);
                cmd.ExecuteNonQuery();
            }
          
            MainClass.con.Close();
        }

        private void RestaurantPOS_Load(object sender, EventArgs e)
        {
            lblLoggedInUser.Text = Login.User_NAME.ToString();
            MainClass.FillProducts(cboProducts);
            cboOrderType.SelectedIndex = 0;
            fpCategory.WrapContents = false;
            GenerateInvoiceNo();
            fpFoods.WrapContents = true;
            CHECKORDERTYPE();
            GetProductData();
            ShowStore();
            GetCategoryData();
            int Number = GenerateTokenNumber();
            CheckTokenDate();
            txtTokenNumber.Text = Number.ToString();
            string currency = CurrencyRetrival();
            lblGrandTotal.Text = "0.00 ";
            lblCurrencyRetriveal.Text = currency;
        }

        public Image ConvertByteArraytoImage(byte[] data)
        {
            using (MemoryStream ms = new MemoryStream(data))
            {
                return Image.FromStream(ms);
            }
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
                lblStoreAddress.Text = dr["StoreAddress"].ToString();
                pictureBox1.Image = ConvertByteArraytoImage((byte[])dr["Logo"]);

            }
            else
            {
                lblStore.Text = "";
                lblStoreAddress.Text = "";
            }

            dr.Close();
            MainClass.con.Close();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            if(lblLoggedInUser.Text == "Admin")
            {
                HomeScreen hs = new HomeScreen();
                hs.lblLoggedUser.Text = "Admin";
                MainClass.showWindow(hs, this, MDI.ActiveForm);
            }
            else
            {
                Login ls = new Login();
                MainClass.showWindow(ls, this, MDI.ActiveForm);
            }
            
        }

        private void CHECKORDERTYPE()
        {
            if (cboOrderType.Text == "Dine In")
            {
                btnTables.Visible = true;
                lblTable.Visible = true;
                txtTableName.Visible = true;
                btnSaveOrder.Enabled = true;
                txtTableSpace.Visible = true;
                btnSaveandPrintOrder.Enabled = false;
            }
            else
            {
                btnTables.Visible = false;
                lblTable.Visible = false;
                txtTableSpace.Visible = false;
                btnSaveOrder.Enabled = false;
                txtTableName.Visible = false;
                btnSaveandPrintOrder.Enabled = true;
                lblDeliveryAddress.Visible = false;
                lblEntername.Visible = false;
                txtDeliveryName.Visible = false;
                txtDeliveryAddress.Visible = false;

            }

            if (cboOrderType.Text == "Credit")
            {
                btnSaveOrder.Text = "SAVE IN &LEDGER";
                lblSelectCustomer.Visible = true;
                btnSaveOrder.Enabled = true;
                btnSaveandPrintOrder.Enabled = false;
                cboSelectCustomer.Visible = true;
                MainClass.FillCustomer(cboSelectCustomer);
                lblSelectCustomer.Text = "Select Customer";
                lblDeliveryAddress.Visible = false;
                lblEntername.Visible = false;
                txtDeliveryName.Visible = false;
                txtDeliveryAddress.Visible = false;


            }
            else if (cboOrderType.Text == "Delivery")
            {
                lblSelectCustomer.Visible = true;
                lblSelectCustomer.Text = "Select Delivery Person";
                lblDeliveryAddress.Visible = true;
                lblEntername.Visible = true;
                txtDeliveryName.Visible = true;
                txtDeliveryAddress.Visible = true;
                cboSelectCustomer.Visible = true;
                MainClass.FillDelivery(cboSelectCustomer);
                btnSaveandPrintOrder.Enabled = true;
                btnSaveOrder.Enabled = false;
                btnSaveOrder.Text = "&SAVE";

            }
            else
            {
                btnSaveOrder.Text = "&SAVE";
                lblSelectCustomer.Visible = false;
                btnSaveandPrintOrder.Enabled = true;
                cboSelectCustomer.Visible = false;
                lblDeliveryAddress.Visible = false;
                lblEntername.Visible = false;
                txtDeliveryName.Visible = false;
                txtDeliveryAddress.Visible = false;
            }
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

        private int GenerateTokenNumber()
        {
            int ID = 0;
            int Number = 0;
            SqlCommand cmd = null;
            try
            {
                MainClass.con.Open();
                cmd = new SqlCommand("select TOP 1 * from TokenNumber ORDER BY ID DESC", MainClass.con);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        ID = int.Parse(dr["ID"].ToString());
                        Number = int.Parse(dr["Number"].ToString());
                    }
                }
                else
                {
                    dr.Close();
                    SqlCommand cmd1 = new SqlCommand("insert into TokenNumber (Number,StartDate) values ('" + 1 + "','" +  dateTimePicker1.Value.ToShortDateString() + "')", MainClass.con);
                    cmd1.ExecuteNonQuery();

                }

                MainClass.con.Close();
                if (tokengeneration == 1)
                {
                    Number++;
                    MainClass.con.Open();
                    cmd = new SqlCommand("update TokenNumber set Number = '" + Number + "' where ID = '" + ID + "' ", MainClass.con);
                    cmd.ExecuteNonQuery();
                    MainClass.con.Close();
                }
                else
                {
                    MainClass.con.Open();
                    cmd = new SqlCommand("select TOP 1 Number from TokenNumber ORDER BY ID DESC", MainClass.con);
                    Number = int.Parse(cmd.ExecuteScalar().ToString());
                    MainClass.con.Close();
                }
            }
            catch (Exception ex)
            {
                MainClass.con.Close();
                MessageBox.Show(ex.Message);
            }
            return Number;
        }
        private void cboOrderType_SelectedIndexChanged(object sender, EventArgs e)
        {
            CHECKORDERTYPE();
        }

        private void btnTables_Click(object sender, EventArgs e)
        {
            Tables newtb = new Tables();
            newtb.Show();
            newtb.TransfEvent += frm_TransfEvent;


        }

        void frm_TransfEvent(string value,string value2)
        {
            txtTableName.Text = value;
            txtTableSpace.Text = value2;
        }



        

        private void btnViewAllProducts_Click(object sender, EventArgs e)
        {
            cboProducts.SelectedIndex = 0;
            GetProductData();
        }

        private void DGVCartProduct_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (DGVCartProduct.SelectedRows.Count == 1)
            {
                if (e.RowIndex != -1 && e.ColumnIndex != -1)
                {
                    if(e.ColumnIndex == 7)  //ADD QTY
                    {
                        
                        DGVCartProduct.CurrentRow.Cells["QTYGV"].Value = float.Parse(DGVCartProduct.CurrentRow.Cells["QTYGV"].Value.ToString()) + 1;
                        DGVCartProduct.CurrentRow.Cells["TotalGV"].Value =  float.Parse(DGVCartProduct.CurrentRow.Cells["PriceGV"].Value.ToString())  * float.Parse(DGVCartProduct.CurrentRow.Cells["QTYGV"].Value.ToString());
                    }
                    if(e.ColumnIndex == 8) //REMOVE QTY
                    {
                        if (int.Parse(DGVCartProduct.CurrentRow.Cells["QTYGV"].Value.ToString()) > 1)
                        {
                            DGVCartProduct.CurrentRow.Cells["QTYGV"].Value = float.Parse(DGVCartProduct.CurrentRow.Cells["QTYGV"].Value.ToString()) - 1;
                            DGVCartProduct.CurrentRow.Cells["TotalGV"].Value = float.Parse(DGVCartProduct.CurrentRow.Cells["PriceGV"].Value.ToString()) * float.Parse(DGVCartProduct.CurrentRow.Cells["QTYGV"].Value.ToString());
                        }
                        else
                        {
                            DGVCartProduct.Rows.RemoveAt(DGVCartProduct.CurrentRow.Index);
                        }
                    }

                    CalculateTotal();
                }
            }
        }

        public static void txtTableName_TextChanged(object sender, EventArgs e)
        {

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

        private void ClearForm()
        {
            DGVCartProduct.Rows.Clear();
            cbGST.Checked = false;
            txtDiscount.Text = "0";
            LedgerSaleID = 0;
            TakeAwaySaleID = 0;
            DINEINID = 0;
            lblGrandTotal.Text = "0.00";
            txtTableName.Text = "";
            lblOrderID.Text = "OrderID";
            btnSaveandPrintOrder.Enabled = true;
            btnSaveOrder.Text = "SAVE";
            cboOrderType.SelectedIndex = 0;
        }

        byte[] ConvertImageToBytes(Image img)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                img.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                return ms.ToArray();
            }
        }

        public static int LedgerSaleID = 0;
        private void btnSaveOrder_Click(object sender, EventArgs e)
        {
            if (cboOrderType.Text == "Credit")
            {
                if (DGVCartProduct.Rows.Count == 0)
                {
                    MessageBox.Show("Enter Products");
                    return;
                }
                if (cboOrderType.Text == "Credit" && cboSelectCustomer.SelectedIndex == 0)
                {
                    MessageBox.Show("Please Select Customer");
                    return;
                }

                SqlCommand cmd = null;
                string invoiceno = "";
                string saletime = "";
                invoiceno = "CRSAL" + txtInvoiceNo.Text;

                try
                {

                    PaymentWindow pm = new PaymentWindow(this);
                    pm.ShowDialog();
                    if (pm.txtPaying.Text != "")
                    {
                        MainClass.con.Open();
                        cmd = new SqlCommand("SELECT CONVERT(varchar(15),  CAST(GETDATE() AS TIME), 100) as SaleTime", MainClass.con);
                        saletime = cmd.ExecuteScalar().ToString();

                        cmd = new SqlCommand("insert into CustomerInvoicesTable (Customer_ID,PaymentType,InvoiceDate,InvoiceNo,TotalAmount,PaidAmount,RemainingBalance) values (@Customer_ID,@PaymentType,@InvoiceDate,@InvoiceNo,@TotalAmount,@PaidAmount,@RemainingBalance)", MainClass.con);
                        cmd.Parameters.AddWithValue("@Customer_ID", cboSelectCustomer.SelectedValue);
                        cmd.Parameters.AddWithValue("@PaymentType", cboOrderType.Text);
                        cmd.Parameters.AddWithValue("@InvoiceDate",  dateTimePicker1.Value.ToShortDateString());
                        cmd.Parameters.AddWithValue("@InvoiceNo", invoiceno);
                        cmd.Parameters.AddWithValue("@TotalAmount", float.Parse(lblGrandTotal.Text));
                        cmd.Parameters.AddWithValue("@PaidAmount", float.Parse(pm.txtPaying.Text));
                        cmd.Parameters.AddWithValue("@RemainingBalance", float.Parse(pm.txtBalance.Text));
                        cmd.ExecuteNonQuery();

                        string CustomerInvoiceID = Convert.ToString(MainClass.Retrieve("select MAX(CustomerInvoiceID) from CustomerInvoicesTable").Rows[0][0]);
                        if (string.IsNullOrEmpty(CustomerInvoiceID))
                        {
                            MessageBox.Show("Please Check The Error or Try Again");
                            return;
                        }


                        cmd = new SqlCommand("insert into CustomerLedgersTable (CustomerInvoice_ID,Customer_ID,InvoiceDate,InvoiceNo,TotalAmount,PaidAmount,Balance) values (@CustomerInvoice_ID,@Customer_ID,@InvoiceDate,@InvoiceNo,@TotalAmount,@PaidAmount,@Balance)", MainClass.con);
                        cmd.Parameters.AddWithValue("@CustomerInvoice_ID", CustomerInvoiceID);
                        cmd.Parameters.AddWithValue("@Customer_ID", cboSelectCustomer.SelectedValue);
                        cmd.Parameters.AddWithValue("@InvoiceDate",  dateTimePicker1.Value.ToShortDateString());
                        cmd.Parameters.AddWithValue("@InvoiceNo", invoiceno);
                        cmd.Parameters.AddWithValue("@TotalAmount", float.Parse(lblGrandTotal.Text));
                        cmd.Parameters.AddWithValue("@PaidAmount", float.Parse(pm.txtPaying.Text));
                        cmd.Parameters.AddWithValue("@Balance", float.Parse(pm.txtBalance.Text));
                        cmd.ExecuteNonQuery();

                        string CustomerLedgerID = Convert.ToString(MainClass.Retrieve("select MAX(CustomerLedgerID) from CustomerLedgersTable").Rows[0][0]);
                        if (string.IsNullOrEmpty(CustomerLedgerID))
                        {
                            MessageBox.Show("Please Check The Error or Try Again");
                            return;
                        }

                        cmd = new SqlCommand("insert into CustomerLedgersInfoTable (CustomerLedger_ID,Customer_ID,PayingDate,InvoiceNo,TotalAmount,PreviousPaid,TodayPaid,NewBalance) values (@CustomerLedger_ID,@Customer_ID,@PayingDate,@InvoiceNo,@TotalAmount,@PreviousPaid,@TodayPaid,@NewBalance)", MainClass.con);
                        cmd.Parameters.AddWithValue("@CustomerLedger_ID", CustomerLedgerID);
                        cmd.Parameters.AddWithValue("@Customer_ID", cboSelectCustomer.SelectedValue);
                        cmd.Parameters.AddWithValue("@PayingDate",  dateTimePicker1.Value.ToShortDateString());
                        cmd.Parameters.AddWithValue("@TotalAmount", float.Parse(lblGrandTotal.Text));
                        cmd.Parameters.AddWithValue("@InvoiceNo", invoiceno);
                        cmd.Parameters.AddWithValue("@PreviousPaid", float.Parse(pm.txtPaying.Text));
                        cmd.Parameters.AddWithValue("@TodayPaid", 0);
                        cmd.Parameters.AddWithValue("@NewBalance", float.Parse(pm.txtBalance.Text));
                        cmd.ExecuteNonQuery();


                        cmd = new SqlCommand("insert into SalesTable (Cashier,Paying,Change,CustomerInvoice_ID, Customer_ID,InvoiceNo,Discount,GrandTotal,OrderType,TableData,SaleDate,SaleTime,OrderStatus,BillGST,TokenNumber,ContactNumber) values (@Cashier,@Paying,@Change,@CustomerInvoice_ID, @Customer_ID,@InvoiceNo,@Discount,@StoreAddress,@OrderType,@TableData,@SaleDate,@SaleTime,@OrderStatus,@BillGST,@TokenNumber,@ContactNumber)", MainClass.con);
                        cmd.Parameters.AddWithValue("@InvoiceNo", invoiceno);
                        cmd.Parameters.AddWithValue("@Discount", float.Parse(txtDiscount.Text));
                        cmd.Parameters.AddWithValue("@GrandTotal", float.Parse(lblGrandTotal.Text));
                        cmd.Parameters.AddWithValue("@TokenNumber", int.Parse(txtTokenNumber.Text));
                        cmd.Parameters.AddWithValue("@Cashier", lblLoggedInUser.Text);
                        cmd.Parameters.AddWithValue("@OrderType", cboOrderType.Text);
                        cmd.Parameters.AddWithValue("@SaleDate",  dateTimePicker1.Value.ToShortDateString());
                        cmd.Parameters.AddWithValue("@Paying", float.Parse(pm.txtPaying.Text));
                        cmd.Parameters.AddWithValue("@Change", float.Parse(pm.txtChange.Text));
                        cmd.Parameters.AddWithValue("@SaleTime", saletime);
                        cmd.Parameters.AddWithValue("@OrderStatus", "In Ledger");
                        cmd.Parameters.AddWithValue("@TableData", DBNull.Value);
                        cmd.Parameters.AddWithValue("@BillGST", billgst);
                        cmd.Parameters.AddWithValue("@CustomerInvoice_ID", CustomerInvoiceID);
                        cmd.Parameters.AddWithValue("@Customer_ID", cboSelectCustomer.SelectedValue.ToString());
                     
                        cmd.Parameters.AddWithValue("@ContactNumber", pm.txtContactNumber.Text);
                        cmd.ExecuteNonQuery();

                        string SaleID = Convert.ToString(MainClass.Retrieve("select MAX(SaleID) from SalesTable").Rows[0][0]);
                        if (string.IsNullOrEmpty(SaleID))
                        {
                            MessageBox.Show("Please Check The Error or Try Again");
                            return;
                        }


                        foreach (DataGridViewRow item in DGVCartProduct.Rows)
                        {
                            int unitID;
                            cmd = new SqlCommand("select UnitID from UnitsTable where Unit = '" + item.Cells["UnitGV"].Value.ToString() + "'", MainClass.con);
                            unitID = int.Parse(cmd.ExecuteScalar().ToString());

                            cmd = new SqlCommand("insert into SalesInfo (Sales_ID,ProductID,Quantity,Unit,SalePrice,TotalOfProduct) values (@Sales_ID,@ProductID,@Quantity,@Unit,@SalePrice,@TotalOfProduct)", MainClass.con);
                            cmd.Parameters.AddWithValue("@Sales_ID", int.Parse(SaleID.ToString()));
                            cmd.Parameters.AddWithValue("@ProductID", item.Cells["ProductID"].Value.ToString());
                            cmd.Parameters.AddWithValue("@Quantity", item.Cells["QTYGV"].Value.ToString());
                            cmd.Parameters.AddWithValue("@Unit", unitID);
                            cmd.Parameters.AddWithValue("@SalePrice", float.Parse(item.Cells["PriceGV"].Value.ToString()));
                            cmd.Parameters.AddWithValue("@TotalOfProduct", float.Parse(item.Cells["TotalGV"].Value.ToString()));
                            cmd.ExecuteNonQuery();
                        }


                        MainClass.con.Close();
                        btnGenerate_Click(sender, e);
                        LedgerSaleID = int.Parse(SaleID);
                        MessageBox.Show("Sale Saved");
                        BillForm bill = new BillForm();
                        bill.Show();
                        ClearForm();
                    }
                    else
                    {
                        return;
                    }

                }
                catch (Exception ex)
                {
                    MainClass.con.Close();
                    MessageBox.Show(ex.Message);
                }

            } //Credit 
            else
            {
                SqlCommand cmd2 = null;
                string saletime2;
                if (btnSaveOrder.Text == "UPDATE")
                {
                    MainClass.con.Open();
                    try
                    {
                        cmd2 = new SqlCommand("SELECT CONVERT(varchar(15),  CAST(GETDATE() AS TIME), 100) as SaleTime", MainClass.con);
                        saletime2 = cmd2.ExecuteScalar().ToString();

                        cmd2 = new SqlCommand("update SalesTable set Discount = @Discount, GrandTotal = @GrandTotal, SaleDate =@SaleDate, SaleTime = @SaleTime where SaleID = '" + lblOrderID.Text + "' ", MainClass.con);
                        cmd2.Parameters.AddWithValue("@Discount", float.Parse(txtDiscount.Text));
                        cmd2.Parameters.AddWithValue("@GrandTotal", float.Parse(lblGrandTotal.Text));
                        cmd2.Parameters.AddWithValue("@SaleDate",  dateTimePicker1.Value.ToShortDateString());
                        cmd2.Parameters.AddWithValue("@SaleTime", saletime2);
                        cmd2.ExecuteNonQuery();

                        cmd2 = new SqlCommand("delete from SalesInfo where Sales_ID = '" + lblOrderID.Text + "'", MainClass.con);
                        cmd2.ExecuteNonQuery();


                        foreach (DataGridViewRow item in DGVCartProduct.Rows)
                        {
                            int unitID;
                            cmd2 = new SqlCommand("select UnitID from UnitsTable where Unit = '" + item.Cells["UnitGV"].Value.ToString() + "'", MainClass.con);
                            unitID = int.Parse(cmd2.ExecuteScalar().ToString());

                            
                            cmd2 = new SqlCommand("insert into SalesInfo (Sales_ID,ProductID,Quantity,Unit,SalePrice,TotalOfProduct) values (@Sales_ID,@ProductID,@Quantity,@Unit,@SalePrice,@TotalOfProduct)", MainClass.con);
                            cmd2.Parameters.AddWithValue("@Sales_ID", int.Parse(lblOrderID.Text.ToString()));
                            cmd2.Parameters.AddWithValue("@ProductID", item.Cells["ProductID"].Value.ToString());
                            cmd2.Parameters.AddWithValue("@Quantity", item.Cells["QTYGV"].Value.ToString());
                            cmd2.Parameters.AddWithValue("@Unit", unitID);
                            cmd2.Parameters.AddWithValue("@SalePrice", float.Parse(item.Cells["PriceGV"].Value.ToString()));
                            cmd2.Parameters.AddWithValue("@TotalOfProduct", float.Parse(item.Cells["TotalGV"].Value.ToString()));
                            cmd2.ExecuteNonQuery();
                        }


                    }
                    catch (Exception ex)
                    {
                        MainClass.con.Close();
                        MessageBox.Show(ex.Message);
                    }

                    MessageBox.Show("Sale Updated");
                    MainClass.con.Close();
                    ClearForm();

                }
                else
                {

                    if (DGVCartProduct.Rows.Count == 0)
                    {
                        MessageBox.Show("Enter Products");
                        return;
                    }
                    if (cboOrderType.Text == "Dine In" && txtTableName.Text == "")
                    {
                        MessageBox.Show("Please Select Tables");
                        return;
                    }
                    SqlCommand cmd = null;
                    string invoiceno = "";
                    string saletime = "";
                    invoiceno = "DSALE" + txtInvoiceNo.Text;

                    try
                    {
                        MainClass.con.Open();
                        cmd = new SqlCommand("SELECT CONVERT(varchar(15),  CAST(GETDATE() AS TIME), 100) as SaleTime", MainClass.con);
                        saletime = cmd.ExecuteScalar().ToString();


                        cmd = new SqlCommand("insert into SalesTable (Cashier,InvoiceNo,Discount,GrandTotal,OrderType,TableData,SaleDate,SaleTime,OrderStatus,BillGST,TokenNumber) values (@Cashier,@InvoiceNo,@Discount,@GrandTotal,@OrderType,@TableData,@SaleDate,@SaleTime,@OrderStatus,@BillGST,@TokenNumber)", MainClass.con);
                        cmd.Parameters.AddWithValue("@InvoiceNo", invoiceno);
                        cmd.Parameters.AddWithValue("@Discount", float.Parse(txtDiscount.Text));
                        cmd.Parameters.AddWithValue("@GrandTotal", float.Parse(lblGrandTotal.Text));
                        cmd.Parameters.AddWithValue("@TokenNumber", int.Parse(txtTokenNumber.Text));
                        cmd.Parameters.AddWithValue("@Cashier", lblLoggedInUser.Text);

                        cmd.Parameters.AddWithValue("@OrderType", cboOrderType.Text);
                        cmd.Parameters.AddWithValue("@SaleDate",  dateTimePicker1.Value.ToShortDateString());
                        cmd.Parameters.AddWithValue("@SaleTime", saletime);

                        cmd.Parameters.AddWithValue("@BillGST", billgst);
                        cmd.Parameters.AddWithValue("@OrderStatus", "Pending");
                        if (cboOrderType.Text == "Dine In")
                        {
                            cmd.Parameters.AddWithValue("@TableData", txtTableName.Text);
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue("@TableData", DBNull.Value);
                        }
                        cmd.ExecuteNonQuery();

                        cmd = new SqlCommand("update Tables set Availability = 0 where TableName = '" + txtTableName.Text + "'", MainClass.con);
                        cmd.ExecuteNonQuery();

                        string SaleID = Convert.ToString(MainClass.Retrieve("select MAX(SaleID) from SalesTable").Rows[0][0]);
                        if (string.IsNullOrEmpty(SaleID))
                        {
                            MessageBox.Show("Please Check The Error or Try Again");
                            return;
                        }


                        foreach (DataGridViewRow item in DGVCartProduct.Rows)
                        {
                            int unitID;
                            cmd = new SqlCommand("select UnitID from UnitsTable where Unit = '" + item.Cells["UnitGV"].Value.ToString() + "'", MainClass.con);
                            unitID = int.Parse(cmd.ExecuteScalar().ToString());

                            cmd = new SqlCommand("insert into SalesInfo (Sales_ID,ProductID,Quantity,Unit,SalePrice,TotalOfProduct) values (@Sales_ID,@ProductID,@Quantity,@Unit,@SalePrice,@TotalOfProduct)", MainClass.con);
                            cmd.Parameters.AddWithValue("@Sales_ID", int.Parse(SaleID.ToString()));
                            cmd.Parameters.AddWithValue("@ProductID", item.Cells["ProductID"].Value.ToString());
                            cmd.Parameters.AddWithValue("@Quantity", item.Cells["QTYGV"].Value.ToString());
                            cmd.Parameters.AddWithValue("@Unit", unitID);
                            cmd.Parameters.AddWithValue("@SalePrice", float.Parse(item.Cells["PriceGV"].Value.ToString()));
                            cmd.Parameters.AddWithValue("@TotalOfProduct", float.Parse(item.Cells["TotalGV"].Value.ToString()));
                            cmd.ExecuteNonQuery();
                        }


                        MainClass.con.Close();
                        btnGenerate_Click(sender, e);
                        TOKENID = GenerateTokenNumber();
                        MessageBox.Show("Sale Saved");

                     


                        TokenForm bf = new TokenForm();
                        bf.Show();
                        tokengeneration = 1;
                        TOKENID = GenerateTokenNumber();
                        tokengeneration = 0;
                        int toke = GenerateTokenNumber();
                        txtTokenNumber.Text = toke.ToString();
                        ClearForm();


                    }
                    catch (Exception ex)
                    {
                        MainClass.con.Close();
                        MessageBox.Show(ex.Message);
                    }
                } //SAVE ORDER




            } //DINE IN
        }

        public static int TOKENID = 0;
        private void txtDiscount_TextChanged(object sender, EventArgs e)
        {
            if (txtDiscount.Text != "" && txtDiscount.Text != "0")
            {
                float gd = 0;
                foreach (DataGridViewRow item in DGVCartProduct.Rows)
                {
                    gd += float.Parse(item.Cells["TotalGV"].Value.ToString());
                }
                float disc = float.Parse(txtDiscount.Text.ToString());
                float tot;
                tot = gd - disc;
                lblGrandTotal.Text = tot.ToString();
            }
            else
            {
                float gd = 0;
                foreach (DataGridViewRow item in DGVCartProduct.Rows)
                {
                    gd += float.Parse(item.Cells["TotalGV"].Value.ToString());
                }
                lblGrandTotal.Text = Convert.ToString(gd);
            }
        }

        public static int TakeAwaySaleID = 0;
        public static int DeliverySaleID = 0;


        private void btnSaveandPrintOrder_Click(object sender, EventArgs e)
        {
            if (DGVCartProduct.Rows.Count == 0)
            {
                MessageBox.Show("Enter Products");
                return;
            }
            if (cboOrderType.Text == "Dine In" && txtTableName.Text == "")
            {
                MessageBox.Show("Please Select Tables");
                return;
            }

            SqlCommand cmd = null;
            string invoiceno = "";
            string saletime = "";
            if(cboOrderType.Text == "Delivery")
            {
                invoiceno = "DSALE" + txtInvoiceNo.Text;
            }
            else
            {
                invoiceno = "TSALE" + txtInvoiceNo.Text;
            }

            try
            {
                MainClass.con.Open();
                cmd = new SqlCommand("SELECT CONVERT(varchar(15),  CAST(GETDATE() AS TIME), 100) as SaleTime", MainClass.con);
                saletime = cmd.ExecuteScalar().ToString();
                MainClass.con.Close();

                if (cboOrderType.Text == "Delivery")
                {
                    MainClass.con.Open();
                    cmd = new SqlCommand("insert into SalesTable (Cashier,InvoiceNo,Discount,GrandTotal,OrderType,TableData,SaleDate,SaleTime,OrderStatus,BillGST,DeliveryName,DeliveryAddress,Paying,Change) values (@Cashier,@InvoiceNo,@Discount,@GrandTotal,@OrderType,@TableData,@SaleDate,@SaleTime,@OrderStatus,@BillGST,@DeliveryName,@DeliveryAddress,@Paying,@Change)", MainClass.con);
                    cmd.Parameters.AddWithValue("@InvoiceNo", invoiceno);
                    cmd.Parameters.AddWithValue("@Discount", float.Parse(txtDiscount.Text));
                    cmd.Parameters.AddWithValue("@GrandTotal", float.Parse(lblGrandTotal.Text));
                    cmd.Parameters.AddWithValue("@OrderType", cboOrderType.Text);
                    cmd.Parameters.AddWithValue("@SaleDate", dateTimePicker1.Value.ToShortDateString());
                    cmd.Parameters.AddWithValue("@SaleTime", saletime);
                    cmd.Parameters.AddWithValue("@OrderStatus", "Completed");
                    cmd.Parameters.AddWithValue("@Cashier", lblLoggedInUser.Text);

                    cmd.Parameters.AddWithValue("@TableData", DBNull.Value);
                    cmd.Parameters.AddWithValue("@BillGST", billgst);
                    cmd.Parameters.AddWithValue("@DeliveryName", txtDeliveryName.Text);
                    cmd.Parameters.AddWithValue("@DeliveryAddress", txtDeliveryAddress.Text);
                    cmd.Parameters.AddWithValue("@Change", 0);
                    cmd.Parameters.AddWithValue("@Paying", float.Parse(lblGrandTotal.Text));
                    cmd.ExecuteNonQuery();
                    MainClass.con.Close();
                }
                else
                {
                    MainClass.con.Open();
                    PaymentWindow pm = new PaymentWindow(this);
                    pm.ShowDialog();
                    if (pm.txtPaying.Text != "" && pm.txtPaying.Text != "0")
                    {
                        cmd = new SqlCommand("insert into SalesTable (Cashier,Paying,Change,InvoiceNo,Discount,GrandTotal,OrderType,TableData,SaleDate,SaleTime,OrderStatus,BillGST,TokenNumber,PaymentMethod,ContactNumber) values (@Cashier,@Paying,@Change,@InvoiceNo,@Discount,@GrandTotal,@OrderType,@TableData,@SaleDate,@SaleTime,@OrderStatus,@BillGST,@TokenNumber,@PaymentMethod,@ContactNumber)", MainClass.con);
                        cmd.Parameters.AddWithValue("@InvoiceNo", invoiceno);
                        cmd.Parameters.AddWithValue("@Discount", float.Parse(txtDiscount.Text));
                        cmd.Parameters.AddWithValue("@PaymentMethod", pm.cboPaymentMethod.Text);
                        cmd.Parameters.AddWithValue("@Cashier", lblLoggedInUser.Text);


                        cmd.Parameters.AddWithValue("@Paying", float.Parse(pm.txtPaying.Text));
                        cmd.Parameters.AddWithValue("@Change", float.Parse(pm.txtChange.Text));
                        cmd.Parameters.AddWithValue("@TokenNumber", int.Parse(txtTokenNumber.Text));
                        cmd.Parameters.AddWithValue("@GrandTotal", float.Parse(lblGrandTotal.Text));
                        cmd.Parameters.AddWithValue("@OrderType", cboOrderType.Text);
                        cmd.Parameters.AddWithValue("@SaleDate",  dateTimePicker1.Value.ToShortDateString());
                        cmd.Parameters.AddWithValue("@SaleTime", saletime);
                        cmd.Parameters.AddWithValue("@OrderStatus", "Completed");
                        cmd.Parameters.AddWithValue("@TableData", DBNull.Value);
                        cmd.Parameters.AddWithValue("@BillGST", billgst);
                        cmd.Parameters.AddWithValue("@ContactNumber", pm.txtContactNumber.Text);
                        cmd.ExecuteNonQuery();

                    }
                    else
                    {
                        MainClass.con.Close();
                        return;
                    }
                }


                string SaleID = Convert.ToString(MainClass.Retrieve("select MAX(SaleID) from SalesTable").Rows[0][0]);
                if (string.IsNullOrEmpty(SaleID))
                {
                    MessageBox.Show("Please Check The Error or Try Again");
                    return;
                }


                foreach (DataGridViewRow item in DGVCartProduct.Rows)
                {
                    int unitID;
                    cmd = new SqlCommand("select UnitID from UnitsTable where Unit = '" + item.Cells["UnitGV"].Value.ToString() + "'", MainClass.con);
                    unitID = int.Parse(cmd.ExecuteScalar().ToString());

                    cmd = new SqlCommand("insert into SalesInfo (Sales_ID,ProductID,Quantity,Unit,SalePrice,TotalOfProduct) values (@Sales_ID,@ProductID,@Quantity,@Unit,@SalePrice,@TotalOfProduct)", MainClass.con);
                    cmd.Parameters.AddWithValue("@Sales_ID", int.Parse(SaleID.ToString()));
                    cmd.Parameters.AddWithValue("@ProductID", item.Cells["ProductID"].Value.ToString());
                    cmd.Parameters.AddWithValue("@Quantity", item.Cells["QTYGV"].Value.ToString());
                    cmd.Parameters.AddWithValue("@Unit", unitID);
                    cmd.Parameters.AddWithValue("@SalePrice", float.Parse(item.Cells["PriceGV"].Value.ToString()));
                    cmd.Parameters.AddWithValue("@TotalOfProduct", float.Parse(item.Cells["TotalGV"].Value.ToString()));
                    cmd.ExecuteNonQuery();
                }

                if (cboOrderType.Text == "Take Away")
                {
                    TakeAwaySaleID = int.Parse(SaleID);
                }
                else
                {
                    DeliverySaleID = int.Parse(SaleID);
                }


                MainClass.con.Close();
                btnGenerate_Click(sender, e);
             

                MessageBox.Show("Sale Finalized");




                //RECEIPT GENERATE
                TOKENID = GenerateTokenNumber();
                TokenForm bf = new TokenForm();
                bf.Show();

                tokengeneration = 1;
                TOKENID = GenerateTokenNumber();

                tokengeneration = 0;
                int toke = GenerateTokenNumber();
                txtTokenNumber.Text = toke.ToString();
               
                ClearForm();
                //


            }
            catch (Exception ex)
            {
                MainClass.con.Close();
                MessageBox.Show(ex.Message);
            }

        }

        public static int DINEINID = 0;
        private void btnPaymentOrder_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = null;
            if (DGVCartProduct.Rows.Count == 0)
            {
                MessageBox.Show("Enter Products");
                return;
            }

            if (cboOrderType.Text == "Dine In" && txtTableName.Text == "")
            {
                MessageBox.Show("Please Select Tables");
                return;
            }

            if (lblGrandTotal.Text != "0.00" && lblOrderID.Text != "OrderID")
            {
                PaymentWindow pm = new PaymentWindow(this);
                pm.ShowDialog();
                pm.txtGrandTotal.Text = lblGrandTotal.Text;
                if (pm.txtPaying.Text != "" && pm.txtPaying.Text != "0")
                {
                    MainClass.con.Open();
                    cmd = new SqlCommand("update SalesTable set OrderStatus = @OrderStatus,ContactNumber=@ContactNumber,Paying=@Paying,Change=@Change,PaymentMethod=@PaymentMethod where SaleID = '" + lblOrderID.Text + "' ", MainClass.con);
                    cmd.Parameters.AddWithValue("@OrderStatus", "Completed");
                    cmd.Parameters.AddWithValue("@Paying", float.Parse(pm.txtPaying.Text));
                    cmd.Parameters.AddWithValue("@Change", float.Parse(pm.txtChange.Text));
                    cmd.Parameters.AddWithValue("@PaymentMethod", pm.cboPaymentMethod.Text);
                    cmd.Parameters.AddWithValue("@ContactNumber", pm.txtContactNumber.Text);
                    cmd.ExecuteNonQuery();

                    cmd = new SqlCommand("update Tables set Availability = 1 where TableName = '" + txtTableName.Text + "'", MainClass.con);
                    cmd.ExecuteNonQuery();
                    DINEINID = int.Parse(lblOrderID.Text);
                    MessageBox.Show("Sale Finalized");
                    MainClass.con.Close();

                    //RECEIPT GENERATE

                    BillForm bf = new BillForm();
                    bf.Show();
                    ClearForm();
                    GenerateInvoiceNo();
                }
                else
                {
                    return;
                }
                //


            }
        }

        private void btnViewOrders_Click(object sender, EventArgs e)
        {
            ViewAllOrders vs = new ViewAllOrders(this);
            vs.ShowDialog();
        }

        private void btnClearForm_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void lblOrderID_TextChanged(object sender, EventArgs e)
        {

            if (lblOrderID.Text != "OrderID")
            {
                SqlCommand cmd = null;
                try
                {
                    MainClass.con.Open();

                    string command = "select p.ProductID, p.ProductName,u.Unit,si.SalePrice,si.Quantity,si.TotalOfProduct from SalesInfo si inner join ProductsTable p on p.ProductID = si.ProductID inner join UnitsTable u on u.UnitID = si.Unit where si.Sales_ID = '" + lblOrderID.Text + "' ";
                    cmd = new SqlCommand(command, MainClass.con);
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        DataGridViewRow createrow = new DataGridViewRow();
                        createrow.CreateCells(DGVCartProduct);
                        createrow.Cells[0].Value = DGVCartProduct.Rows.Count + 1;
                        createrow.Cells[1].Value = dr[0].ToString();
                        createrow.Cells[2].Value = dr[1].ToString();
                        createrow.Cells[3].Value = dr[2].ToString();
                        createrow.Cells[4].Value = dr[3].ToString();
                        createrow.Cells[5].Value = dr[4].ToString();
                        createrow.Cells[6].Value = dr[5].ToString();

                        DGVCartProduct.Rows.Add(createrow);

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

        public static float billgst = 0;
        private void cbGST_CheckedChanged(object sender, EventArgs e)
        {
            if (DGVCartProduct.Rows.Count != 0)
            {

                SqlCommand cmd = null;
                if (cbGST.Checked)
                {
                    MainClass.con.Open();
                    cmd = new SqlCommand("select GST from StoreTable", MainClass.con);
                    object GST = cmd.ExecuteScalar();
                    if (GST != null)
                    {
                        GST = float.Parse(GST.ToString()) / 100;

                        float finalTotal = float.Parse(lblGrandTotal.Text) * float.Parse(GST.ToString());
                        billgst = finalTotal;
                        float total = float.Parse(lblGrandTotal.Text);
                        total += finalTotal;

                        lblGrandTotal.Text = Math.Round(total, 0).ToString();

                    }
                    else
                    {
                        float finalTotal = float.Parse(lblGrandTotal.Text) * 1;
                        lblGrandTotal.Text = finalTotal.ToString();
                    }


                    MainClass.con.Close();
                }
                else
                {
                    float gd = 0;
                    foreach (DataGridViewRow item in DGVCartProduct.Rows)
                    {
                        gd += float.Parse(item.Cells["TotalGV"].Value.ToString());
                    }
                    lblGrandTotal.Text = Convert.ToString(gd);
                }
            }
        }

        private void btnRecentSales_Click(object sender, EventArgs e)
        {
            RecentSales sales = new RecentSales();
            sales.Show();
        }

        private void cboProducts_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetProductData(cboProducts.Text);

        }
    }
}
