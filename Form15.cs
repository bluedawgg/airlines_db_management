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
    public partial class Form15 : Form
    {
        public Form15()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Hide();
            Form20 form = new Form20();
            form.ShowDialog();
            Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Hide();
            Form25 form = new Form25();
            form.ShowDialog();
            Show();
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
            connectDatabase();
            table = new DataTable();
            String command = "select * from flight where flight_no = '" + textBox1.Text + "' and airline_name = '" + Form12.A_N + "'";
            dataAdapter = new MySqlDataAdapter(command, conn);
            dataAdapter.Fill(table);
            if (table.Rows.Count <= 0)
            {
                MessageBox.Show("No such Flight.", "Invalid Entry");
            }
            else
            {
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    for (int j = 0; j < table.Columns.Count; j++)
                    {
                        string myData = table.Rows[i][j].ToString();
                        richTextBox1.Text += myData + " ";
                    }
                    richTextBox1.Text += " \n";

                }

            }
        }
    }
}
