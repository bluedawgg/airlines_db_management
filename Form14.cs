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
    public partial class Form14 : Form
    {
        public Form14()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Hide();
            Form29 form = new Form29();
            form.ShowDialog();
            Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Hide();
            Form24 form = new Form24();
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
        private void button3_Click(object sender, EventArgs e)
        {
            connectDatabase();
            table = new DataTable();
            String command = "select * from customer where c_id = " + textBox1.Text;
            dataAdapter = new MySqlDataAdapter(command, conn);
            dataAdapter.Fill(table);


            if (table.Rows.Count <= 0)
            {
                MessageBox.Show("No such users available.", "Invalid Entry");
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
