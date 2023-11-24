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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Covid_Hospital_System
{
    public partial class Payments : Form
    {
        DB db = new DB();
        Random r = new Random();
       
        public Payments()
        {
            InitializeComponent();
        }

        private void Payments_Load(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            Patient_Details frm = new Patient_Details(form);
            BedAvail frm1 = new BedAvail(frm);
            DateTime dateOfissue = DateTime.ParseExact(frm1.dateTimePicker1.Value.Date.ToString(), "dd-MM-yyyy HH:mm:ss", CultureInfo.InvariantCulture);
            DateTime dateOfdischarge = DateTime.ParseExact(frm1.dateTimePicker2.Value.Date.ToString(), "dd-MM-yyyy HH:mm:ss", CultureInfo.InvariantCulture);
            DateTime inTime = Convert.ToDateTime(dateOfissue.ToString("yyyy-MM-dd"));
            DateTime outTime = Convert.ToDateTime(dateOfdischarge.ToString("yyyy-MM-dd"));
            int rnd = r.Next(1, 31);
            label6.Text = ((outTime.Subtract(inTime).Days+rnd)*100).ToString() ;
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            Patient_Details frm = new Patient_Details(form);
            BedAvail frm1=new BedAvail(frm);
            Random rnd = new Random();

            MessageBox.Show("Booking Successfull!");

            string query = string.Concat("Select count(*) from Payments");
            int i = Convert.ToInt32(db.QueryScalar(query));
            string bedId = frm1.textBox1.Text;
            /*string query1 = string.Concat("Select AdmissionsId from admissions natural join beds where bedid={bedId}");
            int j = Convert.ToInt32(db.QueryScalar(query1));*/
            MySqlConnection conn = new MySqlConnection("server=localhost;database=dbsproject;uid=root;pwd=Hari@9255");

            MySqlCommand cmd = null;
            
            string cmdString = "";
            
            conn.Open();

            cmdString = "insert into payments(admissionsid, amountpaid, paymentdate, accountno, IFSC) values(" + rnd.Next(1,8) + ",'" + label6.Text + "',curdate(),'" + textBox2.Text + "','"+ textBox3.Text+"')";
           
            cmd = new MySqlCommand(cmdString, conn);
           
            cmd.ExecuteNonQuery();
           

            conn.Close();

        }
    }
}
