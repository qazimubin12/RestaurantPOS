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
    public partial class HomeScreen : Form
    {
        public HomeScreen()
        {
            InitializeComponent();
        }


        

     

        private void btnCategories_Click(object sender, EventArgs e)
        {
            Categories c = new Categories();
            MainClass.showWindow(c, this, MDI.ActiveForm);

        }

        private void btnUnits_Click(object sender, EventArgs e)
        {
            Units u = new Units();
            MainClass.showWindow(u, this, MDI.ActiveForm);

        }

        private void btnProducts_Click(object sender, EventArgs e)
        {
            Products p = new Products();
            MainClass.showWindow(p, this, MDI.ActiveForm);

        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            Settings s = new Settings();
            MainClass.showWindow(s, this, MDI.ActiveForm);
        }

        private void btnPersons_Click(object sender, EventArgs e)
        {
            Persons p = new Persons();
            MainClass.showWindow(p, this, MDI.ActiveForm);
        }

        private void btnPurchase_Click(object sender, EventArgs e)
        {
            PurchaseInvoice p = new PurchaseInvoice();
            MainClass.showWindow(p, this, MDI.ActiveForm);
        }

        private void btnInventory_Click(object sender, EventArgs e)
        {
            Inventory i = new Inventory();
            MainClass.showWindow(i, this, MDI.ActiveForm);
        }

        private void btnLedgers_Click(object sender, EventArgs e)
        {
            Ledgers l = new Ledgers();
            MainClass.showWindow(l, this, MDI.ActiveForm);
        }

        private void btnPos_Click(object sender, EventArgs e)
        {
            POS p = new POS();
            if(lblLoggedUser.Text == "Admin")
            {
                p.lblLoggedInUser.Text = "Admin";
            }
            MainClass.showWindow(p, this, MDI.ActiveForm);
        }




        private void FindDailySales()
        {
            string sdate = DateTime.Now.ToShortDateString();
            try
            {
                MainClass.con.Open();
                SqlCommand cmd = new SqlCommand("select sum(Round(GrandTotal,0)) from SalesTable where SaleDate between '" + DateTime.Now.ToShortDateString()+ "' and '" + DateTime.Now.ToShortDateString() + "'  ", MainClass.con);
                lblDailySales.Text = cmd.ExecuteScalar().ToString();
                MainClass.con.Close();

            }
            catch (Exception ex)
            {
                MainClass.con.Close();
                MessageBox.Show(ex.Message);
            }
        }

        //private void FindCustomerBalance()
        //{
        //    try
        //    {
        //        MainClass.con.Open();
        //        SqlCommand cmd = new SqlCommand("select sum(Round(Balance,0)) from CustomerLedgersTable", MainClass.con);
        //        lblCashInHand.Text = cmd.ExecuteScalar().ToString();
        //        MainClass.con.Close();

        //    }
        //    catch (Exception ex)
        //    {
        //        MainClass.con.Close();
        //        MessageBox.Show(ex.Message);
        //    }
        //}



        private void FindLowStocks()
        {
            try
            {
                SqlCommand cmd = null;
                MainClass.con.Open();
                float lowqty;
                cmd = new SqlCommand("select LowStockQty from StoreTable",MainClass.con);
                object l = cmd.ExecuteScalar();
                if(l == null)
                {
                    lowqty = 0;
                }
                else
                {
                    lowqty = float.Parse(l.ToString());
                }


                cmd = new SqlCommand("select count(*) from Inventory where Qty < "+lowqty.ToString()+"  ", MainClass.con);
                lblLowStocks.Text = cmd.ExecuteScalar().ToString();
                MainClass.con.Close();

            }
            catch (Exception ex)
            {
                MainClass.con.Close();
                MessageBox.Show(ex.Message);
            }
        }


      

        private void HomeScreen_Load(object sender, EventArgs e)
        {
            FindDailySales();
            FindLowStocks();
            if (lblLoggedUser.Text == "Cashier")
            {
                btnSettings.Visible = false;
                btnInventory.Visible = false;
                btnReports.Visible = false;
                lowStocksPanel.Visible = false;
                dailysalesPanel.Visible = false;
            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Login ls = new Login();
            MainClass.showWindow(ls, this, MDI.ActiveForm);
        }

        private void btnExpenses_Click(object sender, EventArgs e)
        {
            Expenses es = new Expenses();
            MainClass.showWindow(es, this, MDI.ActiveForm);

        }

        
        private void btnReports_Click(object sender, EventArgs e)
        {
            Reports r = new Reports();
            MainClass.showWindow(r, this, MDI.ActiveForm);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Expenses r = new Expenses();
            MainClass.showWindow(r, this, MDI.ActiveForm);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            PurchaseReturn r = new PurchaseReturn();
            MainClass.showWindow(r, this, MDI.ActiveForm);

        }

        private void btnStockControl_Click(object sender, EventArgs e)
        {
            StockControl s = new StockControl();
            MainClass.showWindow(s, this, MDI.ActiveForm);


        }

        private void button3_Click(object sender, EventArgs e)
        {
            Login ls = new Login();
            MainClass.showWindow(ls, this, MDI.ActiveForm);

        }
    }
}
