using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RestaurantPOS
{
    public partial class MDI : Form
    {
        public MDI()
        {
            InitializeComponent();
        }

        private void MDI_Load(object sender, EventArgs e)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            if (!File.Exists(path + "\\posconnect"))
            {
                DatabaseSettings sl = new DatabaseSettings();
                sl.ShowDialog();
            }
            long fileLen = new FileInfo(path + "\\posconnect").Length;
            if (File.Exists(path + "\\posconnect") && fileLen != 0)
            {
                MainClass.con.Open();
                SqlCommand cmd = new SqlCommand("select count(*) from UsersTable", MainClass.con);
                int ob = int.Parse(cmd.ExecuteScalar().ToString());
                MainClass.con.Close();

                if (ob != 0)
                {
                    Login hs = new Login();
                    MainClass.showWindow(hs, this);
                }
                else {
                    MainClass.con.Open();
                    SqlCommand cmd1 = new SqlCommand("insert into UsersTable (Name,Username,Password,Role) values(@Name,@Username,@Password,@Role)", MainClass.con);
                    cmd1.Parameters.AddWithValue("@Name", "Administrator");
                    cmd1.Parameters.AddWithValue("@Username", "admin");
                    cmd1.Parameters.AddWithValue("@Password", "admin");
                    cmd1.Parameters.AddWithValue("@Role", "Admin");
                    cmd1.ExecuteNonQuery();
                    MainClass.con.Close();

                    MessageBox.Show("User Added Username is admin, and password is admin");
                }
            }
            else
            {
                DatabaseSettings sl = new DatabaseSettings();
                sl.ShowDialog();
            }
        }
    }
}
