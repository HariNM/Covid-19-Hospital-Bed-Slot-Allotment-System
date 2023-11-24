using MySql.Data.MySqlClient;

namespace Covid_Hospital_System
{
    public partial class Form1 : Form
    {
        DB db = new DB();
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FgPass frm = new FgPass();
            frm.Show();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form2 frm = new Form2();
            frm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(this.textBox1.Text) || string.IsNullOrWhiteSpace(this.textBox2.Text))
            {
                MessageBox.Show("Please enter Username or Password", "Required", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.textBox1.Focus();
            }
            string strVar1 = this.textBox1.Text;
            string strVar2 = this.textBox2.Text;
            string query = string.Concat("Select count(*) from users natural join patients where username='", this.textBox1.Text, "' and password='", this.textBox2.Text, "'");
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
                Patient_Details frm1 = new Patient_Details(this);
                frm1.Show();
            }
            
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}