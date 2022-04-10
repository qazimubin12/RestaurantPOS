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
    public partial class TokenForm : Form
    {
        ReportDocument rd;
        public TokenForm()
        {
            InitializeComponent();
        }

        private void TokenForm_Load(object sender, EventArgs e)
        {
            rd = new ReportDocument();
        }
    }
}
