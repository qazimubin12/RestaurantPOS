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
    public partial class PaymentWindow : Form
    {
        RestaurantPOS rp;
        public PaymentWindow(RestaurantPOS rpos)
        {
            InitializeComponent();
            rp = rpos;
        }

        private void btnFinalize_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void PaymentWindow_Load(object sender, EventArgs e)
        {
            txtGrandTotal.Text = rp.lblGrandTotal.Text;
            Calculate();
        }

        private void Calculate()
        {
            if (txtPaying.Text == "" || txtPaying.Text == "0")
            {
                txtBalance.Text = txtGrandTotal.Text;
            }
            else
            {
                txtBalance.Text = Convert.ToString(float.Parse(txtGrandTotal.Text) - float.Parse(txtPaying.Text));
            }
        }
        private void txtPaying_TextChanged(object sender, EventArgs e)
        {
            Calculate();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
