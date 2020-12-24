using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace AirlineReservationSystem
{
    public partial class Homepage : Form
    {
        public Homepage()
        {
            BackgroundImage = Properties.Resources.Airline;
            InitializeComponent();
        }

        MySqlConnection conn;
        MySqlDataAdapter dataAdapter;
        DataTable table;
        public void connectDatabase()
        {
            String oradb = "server=localhost;user id=root;password=bhaga1234;database=air";
            conn = new MySqlConnection(oradb);
            conn.Open();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Hide();
            Form7 form = new Form7();
            form.ShowDialog();
            Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Reg form = new Reg();
            form.Show();
            Hide();
        }
        public static String usr;

        private void button6_Click(object sender, EventArgs e)
        {
            connectDatabase();
            table = new DataTable();
            String command = "select * from customer_login where c_user = '" + textBox1.Text + "' and c_pw = '" + textBox2.Text + "'";
            dataAdapter = new MySqlDataAdapter(command, conn);
            dataAdapter.Fill(table);
            if (table.Rows.Count <= 0)
            {
                MessageBox.Show("No such combination found", "Invalid Entry");
            }
            else
            {
                usr = textBox1.Text;
                Hide();
                Form3 form = new Form3();
                form.ShowDialog();
                Show();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Hide();
            Form5 form = new Form5();
            form.ShowDialog();
            Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Hide();
            Form6 form = new Form6();
            form.ShowDialog();
            Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Hide();
            Form10 form = new Form10();
            form.ShowDialog();
            Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            connectDatabase();
            table = new DataTable();
            String command = "select * from admin_login where a_user = '" + textBox1.Text + "' and a_pw = '" + textBox2.Text + "'";
            dataAdapter = new MySqlDataAdapter(command, conn);
            dataAdapter.Fill(table);
            if (table.Rows.Count <= 0)
            {
                MessageBox.Show("No such combination found", "Invalid Entry");
            }
            else
            {
                Hide();
                Form4 form = new Form4();
                form.ShowDialog();
                Show();
            }
            conn.Close();
        }
    }
}
