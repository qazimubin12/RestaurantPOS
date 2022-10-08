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
            if(POS.SALEID != 0)
            {
                MainClass.ShowBill(rd, crystalReportViewer1, "CreateBill", "@SalesID", POS.SALEID);
            }
           
            else if(Reports.ReportsSaleID != 0)
            {
                MainClass.ShowBill(rd, crystalReportViewer1, "CreateBill", "@SalesID", Reports.ReportsSaleID);
              
            }


            else if (RecentSales.RecentReportsSaleID != 0)
            {
                MainClass.ShowBill(rd, crystalReportViewer1, "CreateBill", "@SalesID", RecentSales.RecentReportsSaleID);
                
            }
        }
    }
}
