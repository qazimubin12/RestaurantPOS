using CrystalDecisions.CrystalReports.Engine;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RestaurantPOS
{
    public partial class BillForm : Form
    {
        ReportDocument rd;
        public BillForm()
        {
            InitializeComponent();
        }

        private void BillForm_Load(object sender, EventArgs e)
        {
            rd = new ReportDocument();
            if(RestaurantPOS.TakeAwaySaleID != 0)
            {
                MainClass.ShowBill(rd, crystalReportViewer1, "CreateBill", "@SalesID", RestaurantPOS.TakeAwaySaleID);
            }
            else if(RestaurantPOS.DINEINID != 0)
            {
                MainClass.ShowDineInBill(rd, crystalReportViewer1, "CreateBill", "@SalesID", RestaurantPOS.DINEINID);
            }
            else if(RestaurantPOS.LedgerSaleID != 0)
            {
                MainClass.ShowLedgerBill(rd, crystalReportViewer1, "LedgerBill", "@LedgeBillID", RestaurantPOS.LedgerSaleID);
            }
            else if(RestaurantPOS.DeliverySaleID != 0)
            {
                MainClass.ShowDeliveryBill(rd, crystalReportViewer1, "CreateBill", "@SalesID", RestaurantPOS.DeliverySaleID);
            }

            else if(Reports.ReportsSaleID != 0)
            {
                if(Reports.ReportOrderTypeID == 1)
                {
                    MainClass.ShowDineInBill(rd, crystalReportViewer1, "CreateBill", "@SalesID", Reports.ReportsSaleID);
                }
                else if(Reports.ReportOrderTypeID == 2)
                {
                    MainClass.ShowBill(rd, crystalReportViewer1, "CreateBill", "@SalesID", Reports.ReportsSaleID);
                }
                else if(Reports.ReportOrderTypeID == 3)
                {
                    MainClass.ShowLedgerBill(rd, crystalReportViewer1, "LedgerBill", "@LedgeBillID", Reports.ReportsSaleID);
                }
            }


            else if (RecentSales.RecentReportsSaleID != 0)
            {
                if (RecentSales.RecentReportOrderTypeID == 1)
                {
                    MainClass.ShowDineInBill(rd, crystalReportViewer1, "CreateBill", "@SalesID", RecentSales.RecentReportsSaleID);
                }
                else if (RecentSales.RecentReportOrderTypeID == 2)
                {
                    MainClass.ShowBill(rd, crystalReportViewer1, "CreateBill", "@SalesID", RecentSales.RecentReportsSaleID);
                }
                else if (RecentSales.RecentReportOrderTypeID == 3)
                {
                    MainClass.ShowLedgerBill(rd, crystalReportViewer1, "LedgerBill", "@LedgeBillID", RecentSales.RecentReportsSaleID);
                }
            }
        }
    }
}
