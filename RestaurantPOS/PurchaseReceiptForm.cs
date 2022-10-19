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
    public partial class PurchaseReceiptForm : Form
    {
        POS p = new POS();
        ReportDocument rd = new ReportDocument();

        public PurchaseReceiptForm()
        {
            InitializeComponent();
        }

    
        private void PurchaseReceiptForm_Load(object sender, EventArgs e)
        {
            if (PurchaseInvoice.PURCHASE_ID != 0)
            {
                MainClass.ShowPurchaseReceipt(rd, crystalReportViewer1, "PurchaseReceipt", "@PurchaseID", PurchaseInvoice.PURCHASE_ID);
            }
            else if (Reports.ReportsPurchaseID != 0)
            {
                MainClass.ShowPurchaseReceipt(rd, crystalReportViewer1, "PurchaseReceipt", "@PurchaseID", Reports.ReportsPurchaseID);
            }
        } 

        private void PurchaseReceiptForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (rd != null)
            {
                rd.Close();
            }
        }
    }
}
