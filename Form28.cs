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
    public partial class Form28 : Form
    {
        public Form28()
        {
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
        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                connectDatabase();
                table = new DataTable();
                String command = "insert into caterer values(" + textBox1.Text + ",'" + textBox2.Text + "')";
                dataAdapter = new MySqlDataAdapter(command, conn);
                dataAdapter.Fill(table);

                MessageBox.Show("Caterer added.");
            }
            catch(Exception exx)
            {
                MessageBox.Show("Caterer already exists");
            }
        }
    }
}
