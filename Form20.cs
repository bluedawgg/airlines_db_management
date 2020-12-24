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
    public partial class Form20 : Form
    {
        public Form20()
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
            try
            {
                connectDatabase();
                table = new DataTable();
                String command = "call remove_flight('" + textBox1.Text + "')";
                dataAdapter = new MySqlDataAdapter(command, conn);
                dataAdapter.Fill(table);
                MessageBox.Show("Flight Deleted.");
            }
            catch(Exception exce)
            {
                MessageBox.Show(exce.Message);
            }
            
        }
    }
}
