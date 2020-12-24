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

namespace AirlineReservationSystem
{
    public partial class Form8 : Form
    {
        public Form8()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
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

        private void button1_Click(object sender, EventArgs e)
        {
            Random generator = new Random();
            int number = generator.Next(1000, 10000);
            connectDatabase();
            table = new DataTable();
            String command = "insert into OTP values('" + Homepage.usr+"'," + number+")";
            dataAdapter = new MySqlDataAdapter(command, conn);
            dataAdapter.Fill(table);

            MessageBox.Show("OTP SENT.");

            Hide();
            Payment_final form = new Payment_final();
            form.ShowDialog();
            Show();
        }
    }
}
