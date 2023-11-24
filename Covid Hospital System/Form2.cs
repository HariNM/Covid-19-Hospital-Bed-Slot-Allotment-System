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
    public partial class Form2 : Form
    {
        DB db = new DB();
        public Form2()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(this.textBox1.Text) || string.IsNullOrWhiteSpace(this.textBox2.Text) || string.IsNullOrWhiteSpace(this.textBox3.Text) || string.IsNullOrWhiteSpace(this.textBox4.Text))
            {
                MessageBox.Show("Please enter Username or Password", "Required", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.textBox1.Focus();
            }
            if (textBox2.Text == textBox3.Text)
            {
                string query = string.Concat("Select count(*) from Patients");
                int i = Convert.ToInt32(db.QueryScalar(query));
                string query1 = string.Concat("Select count(*) from Users");
                int j = Convert.ToInt32(db.QueryScalar(query1));
                MySqlConnection conn = new MySqlConnection("server=localhost;database=dbsproject;uid=root;pwd=Hari@9255");

                MySqlCommand cmd = null;
                MySqlCommand cmd1 = null;
                //MySqlCommand cmd2 = null;
                string cmdString = "";
                string cmdString1 = "";
                conn.Open();

                cmdString = "insert into users values(" + (j + 1) + ",'" + textBox1.Text + "','" + textBox3.Text + "','Patient',NULL" + ")";
                cmdString1 = "insert into patients values(" + (i + 1) + ",'" + textBox1.Text + "','" + textBox6.Text + "','" + textBox7.Text+"','"+ textBox5.Text+"','"+textBox4.Text+"',"+ (j + 1)+ ")";
               // string cmdString2 = "insert into login_record(UserId,LoginTime) values(" + (j + 1) + ",NOW())";
                cmd = new MySqlCommand(cmdString, conn);
                cmd1 = new MySqlCommand(cmdString1, conn);
               // cmd2 = new MySqlCommand(cmdString2, conn);
                cmd.ExecuteNonQuery();
                cmd1.ExecuteNonQuery();
               // cmd2.ExecuteNonQuery();
                conn.Close();

                MessageBox.Show("Your Account has been created! Please Log In.");
            }
            else { MessageBox.Show("Please confirm your password!"); }
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
    }
}
