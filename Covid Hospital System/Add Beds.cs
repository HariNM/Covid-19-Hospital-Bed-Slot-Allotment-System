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
    public partial class Add_Beds : Form
    {
        DB db = new DB();

        DataTable table = new DataTable("table");
        int index;
        public Add_Beds()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Add_Beds_Load(object sender, EventArgs e)
        {
            table.Columns.Add("Room No.", Type.GetType("System.Int32"));
            table.Columns.Add("Bed No.", Type.GetType("System.Int32"));
            table.Columns.Add("Hospital ID", Type.GetType("System.Int32"));
            table.Columns.Add("Type");
            dataGridView1.DataSource = table;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            table.Rows.Add(textBox1.Text, textBox2.Text, textBox3.Text, comboBox1.GetItemText(comboBox1.SelectedItem));
            string query = string.Concat("Select count(*) from beds");
            int i = Convert.ToInt32(db.QueryScalar(query));

            string query2 = string.Concat("Select RoomId from rooms where RoomNo='" + textBox1.Text + "' and HospitalID='" + textBox3.Text + "'");
            int k = Convert.ToInt32(db.QueryScalar(query2));
            MySqlConnection conn = new MySqlConnection("server=localhost;database=dbsproject;uid=root;pwd=Hari@9255");

            MySqlCommand cmd = null;

            string cmdString = "";

            conn.Open();


            cmdString = "insert into beds values(" + (i + 1) + ",'" + comboBox1.GetItemText(comboBox1.SelectedItem) + "'," + k + ",'Available')";

            cmd = new MySqlCommand(cmdString, conn);

            cmd.ExecuteNonQuery();

        }
        private void button2_Click(object sender, EventArgs e)
        {
            index = dataGridView1.CurrentCell.RowIndex;
            dataGridView1.Rows.RemoveAt(index);
            MySqlConnection conn = new MySqlConnection("server=localhost;database=dbsproject;uid=root;pwd=Hari@9255");

            MySqlCommand cmd = null;

            string cmdString = "";

            conn.Open();


            cmdString = "update beds set availability = 'Occupied' where roomid=" + textBox4.Text;
            cmd = new MySqlCommand(cmdString, conn);

            cmd.ExecuteNonQuery();

        }
        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
