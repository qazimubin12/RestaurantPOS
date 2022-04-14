using Guna.UI2.WinForms;
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
    public partial class PurchaseReturn : Form
    {
        public PurchaseReturn()
        {
            InitializeComponent();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            HomeScreen hs = new HomeScreen();
            MainClass.showWindow(hs, this, MDI.ActiveForm);
        }

        private void StocksReturn_Load(object sender, EventArgs e)
        {
            button3.Location = new Point(1239, 0);
            MainClass.FillSupplier(cboSupplier);
        }

        private void FillUnitComboBox(ComboBox cmb)
        {
            try
            {
                DataTable dtUnits = new DataTable();
                dtUnits.Columns.Add("UnitID");
                dtUnits.Columns.Add("Unit");

                DataTable dt = MainClass.Retrieve("select p.UnitID ,u.Unit from UnitsTable u inner join ProductsTable p on p.UnitID = u.UnitID  where p.ProductName = '" + cboProducts.Text + "'");
                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        foreach (DataRow units in dt.Rows)
                        {
                            dtUnits.Rows.Add(units["UnitID"], units["Unit"]);
                        }
                    }
                }
                cmb.DataSource = dtUnits;
                cmb.DisplayMember = "Unit";
                cmb.ValueMember = "UnitID";

            }
            catch (Exception ex)
            {
                MainClass.con.Close();
                MessageBox.Show(ex.Message);
            }
        }

        private void FillInvoiceNoComboBox(ComboBox cmb)
        {
            try
            {
                DataTable dtinvoice = new DataTable();
                dtinvoice.Columns.Add("InvoiceNo");

                DataTable dt = MainClass.Retrieve("select InvoiceNo from PurchasesTable where Supplier_ID =  '" + cboSupplier.SelectedValue.ToString() + "' except select InvoiceNo from StockReturnTable where SupplierID = '" + cboSupplier.SelectedValue.ToString() + "' ");
                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        foreach (DataRow invoice in dt.Rows)
                        {
                            dtinvoice.Rows.Add(invoice["InvoiceNo"]);
                        }
                    }
                }
                cmb.DisplayMember = "InvoiceNo";
                cmb.DataSource = dtinvoice;

            }
            catch (Exception ex)
            {
                MainClass.con.Close();
                MessageBox.Show(ex.Message);
            }
        }

        private void FillProductComboBox(ComboBox cmb)
        {
            try
            {
                DataTable dtproducts = new DataTable();
                dtproducts.Columns.Add("Product_ID");
                dtproducts.Columns.Add("ProductName");

                DataTable dt = MainClass.Retrieve("selecT si.Product_ID,p.ProductName from PurchasesInfo si inner join PurchasesTable st on st.PurchaseID = si.Purchase_ID inner join ProductsTable p on p.ProductID = si.Product_ID where st.InvoiceNo =  '" + cboInvoiceNo.Text + "'");
                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        foreach (DataRow products in dt.Rows)
                        {
                            dtproducts.Rows.Add(products["Product_ID"], products["ProductName"]);
                        }
                    }
                }
                cmb.DisplayMember = "ProductName";
                cmb.ValueMember = "Product_ID";
                cmb.DataSource = dtproducts;

            }
            catch (Exception ex)
            {
                MainClass.con.Close();
                MessageBox.Show(ex.Message);
            }
        }
        private void GetQuantity()
        {
            if (cboInvoiceNo.Text == "")
            {

            }
            else
            {
                try
                {
                    MainClass.con.Open();
                    SqlCommand cmd = new SqlCommand("select si.Quantity  from PurchasesInfo si inner join PurchasesTable st on st.PurchaseID = si.Purchase_ID  where st.InvoiceNo = '" + cboInvoiceNo.Text + "'", MainClass.con);
                    lblBoughtQty.Text = Convert.ToString(float.Parse(cmd.ExecuteScalar().ToString()));
                }
                catch (Exception ex)
                {
                    MainClass.con.Close();
                    MessageBox.Show(ex.Message);
                }
            }
        }




        private void cboProducts_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboProducts.Text == "")
            {
                cboUnit.Text = "";
                return;
            }
            GetQuantity();
            FillUnitComboBox(cboUnit);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (cboInvoiceNo.Text != "")
            {
                bool productalready = false;

                if (txtQuantity.Text == "")
                {
                    MessageBox.Show("Please Enter Quantity", "Input Fields", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (txtReturnRate.Text == "")
                {
                    MessageBox.Show("Please Input Rate", "Input Fields", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (float.Parse(txtQuantity.Text) > float.Parse(lblBoughtQty.Text))
                {

                    MessageBox.Show("Bought Quantity is less than returning Quantity", "Input Fields", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                else
                {
                    float qty = float.Parse(txtQuantity.Text);
                    float rate = float.Parse(txtReturnRate.Text);
                    float producttotal = qty * rate;
                    if (DGVStockReturn.Rows.Count == 0)
                    {
                        DataGridViewRow createrow = new DataGridViewRow();
                        createrow.CreateCells(DGVStockReturn);
                        createrow.Cells[0].Value = cboProducts.SelectedValue.ToString();
                        createrow.Cells[1].Value = cboProducts.Text.ToString();
                        createrow.Cells[2].Value = cboUnit.Text.ToString();
                        createrow.Cells[3].Value = txtQuantity.Text.ToString();
                        createrow.Cells[4].Value = txtReturnRate.Text.ToString();
                        createrow.Cells[5].Value = producttotal.ToString();
                        DGVStockReturn.Rows.Add(createrow);
                    }
                    else
                    {
                        foreach (DataGridViewRow check in DGVStockReturn.Rows)
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
                            foreach (DataGridViewRow row in DGVStockReturn.Rows)
                            {
                                if (Convert.ToString(row.Cells[0].Value) == Convert.ToString(cboProducts.SelectedValue))
                                {
                                    row.Cells[3].Value = float.Parse(row.Cells[3].Value.ToString()) + qty;
                                    row.Cells[5].Value = float.Parse(row.Cells[5].Value.ToString()) * float.Parse(row.Cells[3].Value.ToString());
                                }
                            }
                        }

                        else
                        {
                            if (productalready == false)
                            {
                                DataGridViewRow createrow = new DataGridViewRow();
                                createrow.CreateCells(DGVStockReturn);
                                createrow.Cells[0].Value = cboProducts.SelectedValue.ToString();
                                createrow.Cells[1].Value = cboProducts.Text.ToString();
                                createrow.Cells[2].Value = cboUnit.Text.ToString();
                                createrow.Cells[3].Value = txtQuantity.Text.ToString();
                                createrow.Cells[4].Value = txtReturnRate.Text.ToString();
                                createrow.Cells[5].Value = producttotal.ToString();
                                DGVStockReturn.Rows.Add(createrow);
                            }
                        }
                    }

                }
                CalculateTotal();
                MinorClear();

            }
        }

        private void MinorClear()
        {
            txtQuantity.Text = "";
            txtReturnRate.Text = "";
            cboProducts.Focus();
        }

        private void CalculateTotal()
        {
            float gross = 0;
            if (DGVStockReturn.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in DGVStockReturn.Rows)
                {
                    gross += float.Parse(row.Cells["ProductTotalGV"].Value.ToString());
                }
                txtGrossTotal.Text = Convert.ToString(gross);
            }
        }
        private void cboCustomer_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboSupplier.SelectedIndex == 0)
            {
                cboInvoiceNo.Text = "";
                return;
            }
            FillInvoiceNoComboBox(cboInvoiceNo);
        }

        private void cboUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboUnit.Text != "")
            {
                SqlCommand cmd = new SqlCommand("select si.CostPrice from PurchasesInfo si inner join PurchasesTable st on st.PurchaseID = si.Purchase_ID where si.Product_ID = '" + cboProducts.SelectedValue.ToString() + "' and st.InvoiceNo = '" + cboInvoiceNo.Text + "'", MainClass.con);
                float costprice = float.Parse(cmd.ExecuteScalar().ToString());
                txtReturnRate.Text = costprice.ToString();
            }
            else
            {
                txtReturnRate.Text = "";
            }
        }

        private void cboInvoiceNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboInvoiceNo.Text == "")
            {
                cboProducts.Text = "";
                return;
            }
            FillProductComboBox(cboProducts);
        }


        private void FullClear()
        {
            foreach (Control item in panel2.Controls)
            {
                if (item is Guna2TextBox)
                {
                    ((Guna2TextBox)item).Text = String.Empty;
                }
                if (item is ComboBox)
                {
                    ((ComboBox)item).SelectedIndex = 0;
                }
                if (item is DateTimePicker)
                {
                    ((DateTimePicker)item).Value = DateTime.Now;
                }
                if (item is Guna2ToggleSwitch)
                {
                    ((Guna2ToggleSwitch)item).Checked = false;
                }
            }

            foreach (Control item in GBProductDetails.Controls)
            {
                if (item is Guna2TextBox)
                {
                    ((Guna2TextBox)item).Text = String.Empty;
                }
                if (item is ComboBox)
                {
                    ((ComboBox)item).Text = "";
                }
                if (item is DateTimePicker)
                {
                    ((DateTimePicker)item).Value = DateTime.Now;
                }
                if (item is Guna2ToggleSwitch)
                {
                    ((Guna2ToggleSwitch)item).Checked = false;
                }
            }


            cboProducts.SelectedIndex = 0;
            txtGrossTotal.Text = "";
            DGVStockReturn.Rows.Clear();

        }

        private float CashInHand()
        {

            float cash = 0;
            try
            {
                SqlCommand cmd = new SqlCommand("select CashInHand from StoreTable ", MainClass.con);
                cash = float.Parse(cmd.ExecuteScalar().ToString());
            }
            catch (Exception ex)
            {
                MainClass.con.Close();
                MessageBox.Show(ex.Message);
            }
            return cash;
        }

        private void DGVStockReturn_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1 && e.ColumnIndex != -1)
            {
                if (e.ColumnIndex == 6)
                {
                    DGVStockReturn.Rows.RemoveAt(DGVStockReturn.CurrentRow.Index);
                }
            }
            CalculateTotal();

            if (DGVStockReturn.Rows.Count == 0)
            {
                FullClear();
            }
        }

        private void btnFinalize_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = null;
            int unitID = 0;
            object stockqty = null;
            if (DGVStockReturn.Rows.Count > 0)
            {

                try
                {
                    cmd = new SqlCommand("select Balance from SupplierLedgersTable where InvoiceNo = '" + cboInvoiceNo.Text + "'", MainClass.con);
                    object suppliercheckinLedgers = cmd.ExecuteScalar();

                    cmd = new SqlCommand("select SupplerLedgerID from SupplierLedgersTable where InvoiceNo = '" + cboInvoiceNo.Text + "'", MainClass.con);
                    object SupplierLedgerID = cmd.ExecuteScalar();


                    foreach (DataGridViewRow item in DGVStockReturn.Rows)
                    {
                        try
                        {
                            cmd = new SqlCommand("select UnitID from UnitsTable where Unit = '" + item.Cells[2].Value.ToString() + "'", MainClass.con);
                            unitID = int.Parse(cmd.ExecuteScalar().ToString());
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                            MainClass.con.Close();
                        } // UnitID
                        try
                        {
                            cmd = new SqlCommand("insert into StockReturnTable (SupplierID,ProductID,UnitID,Rate,Quantity,GrandTotal,ReturnDate,InvoiceNo,Remarks) values (@SupplierID,@ProductID,@UnitID,@Rate,@Quantity,@GrandTotal,@ReturnDate,@InvoiceNo,@Remarks)", MainClass.con);
                            cmd.Parameters.AddWithValue("@SupplierID", cboSupplier.SelectedValue.ToString());
                            cmd.Parameters.AddWithValue("@ProductID", item.Cells["ProductIDGV"].Value.ToString());
                            cmd.Parameters.AddWithValue("@UnitID", unitID);
                            cmd.Parameters.AddWithValue("@Rate", item.Cells["RateGV"].Value.ToString());
                            cmd.Parameters.AddWithValue("@Quantity", float.Parse(item.Cells["QuantityGV"].Value.ToString()));
                            cmd.Parameters.AddWithValue("@GrandTotal", float.Parse(txtGrossTotal.Text));
                            cmd.Parameters.AddWithValue("@ReturnDate", DateTime.Now.ToShortDateString());
                            cmd.Parameters.AddWithValue("@InvoiceNo", cboInvoiceNo.Text);
                            cmd.Parameters.AddWithValue("@Remarks", txtRemarks.Text);
                            cmd.ExecuteNonQuery();

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                            MainClass.con.Close();
                        } //Inserting Stocks Return Details
                        try
                        {
                            cmd = new SqlCommand("select Qty from Inventory where ProductID = '" + item.Cells[0].Value.ToString() + "'", MainClass.con);
                            stockqty = cmd.ExecuteScalar();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                            MainClass.con.Close();
                        } //stockqty finding
                        try
                        {

                            float qty = 0;
                            float.TryParse(stockqty.ToString(), out qty);
                            qty -= float.Parse(item.Cells[3].Value.ToString());
                            MainClass.UpdateInventory(int.Parse(item.Cells[0].Value.ToString()), qty);

                            //Updating Inventory
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                            MainClass.con.Close();
                        }//Inventory
                        try
                        {
                            cmd = new SqlCommand("select PaymentType from SupplierInvoicesTable where InvoiceNo = '" + cboInvoiceNo.Text + "'", MainClass.con);
                            object ob = cmd.ExecuteScalar();

                            if (ob.ToString() == "Credit")
                            {

                                cmd = new SqlCommand("select Balance from SupplierLedgersTable where InvoiceNo = '" + cboInvoiceNo.Text + "'", MainClass.con);
                                float previousbalance = float.Parse(cmd.ExecuteScalar().ToString());

                                cmd = new SqlCommand("selecT RemainingBalance from SupplierInvoicesTable where InvoiceNo = '" + cboInvoiceNo.Text + "'", MainClass.con);
                                float invoicepreviousbalance = float.Parse(cmd.ExecuteScalar().ToString());


                                float newbalance = previousbalance - float.Parse(txtGrossTotal.Text);
                                cmd = new SqlCommand("update SupplierLedgersTable set Balance = @Balance, Remarks = @Remarks where InvoiceNo = '" + cboInvoiceNo.Text + "' and Customer_ID = '" + cboSupplier.SelectedValue.ToString() + "'", MainClass.con);
                                cmd.Parameters.AddWithValue("@Balance", newbalance);
                                cmd.Parameters.AddWithValue("@Remarks", "Stocks Returned");
                                cmd.ExecuteNonQuery();


                                float invoicenewbalance = invoicepreviousbalance - float.Parse(txtGrossTotal.Text);
                                cmd = new SqlCommand("update SupplierInvoicesTable set RemainingBalance = @RemainingBalance where InvoiceNo = '" + cboInvoiceNo.Text + "' and Customer_ID = '" + cboSupplier.SelectedValue.ToString() + "'", MainClass.con);
                                cmd.Parameters.AddWithValue("@RemainingBalance", invoicenewbalance);
                                cmd.ExecuteNonQuery();


                                string InsertLedgerInfo = "insert into SupplierLedgersInfoTable (SupplierLedger_ID,Supplier_ID,PayingDate,InvoiceNo,TotalAmount,PreviousPaid,TodayPaid,NewBalance,Remarks) values(@SupplierLedger_ID,@Supplier_ID,@PayingDate,@InvoiceNo,@TotalAmount,@PreviousPaid,@TodayPaid,@NewBalance,@Remarks)";
                                cmd = new SqlCommand(InsertLedgerInfo, MainClass.con);
                                cmd.Parameters.AddWithValue("@SupplierLedger_ID", SupplierLedgerID);
                                cmd.Parameters.AddWithValue("@Supplier_ID", cboSupplier.SelectedValue.ToString());
                                cmd.Parameters.AddWithValue("@InvoiceNo", cboInvoiceNo.Text);
                                cmd.Parameters.AddWithValue("@PayingDate", DateTime.Now.ToShortDateString());
                                cmd.Parameters.AddWithValue("@TotalAmount", txtGrossTotal.Text);
                                cmd.Parameters.AddWithValue("@PreviousPaid", 0);
                                cmd.Parameters.AddWithValue("@TodayPaid", 0);
                                cmd.Parameters.AddWithValue("@NewBalance", newbalance);
                                cmd.Parameters.AddWithValue("@Remarks", "Stocks Returned");
                                cmd.ExecuteNonQuery();
                            }

                            MessageBox.Show("Stocks Returned Successfully");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                            MainClass.con.Close();
                        } //Ledgers Updating
                    }

                    try
                    {
                        float handcash = CashInHand();
                        float cash = handcash + float.Parse(txtGrossTotal.Text);

                        cmd = new SqlCommand("update StoreTable set CashInHand = @CashInHand", MainClass.con);
                        cmd.Parameters.AddWithValue("@CashInHand", cash);
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        MainClass.con.Close();
                        MessageBox.Show(ex.Message);
                    } //UpdateCash Flow


                    MainClass.con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    MainClass.con.Close();
                }
            }
            FullClear();
            cboSupplier.SelectedIndex = 0;

        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            FullClear();
        }

        private void txtReturnRate_TextChanged(object sender, EventArgs e)
        {

        }

        private void GBProductDetails_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
