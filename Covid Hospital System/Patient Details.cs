using System;
using System.Collections;
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
    public partial class Patient_Details : Form
    {
        DB db = new DB();
        Form1 frm;
        public Patient_Details(Form1 frm)
        {
            InitializeComponent();
            this.frm = frm;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            BedAvail frm = new BedAvail(this);
            frm.Show();
        }


        /* private void label3_Click(object sender, EventArgs e)
         {

         }*/




        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click_1(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void Patient_Details_Load(object sender, EventArgs e)
        {
            string username = frm.textBox1.Text;
            string password = frm.textBox2.Text;
            var query1 = string.Concat("Select PatientId from Patients natural join users where username='", username, "' and password='", password, "'");
            int q1 = Convert.ToInt16(db.QueryScalar(query1));
            label3.Text = q1.ToString();
            var query2 = string.Concat("Select Gender from Patients natural join users where username='", username, "' and password='", password, "'");
            string q2 = Convert.ToString(db.QueryScalar(query2));
            label8.Text = q2.ToString();
            var query3 = string.Concat("Select Name from Patients natural join users where username='", username, "' and password='", password, "'");
            string q3 = Convert.ToString(db.QueryScalar(query3));
            label9.Text = q3.ToString();
            var query4 = string.Concat("Select dateofbirth from Patients natural join users where username='", username, "' and password='", password, "'");
            string q4 = Convert.ToString(db.QueryScalar(query4));
            DateTime dateOfBirth = DateTime.ParseExact(q4, "dd-MM-yyyy HH:mm:ss", CultureInfo.InvariantCulture);
            label10.Text = dateOfBirth.ToString("dd-MM-yyyy");
            var query5 = string.Concat("Select BloodGroup from Patients natural join users where username='", username, "' and password='", password, "'");
            string q5 = Convert.ToString(db.QueryScalar(query5));
            label11.Text = q5.ToString();
        }
    }
}
