﻿using System;
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

namespace PointOfSaleSystem
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
                        try
                        {
                            MainClass.con.Open();
                            SqlCommand cmd1 = new SqlCommand("select * from ModeSwitching", MainClass.con);
                            count = cmd1.ExecuteScalar();
                            MainClass.con.Close();
                        }
                        catch (Exception ex)
                        {
                            MainClass.con.Close();
                            MessageBox.Show(ex.Message);
                        }

                        if (count == null)
                        {
                            try
                            {
                                MainClass.con.Open();
                                SqlCommand cmd1 = new SqlCommand("insert into ModeSwitching (InventoryMode)  values ('"+1+"')", MainClass.con);
                                cmd1.ExecuteNonQuery();
                                MainClass.con.Close();

                            }
                            catch (Exception ex)
                            {
                                MainClass.con.Close();
                                MessageBox.Show(ex.Message);
                            }
                        }

                        MessageBox.Show("Welcome " + User_NAME);
                        HomeScreen das = new HomeScreen();
                        das.lblLoggedUser.Text = Role.ToString();
                        MainClass.showWindow(das, this, MDI.ActiveForm);
                    }
                    else
                    {
                        MessageBox.Show("Welcome " + User_NAME);
                        RestaurantPOS das = new RestaurantPOS();
                        das.lblLoggedInUser.Text = Role.ToString();
                        MainClass.showWindow(das, this, MDI.ActiveForm);
                    }
                }
            }
            catch (Exception ex)
            {
                MainClass.con.Close();
                MessageBox.Show(ex.Message);
            }
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
