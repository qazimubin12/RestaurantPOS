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
namespace RestaurantPOS
{
    public partial class Tables : Form
    {
        private Button tablebutton;
        public delegate void TransfDelegate(String value, String value2);
        public event TransfDelegate TransfEvent;
        public Tables()
        {
            InitializeComponent();
        }

     
        private void ClearandReset()
        {
            btnSave.Text = "SAVE";
            btnSave.BackColor = Color.SeaGreen;
            txtTableName.Clear();
            txtTableSpace.Clear();
        }

        private void GetTables()
        {
            SqlCommand cmd = null;
            SqlDataReader dr;
            try
            {
                MainClass.con.Open();
                fpTables.Controls.Clear();
                cmd = new SqlCommand("select TableID, TableName,TableSpace,Availability from Tables", MainClass.con);
                dr = cmd.ExecuteReader();
                while(dr.Read())
                {
                    tablebutton = new Button();
                    tablebutton.Width = 150;
                    tablebutton.Height = 50;
                    tablebutton.Font = new Font("Arial", 10);
                    tablebutton.FlatStyle = FlatStyle.Flat;
                    tablebutton.BackColor = Color.FromArgb(39, 174, 96);
                    tablebutton.BackgroundImageLayout = ImageLayout.Stretch;
                    tablebutton.Text = dr["TableName"].ToString();
                    tablebutton.ForeColor = Color.White;
                    tablebutton.Tag = dr["TableID"].ToString();
                    if(dr["Availability"].ToString() == "False")
                    {
                        tablebutton.Enabled = false;
                        tablebutton.BackColor = Color.Red;
                    }


                    fpTables.Controls.Add(tablebutton);

                    tablebutton.Click += new EventHandler(OnTableClick);

                }

                MainClass.con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                MainClass.con.Close();
            }
        }


        public void OnTableClick(object sender, EventArgs e)
        {


            SqlCommand cmd = null;
            string tablename = "";
            string tablespace = "";
            string tag = ((Button)sender).Tag.ToString();
            try
            {
                MainClass.con.Open();
                cmd = new SqlCommand("select TableName from Tables where TableID = '" + tag + "'", MainClass.con);
                tablename = cmd.ExecuteScalar().ToString();

                cmd = new SqlCommand("select TableSpace from Tables where TableID = '" + tag + "'", MainClass.con);
                tablespace = cmd.ExecuteScalar().ToString();
                MainClass.con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                MainClass.con.Close();
            }
            TransfEvent(tablename, tablespace);

            this.Close();
           

        }



        private void btnSave_Click(object sender, EventArgs e)
        {
            
            SqlCommand cmd = null;
            if (btnSave.Text == "SAVE")
            {
                try
                {
                    MainClass.con.Open();
                    cmd = new SqlCommand("insert into Tables (TableName,TableSpace) values (@TableName,@TableSpace)", MainClass.con);
                    cmd.Parameters.AddWithValue("@TableName", txtTableName.Text);
                    cmd.Parameters.AddWithValue("@TableSpace", txtTableSpace.Text);
                    cmd.ExecuteNonQuery();
                    MainClass.con.Close();
                    MessageBox.Show("Table Saved Successfully");
                    GetTables();
                    ClearandReset();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    MainClass.con.Close();
                }
            }
            else
            {
                try
                {
                    MainClass.con.Open();
                    cmd = new SqlCommand("update Tables set TableName = @TableName ,TableSpace =  @TableSpace where TableID = @TableID", MainClass.con);
                    cmd.Parameters.AddWithValue("@TableID", lblID.Text);
                    cmd.Parameters.AddWithValue("@TableName", txtTableName.Text);
                    cmd.Parameters.AddWithValue("@TableSpace", txtTableSpace.Text);
                    cmd.ExecuteNonQuery();
                    MainClass.con.Close();
                    MessageBox.Show("Table Updated Successfully");
                    GetTables();
                    ClearandReset();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    MainClass.con.Close();
                }
            }
        }

        private void Tables_Load(object sender, EventArgs e)
        {
            GetTables();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnViewAll_Click(object sender, EventArgs e)
        {
            this.Close();
            ViewAllTables vs = new ViewAllTables();
            vs.Show();
        }

        private void lblID_Click(object sender, EventArgs e)
        {

        }
    }
}
