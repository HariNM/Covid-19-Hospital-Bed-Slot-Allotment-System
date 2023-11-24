using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Covid_Hospital_System
{
    public partial class SignUpR : Form
    {
        DB db = new DB();
        public SignUpR()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
             if (string.IsNullOrWhiteSpace(this.textBox1.Text) || string.IsNullOrWhiteSpace(this.textBox2.Text) || string.IsNullOrWhiteSpace(this.textBox3.Text) || string.IsNullOrWhiteSpace(this.textBox4.Text))
             {
                 MessageBox.Show("Please enter Username or Password", "Required", MessageBoxButtons.OK, MessageBoxIcon.Error);
                 this.textBox1.Focus();
             }
             if(textBox2.Text==textBox3.Text) 
            {
                string query = string.Concat("Select count(*) from Receptionist");
                int i = Convert.ToInt32(db.QueryScalar(query));
                string query1 = string.Concat("Select count(*) from Users");
                int j = Convert.ToInt32(db.QueryScalar(query1));
                MySqlConnection conn = new MySqlConnection("server=localhost;database=dbsproject;uid=root;pwd=Hari@9255");

                MySqlCommand cmd = null;
                MySqlCommand cmd1 = null;
                string cmdString = "";
                string cmdString1 = "";
                conn.Open();

                cmdString = "insert into users values(" + (j + 1) + ",'" + textBox1.Text + "','" + textBox3.Text + "','Receptionist'," + textBox4.Text + ")";
                cmdString1 = "insert into receptionist values(" + (i + 1) + ",'" + textBox1.Text + "'," + (j + 1) + ")";
                cmd = new MySqlCommand(cmdString, conn);
                cmd1 = new MySqlCommand(cmdString1, conn);
                cmd.ExecuteNonQuery();
                cmd1.ExecuteNonQuery();

                conn.Close();

                MessageBox.Show("Your Account has been created! Please Log In.");
            }
            else { MessageBox.Show("Please confirm your password!"); }

             
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
