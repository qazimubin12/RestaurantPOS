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
    public partial class ViewAllTables : Form
    {
        public ViewAllTables()
        {
            InitializeComponent();
        }

        private void ShowAllTables(DataGridView dgv, DataGridViewColumn TableID, DataGridViewColumn TableName, DataGridViewColumn TableSpace)
        {
            SqlCommand cmd = null;
            try
            {
                MainClass.con.Open();
                cmd = new SqlCommand("select TableID,TableName,TableSpace from Tables", MainClass.con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                TableID.DataPropertyName = dt.Columns["TableID"].ToString();
                TableName.DataPropertyName = dt.Columns["TableName"].ToString();
                TableSpace.DataPropertyName = dt.Columns["TableSpace"].ToString();
                dgv.DataSource = dt;
                MainClass.con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                MainClass.con.Close();
            }
        }

        private void ViewAllTables_Load(object sender, EventArgs e)
        {
            ShowAllTables(DGVTables, TableIDGV, TableNameGV, TableSpaceGV);
        }

        private void editeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            Tables ts = new Tables();
            ts.Show();
            ts.lblID.Text = DGVTables.CurrentRow.Cells[0].Value.ToString();
            ts.txtTableName.Text = DGVTables.CurrentRow.Cells[1].Value.ToString();
            ts.txtTableSpace.Text = DGVTables.CurrentRow.Cells[2].Value.ToString();
            ts.btnSave.Text = "UPDATE";
            ts.btnSave.BackColor = Color.Black;
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();

        }
    }
}
