using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Covid_Hospital_System
{
    public partial class FgPass : Form
    {
        DB db = new DB();
        public FgPass()
        {
            InitializeComponent();
        }

        private void FgPass_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string query2 = string.Concat("Select count(*) from admissions");
            int i = Convert.ToInt32(db.QueryScalar(query2));

            MySqlConnection conn = new MySqlConnection("server=localhost;database=dbsproject;uid=root;pwd=Hari@9255");
            MySqlCommand cmd = null;
            
            string cmdString = "";
            conn.Open();
            cmdString = "UPDATE Users SET Password = '" + textBox3.Text + "' WHERE Username = '" + textBox1.Text + "'";
            cmd = new MySqlCommand(cmdString, conn);
            MessageBox.Show("Password has been updated successfully!");
            cmd.ExecuteNonQuery();
            conn.Close();
            
        }
    }
}
