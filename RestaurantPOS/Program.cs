using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RestaurantPOS
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
                else
                {
                    Application.Run(new MDI());
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
