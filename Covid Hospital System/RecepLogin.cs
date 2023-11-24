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

namespace Covid_Hospital_System
{
    public partial class RecepLogin : Form
    {
        DB db = new DB();
        public RecepLogin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(this.textBox1.Text) || string.IsNullOrWhiteSpace(this.textBox2.Text))
            {
                MessageBox.Show("Please enter Username or Password", "Required", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.textBox1.Focus();
            }
            string query = string.Concat("Select count(*) from users natural join receptionist where username='", this.textBox1.Text, "' and password='", this.textBox2.Text, "'");
            if (Convert.ToInt16(db.QueryScalar(query)) <= 0)
            {
                MessageBox.Show("Username or Password incorrect. Please enter valid username or password.");

                return;
            }
            else
            {
                string query1 = string.Concat("Select userid from users where username=", this.textBox1.Text);
                int i = Convert.ToInt32(db.QueryScalar(query));
                MySqlConnection conn = new MySqlConnection("server=localhost;database=dbsproject;uid=root;pwd=Hari@9255");
                MySqlCommand cmd2 = null;
                conn.Open();
                string cmdString2 = "insert into login_report(UserId,LoginTime) values(" + i + ",NOW())";
                cmd2 = new MySqlCommand(cmdString2, conn);
                cmd2.ExecuteNonQuery();
                conn.Close();
                Receptioninst frm = new Receptioninst(this);
                frm.Show();
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FgPassR frm = new FgPassR();
            frm.Show();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SignUpR frm = new SignUpR();
            frm.Show();
        }
    }
}
