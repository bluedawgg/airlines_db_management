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
    public partial class Form12 : Form
    {
        public Form12()
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
        public static String A_N;
        private void button1_Click(object sender, EventArgs e)
        {

            connectDatabase();
            table = new DataTable();
            String command = "select * from airlines where airline_name = '" + textBox1.Text + "'";
            dataAdapter = new MySqlDataAdapter(command, conn);
            dataAdapter.Fill(table);
            if (table.Rows.Count <= 0)
            {
                MessageBox.Show("No such airline found", "Invalid Entry");
            }
            else
            {
                Hide();
                A_N = textBox1.Text;
                Form13 form = new Form13();
                form.ShowDialog();
                Show();
            }



            
        }
    }
}
