using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Covid_Hospital_System
{
    public partial class Receptioninst : Form
    {
        DB db = new DB();
        RecepLogin rl;
        public Receptioninst(RecepLogin rl)
        {
            InitializeComponent();
            this.rl = rl;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Add_Beds frm = new Add_Beds();
            frm.Show();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void Receptioninst_Load(object sender, EventArgs e)
        {
            string username = rl.textBox1.Text;
            string password = rl.textBox2.Text;
            var query1 = string.Concat("Select ReceptionistId from Receptionist natural join users where username='", username, "' and password='", password, "'");
            int q1 = Convert.ToInt16(db.QueryScalar(query1));
            label5.Text = q1.ToString();
            var query2 = string.Concat("Select receptionistName from Receptionist natural join users where username='", username, "' and password='", password, "'");
            string q2 = Convert.ToString(db.QueryScalar(query2));
            label6.Text = q2.ToString();
            var query3 = string.Concat("Select HospitalID from Receptionist natural join users where username='", username, "' and password='", password, "'");
            int q3 = Convert.ToInt16(db.QueryScalar(query3));
            label7.Text = q3.ToString();
        }
    }
}
