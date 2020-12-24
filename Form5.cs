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
    public partial class Form5 : Form
    {
        public Form5()
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
        private void connectDatabase()
        {
            String oradb = "server=localhost;user id=root;password=bhaga1234;database=air";
            conn = new MySqlConnection(oradb);
            conn.Open();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            connectDatabase();
            table = new DataTable();
            String command = "select * from flight_plan";
            dataAdapter = new MySqlDataAdapter(command, conn);
            dataAdapter.Fill(table);
            if (table.Rows.Count <= 0)
            {
                MessageBox.Show("No such flights available", "Invalid Entry");
            }
            else
            {


                for (int i = 0; i < table.Rows.Count; i++)
                {
                    for (int j = 0; j <= 8; j++)
                    {
                        string myData = table.Rows[i][j].ToString();
                        richTextBox1.Text += myData + " ";
                    }
                    richTextBox1.Text += " \n";

                }
            }


        }

        private void button1_Click(object sender, EventArgs e)
        {
            connectDatabase();
            String command;
            table = new DataTable();
            //String command = "select * from flight_plan,flight where flight_plan.flight_no = flight.flight_no and start_from = '" + textBox1.Text+ "' and go_to ='"+ textBox2.Text+"' and date_of_f = '"+textBox3.Text+"' and flight.airline_name = '" + textBox4.Text +"'";
            if (radioButton1.Checked)
            {
                richTextBox1.Text = "";
                command = "select * from flight_plan,flight where flight_plan.flight_no = flight.flight_no and start_from = '" + textBox1.Text + "' and go_to ='" + textBox2.Text + "' and date_of_f = '" + textBox3.Text + "' order by dep_time asc"; //and flight.airline_name = '" + textBox4.Text + "'";
            }
            else
            {
                richTextBox1.Text = "";
                command = command = "select * from flight_plan,flight where flight_plan.flight_no = flight.flight_no and start_from = '" + textBox1.Text + "' and go_to ='" + textBox2.Text + "' and date_of_f = '" + textBox3.Text + "' order by baseprice asc"; //and flight.airline_name = '" + textBox4.Text + "'";
            }
            dataAdapter = new MySqlDataAdapter(command, conn);
            dataAdapter.Fill(table);
            if (table.Rows.Count <= 0)
            {
                MessageBox.Show("No such flights available", "Invalid Entry");
            }
            else
            {


                for (int i = 0; i < table.Rows.Count; i++)
                {
                    for (int j = 0; j <= 8; j++)
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
