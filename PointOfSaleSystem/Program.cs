﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PointOfSaleSystem
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]

        

        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            try
            {
                string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                if (!File.Exists(path + "\\posconnect"))
                {
                    DatabaseSettings sl = new DatabaseSettings();
                    sl.ShowDialog();
                }




                MainClass.con.Open();
                SqlCommand cmd = new SqlCommand("select * from example where status = 1 ", MainClass.con);
                cmd.CommandType = System.Data.CommandType.Text;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    if (dr[2].ToString() == "1")
                    {
                        dr.Close();
                        SqlCommand cmd1 = new SqlCommand("select left(e.Keys,5)+'-' +RIGHT(e.Keys,4) as 'Date' from example e where e.status = 1", MainClass.con);
                        cmd1.CommandType = System.Data.CommandType.Text;
                        SqlDataReader dr1 = cmd1.ExecuteReader();
                        if (dr1.Read())
                        {
                            if (DateTime.Parse(dr1["Date"].ToString()) <= DateTime.Now.Date)
                            {
                                dr1.Close();
                                SqlCommand cmd2 = new SqlCommand("update  example set status = 0", MainClass.con);
                                cmd2.CommandType = System.Data.CommandType.Text;
                                cmd2.ExecuteNonQuery();
                                MessageBox.Show("Your Software has been expired");

                                AdminLogin amd = new AdminLogin();
                                amd.ShowDialog();
                            }
                            else
                            {
                                try
                                {
                                    dr1.Close();
                                    SqlCommand cmd2 = new SqlCommand("select today from example e where e.status = 1", MainClass.con);
                                    cmd2.CommandType = System.Data.CommandType.Text;
                                    SqlDataReader dr2 = cmd2.ExecuteReader();
                                    if (dr2.Read())
                                    {
                                        if (DateTime.Parse(dr2["today"].ToString()) > DateTime.Now.Date)
                                        {
                                            SqlCommand cmd3 = new SqlCommand("update  example set status = 0", MainClass.con);
                                            cmd3.CommandType = System.Data.CommandType.Text;
                                            cmd3.ExecuteNonQuery();
                                            MessageBox.Show("Your Software has been expired");
                                            AdminLogin amd = new AdminLogin();
                                            amd.ShowDialog();
                                        }
                                        else
                                        {
                                            MainClass.con.Close();
                                            try
                                            {
                                                SqlCommand cmd4 = new SqlCommand("update example set today = '" + DateTime.Now.Date + "' where status = 1", MainClass.con);
                                                cmd4.CommandType = System.Data.CommandType.Text;
                                                MainClass.con.Open();
                                                cmd4.ExecuteNonQuery();
                                                MainClass.con.Close();
                                            }
                                            catch (Exception ex)
                                            {
                                                MainClass.con.Close();
                                                MessageBox.Show(ex.Message);
                                            }

                                            Application.Run(new MDI());
                                        }
                                    }
                                }
                                catch (Exception ex)
                                {
                                    MainClass.con.Close();
                                    MessageBox.Show(ex.Message);
                                }

                            }
                        }

                    }
                    else
                    {
                        AdminLogin amd = new AdminLogin();
                        amd.ShowDialog();
                    }

                    MainClass.con.Close();

                }
                else
                {
                    AdminLogin amd = new AdminLogin();
                    amd.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MainClass.con.Close();
                MessageBox.Show(ex.Message);
            }


        }
    }
}
