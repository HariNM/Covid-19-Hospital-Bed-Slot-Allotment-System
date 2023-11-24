using Microsoft.VisualBasic;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Relational;
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
    public partial class BedAvail : Form
    {
        DB db = new DB();
        DataTable table = new DataTable("table");
        Patient_Details frm;
        string? index;
        public int bedid;
        public BedAvail(Patient_Details frm)
        {

            InitializeComponent();
            this.frm = frm;
        }
        private void loadData()
        {
            MySqlConnection conn = new MySqlConnection("server=localhost;database=dbsproject;uid=root;pwd=Hari@9255");
            var query = "select * from Beds";
            //int q = Convert.ToInt16(db.QueryScalar(query));
            MySqlCommand mySqlCommand = new MySqlCommand(query, conn);
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            adapter.SelectCommand = mySqlCommand;
            adapter.Fill(table);
            BindingSource bindingSource = new BindingSource();
            bindingSource.DataSource = table;
            dataGridView1.DataSource = bindingSource;
        }
        private void BedAvail_Load(object sender, EventArgs e)
        {
            loadData();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (index == "Available")
            {
                string query2 = string.Concat("Select count(*) from admissions");
                int i = Convert.ToInt32(db.QueryScalar(query2));

                MySqlConnection conn = new MySqlConnection("server=localhost;database=dbsproject;uid=root;pwd=Hari@9255");
                MySqlCommand cmd = null;
                MySqlCommand cmd1 = null;
                string cmdString = "";
                conn.Open();
                DateTime dateOfissue = DateTime.ParseExact(dateTimePicker1.Value.Date.ToString(), "dd-MM-yyyy HH:mm:ss", CultureInfo.InvariantCulture);
                DateTime dateOfdischarge = DateTime.ParseExact(dateTimePicker2.Value.Date.ToString(), "dd-MM-yyyy HH:mm:ss", CultureInfo.InvariantCulture);
                cmdString = "insert into admissions values(" + (i + 1) + ",'" + frm.label3.Text + "','" + dateOfissue.ToString("yyyy-MM-dd") + "','" + dateOfdischarge.ToString("yyyy-MM-dd") + "'," + textBox1.Text + ")";
                string cmdString2 = "Update beds SET Availability = 'Occupied' WHERE bedid=" + "'" + textBox1.Text + "'";
                cmd = new MySqlCommand(cmdString, conn);
                cmd1 = new MySqlCommand(cmdString2, conn);
                cmd.ExecuteNonQuery();
                cmd1.ExecuteNonQuery();
                Payments frm1 = new Payments();
                frm1.Show();
                conn.Close();

            }
            else { MessageBox.Show("The selected bed is already occupied. Please choose another bed or wait for slots to become empty.", "Required", MessageBoxButtons.OK, MessageBoxIcon.Error); }


        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
        }

        public void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            MySqlConnection conn = new MySqlConnection("server=localhost;database=dbsproject;uid=root;pwd=Hari@9255");
            MySqlCommand cmd = null;
            if (e.RowIndex >= 0)
            {
                string cmdString = "";
                conn.Open();
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];

                textBox1.Text = row.Cells["BedId"].Value.ToString();
                textBox2.Text = row.Cells["RoomId"].Value.ToString();
                textBox4.Text = row.Cells["Type"].Value.ToString();
                string query = string.Concat("Select HospitalId from Rooms where RoomId='" + row.Cells["RoomId"].Value.ToString() + "'");
                bedid = int.Parse(textBox1.Text);
                textBox3.Text = Convert.ToInt16(db.QueryScalar(query)).ToString();
                index = row.Cells["Availability"].Value.ToString();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
