using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;

namespace RestaurantPOS
{
    public partial class Login : Form
    {
        SqlDataReader dr;
        public static object User_NAME = "";
        public static object Role = "";
        public Login()
        {
            InitializeComponent();
        }

        private void Clear()
        {
            txtUsername.Text = "";
            txtPassword.Text = "";
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            //MainClass.con.Open();
            //SqlCommand cmd1 = new SqlCommand("select ExpiryDate from testing", MainClass.con);
            //DateTime Date = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd"));
            //DateTime expiry = DateTime.Parse(cmd1.ExecuteScalar().ToString());

            //MainClass.con.Close();
            //if (Date < expiry)
            //{
                try
                {
                    bool found = false;
                    object count = 0;
                    MainClass.con.Open();
                    SqlCommand cmd = new SqlCommand("select * from UsersTable where Username = @Username and Password = @Password ", MainClass.con);
                    cmd.Parameters.AddWithValue("@Username", txtUsername.Text);
                    cmd.Parameters.AddWithValue("@Password", txtPassword.Text);
                    dr = cmd.ExecuteReader();
                    dr.Read();
                    if (dr.HasRows)
                    {
                        found = true;
                        User_NAME = dr["Name"].ToString();
                        Role = dr["Role"].ToString();
                    }
                    else
                    {
                        found = false;
                        MessageBox.Show("Invalid Details", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Clear();
                        txtUsername.Focus();
                    }
                    dr.Close();
                    MainClass.con.Close();
                    if (found == true)
                    {
                        if (Role.ToString() == "Admin")
                        {

                            MessageBox.Show("Welcome " + User_NAME);
                            HomeScreen das = new HomeScreen();
                            das.lblLoggedUser.Text = Role.ToString();
                            MainClass.showWindow(das, this, MDI.ActiveForm);
                        }
                        else
                        {
                            MessageBox.Show("Welcome " + User_NAME);
                            HomeScreen das = new HomeScreen();
                            das.lblLoggedUser.Text = Role.ToString();
                            MainClass.showWindow(das, this, MDI.ActiveForm);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MainClass.con.Close();
                    MessageBox.Show(ex.Message);
                }
            //}
        }

        private void CBShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            if(CBShowPassword.Checked)
            {
                txtPassword.UseSystemPasswordChar = false;
            }
            else
            {
                txtPassword.UseSystemPasswordChar = true;
            }
        }
    }
}
