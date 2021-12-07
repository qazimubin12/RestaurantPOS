using DGVPrinterHelper;
using iTextSharp.text;
using iTextSharp.text.pdf;
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

namespace PointOfSaleSystem
{
    public partial class Reports : Form
    {
        int saledate = 0;
        int purchasedate = 0;
        public Reports()
        {
            InitializeComponent();
        }



        private void CheckMode()
        {
            int mode;
            try
            {
                MainClass.con.Open();
                SqlCommand cmd = new SqlCommand("select InventoryMode from ModeSwitching", MainClass.con);
                mode = int.Parse(cmd.ExecuteScalar().ToString());
                if (mode == 0)
                {
                    btnPurchaseReports.Visible = false;
                    btnProfitLossReports.Visible = false;
                    btnExpenseReports.Visible = false;
                }
                else
                {
                    btnPurchaseReports.Visible = true;
                    btnExpenseReports.Visible = true;
                    btnProfitLossReports.Visible = true;


                }

                MainClass.con.Close();
            }
            catch (Exception ex)
            {
                MainClass.con.Close();
                MessageBox.Show(ex.Message);
            }
        }

        private void btnPurchaseReports_Click(object sender, EventArgs e)
        {
            //     tabControl1.SelectedIndex = 0;
        }

        private void Reports_Load(object sender, EventArgs e)
        {
            CheckMode();
            lblLoggedUser.Text = "Admin";

            tabControl1.SelectedIndex = 1;
            ShowLedgersInfo(DGVLedgersReports, CustomerGV, PayingDateGV, LedgerInvoiceNoGV, LedgerTotalGv, PreviousPaidGV, TodaysPaidGV, NewBalanceGV);
            MainClass.FillCustomer(CboCustomerLedger);
            MainClass.HideAllTabsOnTabControl(tabControl1);
            //       ShowPurchases(DGVPurchases, SupplierInvoiceIDGV, PaymentTypeGV, InvoiceNoGv, InvoiceDateGV, SupplierNameGV, GrandTotalGV);
            //    ShowSales(DGVSales, CustomerInvoiceIDGV, PaymentGVC, InvoiceNoGVC, InvoiceDateGVC, CustomerGVC, GrandTotalGVC);
            ShowRestaurantSales(DGVSales, SaleIDGV, SaleInvoiceNoGV, OrderDateGV, OrderTypeGV, OrderTimeGV, SaleGrandTotalGV);
        }

        //private void ShowPurchases(DataGridView dgv, DataGridViewColumn SupplierInvoiceID,DataGridViewColumn PaymentType, DataGridViewColumn InvoiceNo, DataGridViewColumn InvoiceDate, DataGridViewColumn PersonName, DataGridViewColumn GrandTotal )
        //{
        //    MainClass.con.Open();
        //    SqlCommand cmd = null;
        //    if(purchasedate == 1)
        //    {
        //        cmd = new SqlCommand("select st.SupplierInvoiceID,st.PaymentType,pp.InvoiceNo,format(st.InvoiceDate, 'dd/MM/yyyy') as 'Date',pt.Name,pp.GrandTotal from PurchasesInfo p inner join PurchasesTable pp on pp.PurchaseID = p.Purchase_ID  inner join PersonsTable pt on pt.PersonID = pp.Supplier_ID inner join SupplierInvoicesTable st on st.SupplierInvoiceID = pp.SupplierInvoice_ID where st.InvoiceDate between '" + dtPurchase1.Value.ToShortDateString() + "' and '" + dtPurchase2.Value.ToShortDateString() + "'", MainClass.con);
        //    }
        //    else
        //    {
        //        cmd = new SqlCommand("select st.SupplierInvoiceID,st.PaymentType,pp.InvoiceNo,format(st.InvoiceDate, 'dd/MM/yyyy') as 'Date',pt.Name,pp.GrandTotal from PurchasesInfo p inner join PurchasesTable pp on pp.PurchaseID = p.Purchase_ID  inner join PersonsTable pt on pt.PersonID = pp.Supplier_ID inner join SupplierInvoicesTable st on st.SupplierInvoiceID = pp.SupplierInvoice_ID", MainClass.con);
        //    }
        //    SqlDataAdapter da = new SqlDataAdapter(cmd);
        //    DataTable dt = new DataTable();
        //    da.Fill(dt);
        //    SupplierInvoiceID.DataPropertyName = dt.Columns["SupplierInvoiceID"].ToString();
        //    PaymentType.DataPropertyName = dt.Columns["PaymentType"].ToString();
        //    InvoiceNo.DataPropertyName = dt.Columns["InvoiceNo"].ToString();
        //    InvoiceDate.DataPropertyName = dt.Columns["Date"].ToString();
        //    PersonName.DataPropertyName = dt.Columns["Name"].ToString();
        //    GrandTotal.DataPropertyName = dt.Columns["GrandTotal"].ToString();
        //    dgv.DataSource = dt;
        //    MainClass.con.Close();
        //}



        private void ShowLedgersInfo(DataGridView dgv, DataGridViewColumn Customer, DataGridViewColumn PayingDate, DataGridViewColumn InvoiceNo,
            DataGridViewColumn TotalAmount, DataGridViewColumn PreviousPaid, DataGridViewColumn TodayPaid, DataGridViewColumn NewBalance, string search = null)
        {
            try
            {
                SqlCommand cmd = null;
                MainClass.con.Open();
                if (search == "0" || search == null)
                {
                    cmd = new SqlCommand("select p.Name,ct.PayingDate,ct.InvoiceNo,ct.TotalAmount,ct.PreviousPaid,ct.TodayPaid,ct.NewBalance  from CustomerLedgersInfoTable ct inner join PersonsTable p on p.PersonID = ct.Customer_ID", MainClass.con);
                }
                else
                {
                    cmd = new SqlCommand("select p.Name,ct.PayingDate,ct.InvoiceNo,ct.TotalAmount,ct.PreviousPaid,ct.TodayPaid,ct.NewBalance  from CustomerLedgersInfoTable ct inner join PersonsTable p on p.PersonID = ct.Customer_ID where ct.Customer_ID = '" + search + "'", MainClass.con);
                }
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                Customer.DataPropertyName = dt.Columns["Name"].ToString();
                PayingDate.DataPropertyName = dt.Columns["PayingDate"].ToString();
                InvoiceNo.DataPropertyName = dt.Columns["InvoiceNo"].ToString();
                TotalAmount.DataPropertyName = dt.Columns["TotalAmount"].ToString();
                PreviousPaid.DataPropertyName = dt.Columns["PreviousPaid"].ToString();
                TodayPaid.DataPropertyName = dt.Columns["TodayPaid"].ToString();
                NewBalance.DataPropertyName = dt.Columns["NewBalance"].ToString();
                dgv.DataSource = dt;
                MainClass.con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                MainClass.con.Close();
            }
        }


        private void ShowRestaurantSales(DataGridView dgv, DataGridViewColumn SaleID, DataGridViewColumn InvoiceNo, DataGridViewColumn SaleDate, DataGridViewColumn OrderType, DataGridViewColumn SaleTime, DataGridViewColumn GrandTotal, string search = null)
        {
            MainClass.con.Open();
            SqlCommand cmd = null;
            if (saledate == 1)
            {
                if (search == "" || search == null)
                {
                    cmd = new SqlCommand("select SaleID,InvoiceNo,format(SaleDate, 'dd/MM/yyyy') as 'Date',OrderType, SaleTime,round(GrandTotal,0) as 'GrandTotal' from SalesTable where SaleDate between '" + dtSale1.Value.ToShortDateString() + "' and '" + dtSale2.Value.ToShortDateString() + "' ", MainClass.con);
                }
                else
                {
                    cmd = new SqlCommand("select SaleID,InvoiceNo,format(SaleDate, 'dd/MM/yyyy') as 'Date',OrderType, SaleTime,round(GrandTotal,0) as 'GrandTotal'   from SalesTable where SaleDate between '" + dtSale1.Value.ToShortDateString() + "' and '" + dtSale2.Value.ToShortDateString() + "' and InvoiceNo  like '%" + search + "%' ", MainClass.con);
                }
            }
            else
            {
                if (search == "" || search == null)
                {
                    cmd = new SqlCommand("select SaleID,InvoiceNo,format(SaleDate, 'dd/MM/yyyy') as 'Date',OrderType, SaleTime,round(GrandTotal,0) as 'GrandTotal'  from SalesTable", MainClass.con);
                }
                else
                {
                    cmd = new SqlCommand("select SaleID,InvoiceNo,format(SaleDate, 'dd/MM/yyyy') as 'Date',OrderType, SaleTime,round(GrandTotal,0) as 'GrandTotal'   from SalesTable where InvoiceNo  like '%" + search + "%'", MainClass.con);
                }
            }
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            SaleID.DataPropertyName = dt.Columns["SaleID"].ToString();
            InvoiceNo.DataPropertyName = dt.Columns["InvoiceNo"].ToString();
            SaleDate.DataPropertyName = dt.Columns["Date"].ToString();
            SaleTime.DataPropertyName = dt.Columns["SaleTime"].ToString();
            OrderType.DataPropertyName = dt.Columns["OrderType"].ToString();
            GrandTotal.DataPropertyName = dt.Columns["GrandTotal"].ToString();
            dgv.DataSource = dt;
            MainClass.con.Close();

            CalculateProvidedTotal();
        }


        //private void ShowSales(DataGridView dgv, DataGridViewColumn CustomerInvoiceID, DataGridViewColumn PaymentType, DataGridViewColumn InvoiceNo, DataGridViewColumn InvoiceDate, DataGridViewColumn PersonName, DataGridViewColumn GrandTotal)
        //{
        //    MainClass.con.Open();
        //    SqlCommand cmd = null;
        //    if(saledate == 1)
        //    {
        //        cmd = new SqlCommand("select st.CustomerInvoiceID,st.PaymentType,pp.InvoiceNo,format(st.InvoiceDate, 'dd/MM/yyyy') as 'Date',pt.Name,pp.GrandTotal from SalesInfo p inner join SalesTable pp on pp.SaleID = p.Sales_ID  inner join PersonsTable pt on pt.PersonID = pp.Customer_ID inner join CustomerInvoicesTable st on st.CustomerInvoiceID = pp.CustomerInvoice_ID where st.InvoiceDate between '" + dtSale1.Value.ToShortDateString() + "' and '" + dtSale2.Value.ToShortDateString() + "' ", MainClass.con);
        //    }
        //    else
        //    {
        //        cmd = new SqlCommand("select st.CustomerInvoiceID,st.PaymentType,pp.InvoiceNo,format(st.InvoiceDate, 'dd/MM/yyyy') as 'Date',pt.Name,pp.GrandTotal from SalesInfo p inner join SalesTable pp on pp.SaleID = p.Sales_ID  inner join PersonsTable pt on pt.PersonID = pp.Customer_ID inner join CustomerInvoicesTable st on st.CustomerInvoiceID = pp.CustomerInvoice_ID", MainClass.con);
        //    }
        //    SqlDataAdapter da = new SqlDataAdapter(cmd);
        //    DataTable dt = new DataTable();
        //    da.Fill(dt);
        //    CustomerInvoiceID.DataPropertyName = dt.Columns["CustomerInvoiceID"].ToString();
        //    PaymentType.DataPropertyName = dt.Columns["PaymentType"].ToString();
        //    InvoiceNo.DataPropertyName = dt.Columns["InvoiceNo"].ToString();
        //    InvoiceDate.DataPropertyName = dt.Columns["Date"].ToString();
        //    PersonName.DataPropertyName = dt.Columns["Name"].ToString();
        //    GrandTotal.DataPropertyName = dt.Columns["GrandTotal"].ToString();
        //    dgv.DataSource = dt;
        //    MainClass.con.Close();
        //}


        private void CalculateProvidedTotal()
        {
            float total = 0;
            foreach (DataGridViewRow item in DGVSales.Rows)
            {
                total += float.Parse(item.Cells["SaleGrandTotalGV"].Value.ToString());
            }
            txtTotalSales.Text = total.ToString();
        }


        private void btnSaleReports_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 1;

        }

        private void btnLedgerReports_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 2;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 3;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 4;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            HomeScreen hs = new HomeScreen();
            hs.lblLoggedUser.Text = "Admin";
            MainClass.showWindow(hs, this, MDI.ActiveForm);
        }

        private void txtSearchPurhcaseInvoice_TextChanged(object sender, EventArgs e)
        {
            //      ShowPurchasesSearched(DGVPurchases, SupplierInvoiceIDGV, PaymentTypeGV, InvoiceNoGv, InvoiceDateGV, SupplierNameGV, GrandTotalGV);
        }


        //private void ShowPurchasesSearched(DataGridView dgv, DataGridViewColumn SupplierInvoiceID, DataGridViewColumn PaymentType, DataGridViewColumn InvoiceNo, DataGridViewColumn InvoiceDate, DataGridViewColumn PersonName, DataGridViewColumn GrandTotal)
        //{
        //    MainClass.con.Open();
        //    SqlCommand cmd = null;
        //    if (txtSearchPurhcaseInvoice.Text == "")
        //    {
        //        cmd = new SqlCommand("select st.SupplierInvoiceID,st.PaymentType,pp.InvoiceNo,format(st.InvoiceDate, 'dd/MM/yyyy') as 'Date',pt.Name,pp.GrandTotal from PurchasesInfo p inner join PurchasesTable pp on pp.PurchaseID = p.Purchase_ID  inner join PersonsTable pt on pt.PersonID = pp.Supplier_ID inner join SupplierInvoicesTable st on st.SupplierInvoiceID = pp.SupplierInvoice_ID", MainClass.con);
        //    }
        //    else
        //    {
        //        cmd = new SqlCommand("select st.SupplierInvoiceID,st.PaymentType,pp.InvoiceNo,format(st.InvoiceDate, 'dd/MM/yyyy') as 'Date',pt.Name,pp.GrandTotal from PurchasesInfo p inner join PurchasesTable pp on pp.PurchaseID = p.Purchase_ID  inner join PersonsTable pt on pt.PersonID = pp.Supplier_ID inner join SupplierInvoicesTable st on st.SupplierInvoiceID = pp.SupplierInvoice_ID where pp.InvoiceNo like '%" + txtSearchPurhcaseInvoice.Text + "%' ", MainClass.con);
        //    }
        //    SqlDataAdapter da = new SqlDataAdapter(cmd);
        //    DataTable dt = new DataTable();
        //    da.Fill(dt);
        //    SupplierInvoiceID.DataPropertyName = dt.Columns["SupplierInvoiceID"].ToString();
        //    PaymentType.DataPropertyName = dt.Columns["PaymentType"].ToString();
        //    InvoiceNo.DataPropertyName = dt.Columns["InvoiceNo"].ToString();
        //    InvoiceDate.DataPropertyName = dt.Columns["Date"].ToString();
        //    PersonName.DataPropertyName = dt.Columns["Name"].ToString();
        //    GrandTotal.DataPropertyName = dt.Columns["GrandTotal"].ToString();
        //    dgv.DataSource = dt;
        //    MainClass.con.Close();
        //}

        //private void ShowSalesSearched(DataGridView dgv, DataGridViewColumn CustomerInvoiceID, DataGridViewColumn PaymentType, DataGridViewColumn InvoiceNo, DataGridViewColumn InvoiceDate, DataGridViewColumn PersonName, DataGridViewColumn GrandTotal)
        //{
        //    MainClass.con.Open();
        //    SqlCommand cmd = null;
        //    if(txtSearchSaleInvoice.Text != "")
        //    {
        //        cmd = new SqlCommand("select st.CustomerInvoiceID,st.PaymentType,pp.InvoiceNo,format(st.InvoiceDate, 'dd/MM/yyyy') as 'Date',pt.Name,pp.GrandTotal from SalesInfo p inner join SalesTable pp on pp.SaleID = p.Sales_ID  inner join PersonsTable pt on pt.PersonID = pp.Customer_ID inner join CustomerInvoicesTable st on st.CustomerInvoiceID = pp.CustomerInvoice_ID where pp.InvoiceNo  like '%" + txtSearchSaleInvoice.Text + "%'", MainClass.con);
        //    }
        //    else
        //    {
        //        cmd = new SqlCommand("select st.CustomerInvoiceID,st.PaymentType,pp.InvoiceNo,format(st.InvoiceDate, 'dd/MM/yyyy') as 'Date',pt.Name,pp.GrandTotal from SalesInfo p inner join SalesTable pp on pp.SaleID = p.Sales_ID  inner join PersonsTable pt on pt.PersonID = pp.Customer_ID inner join CustomerInvoicesTable st on st.CustomerInvoiceID = pp.CustomerInvoice_ID", MainClass.con);
        //    }
        //    SqlDataAdapter da = new SqlDataAdapter(cmd);
        //    DataTable dt = new DataTable();
        //    da.Fill(dt);
        //    CustomerInvoiceID.DataPropertyName = dt.Columns["CustomerInvoiceID"].ToString();
        //    PaymentType.DataPropertyName = dt.Columns["PaymentType"].ToString();
        //    InvoiceNo.DataPropertyName = dt.Columns["InvoiceNo"].ToString();
        //    InvoiceDate.DataPropertyName = dt.Columns["Date"].ToString();
        //    PersonName.DataPropertyName = dt.Columns["Name"].ToString();
        //    GrandTotal.DataPropertyName = dt.Columns["GrandTotal"].ToString();
        //    dgv.DataSource = dt;
        //    MainClass.con.Close();
        //}


        private void button11_Click(object sender, EventArgs e)
        {
            // ShowPurchases(DGVPurchases, SupplierInvoiceIDGV, PaymentTypeGV, InvoiceNoGv, InvoiceDateGV, SupplierNameGV, GrandTotalGV);
        }

        private void PurchaseDate(object sender, EventArgs e)
        {
            if (dtPurchase1.Value == DateTime.Now && dtPurchase2.Value == DateTime.Now)
            {
                purchasedate = 0;

            }
            else
            {
                purchasedate = 1;

            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            purchasedate = 0;
            dtPurchase1.Value = DateTime.Now;
            dtPurchase2.Value = DateTime.Now;
            //            ShowPurchases(DGVPurchases, SupplierInvoiceIDGV, PaymentTypeGV, InvoiceNoGv, InvoiceDateGV, SupplierNameGV, GrandTotalGV);

        }

        private void SaleDate(object sender, EventArgs e)
        {
            if (dtSale2.Value == DateTime.Now && dtSale1.Value == DateTime.Now)
            {
                saledate = 0;

            }
            else
            {
                saledate = 1;
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            ShowRestaurantSales(DGVSales, SaleIDGV, SaleInvoiceNoGV, OrderDateGV, OrderTypeGV, OrderTimeGV, SaleGrandTotalGV);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            saledate = 0;
            dtSale1.Value = DateTime.Now;
            dtSale2.Value = DateTime.Now;
            ShowRestaurantSales(DGVSales, SaleIDGV, SaleInvoiceNoGV, OrderDateGV, OrderTypeGV, OrderTimeGV, SaleGrandTotalGV);
            //   ShowSales(DGVSales, CustomerInvoiceIDGV, PaymentGVC, InvoiceNoGVC, InvoiceDateGVC, CustomerGVC, GrandTotalGVC);
        }

        private void txtSearchSaleInvoice_TextChanged(object sender, EventArgs e)
        {
            ShowRestaurantSales(DGVSales, SaleIDGV, SaleInvoiceNoGV, OrderDateGV, OrderTypeGV, OrderTimeGV, SaleGrandTotalGV, txtSearchSaleInvoice.Text);

            //ShowSalesSearched(DGVSales, CustomerInvoiceIDGV, PaymentGVC, InvoiceNoGVC, InvoiceDateGVC, CustomerGVC, GrandTotalGVC);
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = null;
            string customerInvoiceID;
            string customerLedgerID;
            if (DGVSales.SelectedRows.Count == 1)
            {
                try
                {
                    MainClass.con.Open();

                    if (DGVSales.CurrentRow.Cells["OrderTypeGV"].Value.ToString() == "Dine In" || DGVSales.CurrentRow.Cells["OrderTypeGV"].Value.ToString() == "Take Away")
                    {
                        cmd = new SqlCommand("delete from SalesInfo where Sales_ID = '" + DGVSales.CurrentRow.Cells["SaleIDGV"].Value.ToString() + "'", MainClass.con);
                        cmd.ExecuteNonQuery();

                        cmd = new SqlCommand("delete from SalesTable where SaleID = '" + DGVSales.CurrentRow.Cells["SaleIDGV"].Value.ToString() + "'", MainClass.con);
                        cmd.ExecuteNonQuery();
                    }

                    else
                    {
                        if (DGVSales.CurrentRow.Cells["OrderTypeGV"].Value.ToString() == "Credit")
                        {
                            cmd = new SqlCommand("select CustomerInvoice_ID from SalesTable where InvoiceNo = '" + DGVSales.CurrentRow.Cells["SaleInvoiceNoGV"].Value.ToString() + "'", MainClass.con);
                            customerInvoiceID = cmd.ExecuteScalar().ToString();

                            cmd = new SqlCommand("select CustomerLedgerID from CustomerLedgersTable where CustomerInvoice_ID = '" + customerInvoiceID + "'", MainClass.con);
                            customerLedgerID = cmd.ExecuteScalar().ToString();

                            cmd = new SqlCommand("delete from CustomerLedgersInfoTable where CustomerLedger_ID = '" + customerLedgerID + "'", MainClass.con);
                            cmd.ExecuteNonQuery();

                            cmd = new SqlCommand("delete from CustomerLedgersTable where CustomerInvoice_ID = '" + customerInvoiceID + "'", MainClass.con);
                            cmd.ExecuteNonQuery();

                            cmd = new SqlCommand("delete from SalesInfo where Sales_ID = '" + DGVSales.CurrentRow.Cells["SaleIDGV"].Value.ToString() + "'", MainClass.con);
                            cmd.ExecuteNonQuery();

                            cmd = new SqlCommand("delete from SalesTable where SaleID = '" + DGVSales.CurrentRow.Cells["SaleIDGV"].Value.ToString() + "'", MainClass.con);
                            cmd.ExecuteNonQuery();

                            cmd = new SqlCommand("delete from CustomerInvoicesTable where CustomerInvoiceID = '" + customerInvoiceID + "'", MainClass.con);
                            cmd.ExecuteNonQuery();



                        }
                    }



                    MainClass.con.Close();

                    MessageBox.Show("Sale Deleted Successfully");
                    ShowRestaurantSales(DGVSales, SaleIDGV, SaleInvoiceNoGV, OrderDateGV, OrderTypeGV, OrderTimeGV, SaleGrandTotalGV);

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    MainClass.con.Close();
                }
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void CboCustomerLedger_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowLedgersInfo(DGVLedgersReports, CustomerGV, PayingDateGV, LedgerInvoiceNoGV, LedgerTotalGv, PreviousPaidGV, TodaysPaidGV, NewBalanceGV, CboCustomerLedger.SelectedValue.ToString());
        }

        private void btnExportPdF_Click(object sender, EventArgs e)
        {
            DGVPrinter printer = new DGVPrinter();
            printer.Title = "TFC - LEDGER REPORTS";
            if(CboCustomerLedger.SelectedIndex == 0)
            {
                printer.SubTitle = "Customer : ALL CUSTOMERS";
            }
            else
            {
                printer.SubTitle = "Customer : " + CboCustomerLedger.Text;
            }
            
            printer.SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
            printer.PageNumbers = true;
            printer.PorportionalColumns = true;
            printer.PageNumberInHeader = false;
            printer.HeaderCellAlignment = StringAlignment.Center;
            printer.Footer = "Developed by Cyber Soft Services  Contact: +92 300 9259266";
            printer.FooterSpacing = 15;
            printer.PrintDataGridView(DGVLedgersReports);

            
            MessageBox.Show("PDF SAVED SUCCESSFULLY");
        }

        public static int ReportsSaleID = 0;
        public static int ReportOrderTypeID = 0;
        private void DGVSales_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex != -1 || e.ColumnIndex != -1)
            {
                if(e.ColumnIndex == 0)
                {
                    if(DGVSales.CurrentRow.Cells["OrderTypeGV"].Value.ToString() == "Dine In")
                    {
                        ReportOrderTypeID = 1;
                        ReportsSaleID = int.Parse(DGVSales.CurrentRow.Cells["SaleIDGV"].Value.ToString());
                        BillForm bf = new BillForm();
                        bf.Show();

                    }
                    else if (DGVSales.CurrentRow.Cells["OrderTypeGV"].Value.ToString() == "Take Away")
                    {
                        ReportOrderTypeID = 2;
                        ReportsSaleID = int.Parse(DGVSales.CurrentRow.Cells["SaleIDGV"].Value.ToString());
                        BillForm bf = new BillForm();
                        bf.Show();
                    }
                    else if(DGVSales.CurrentRow.Cells["OrderTypeGV"].Value.ToString() == "Credit")
                    {
                        ReportOrderTypeID = 3;
                        ReportsSaleID = int.Parse(DGVSales.CurrentRow.Cells["SaleIDGV"].Value.ToString());
                        BillForm bf = new BillForm();
                        bf.Show();
                    }
                }
            }
        }
    }
}
