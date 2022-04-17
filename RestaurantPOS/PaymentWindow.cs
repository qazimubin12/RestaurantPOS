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
            if (rp.cboOrderType.Text == "Dine In" || rp.cboOrderType.Text == "Take Away")
            {
                if (txtPaying.Text != "" && cboPaymentMethod.Text != "")
                {
                    float total = float.Parse(txtGrandTotal.Text);
                    float paying = float.Parse(txtPaying.Text);
                    if (total > paying)
                    {
                        MessageBox.Show("Paying Amount is Incorrect");
                        return;
                    }
                    else
                    {
                        this.Close();
                    }
                }
                else
                {
                    MessageBox.Show("Paying Amount cannot be Empty");
                    return;
                }
            }
        }

        private void PaymentWindow_Load(object sender, EventArgs e)
        {
            txtGrandTotal.Text = rp.lblGrandTotal.Text;
            if(rp.cboOrderType.Text == "Dine In" || rp.cboOrderType.Text == "Take Away" || rp.cboOrderType.Text == "Delivery")
            {
                label4.Visible = false;
                txtBalance.Visible = false;
            }
            else
            {
                label4.Visible = true;
                txtBalance.Visible = true;
            }
            
            Calculate();
        }

        private void Calculate()
        {
            float total = 0;
            float paying = 0;
            

            if (txtPaying.Text == "" || txtPaying.Text == "0")
            {
                txtBalance.Text = txtGrandTotal.Text;
                txtChange.Text = "0";
                total = float.Parse(txtGrandTotal.Text);
                paying = 0;
            }
            else
            {
                total = float.Parse(txtGrandTotal.Text);
                paying = float.Parse(txtPaying.Text);
                if (paying > total)
                {
                    txtChange.Text =  Convert.ToString(float.Parse(txtPaying.Text) - float.Parse(txtGrandTotal.Text));
                    txtBalance.Text = "0";
                }
                else
                {
                    txtBalance.Text = Convert.ToString(float.Parse(txtGrandTotal.Text) - float.Parse(txtPaying.Text));
                    txtChange.Text = "0";
                }
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

        private void txtBalance_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
