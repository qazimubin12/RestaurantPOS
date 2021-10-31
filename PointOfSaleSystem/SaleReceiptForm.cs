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

namespace PointOfSaleSystem
{
    public partial class SaleReceiptForm : Form
    {
        POS p = new POS();
        ReportDocument rd = new ReportDocument();

        public SaleReceiptForm()
        {
            InitializeComponent();
        }

        private void SaleReceiptForm_Load(object sender, EventArgs e)
        {
            if (POS.savedcustomercheck == true)
            {
                MainClass.ShowSaleRecieptSavedCustomer(rd, crystalReportViewer1, "SaleRecieptOfSavedCustomer");
            }
            else
            {
                
                MainClass.ShowSaleReciept(rd, crystalReportViewer1, "SaleRecieptOfWalkingCustomer");
            }
        }

        private void SaleReceiptForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (rd != null)
            {
                rd.Close();
            }
        }
    }
}
