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
    
    public partial class Form7 : Form
    {

        MySqlConnection conn;
        MySqlDataAdapter dataAdapter, dataAdapter2;
        DataTable table, ta2;

        public static String d, f, t;
        public void connectDatabase()
        {
            String oradb = "server=localhost;user id=root;password=bhaga1234;database=air";
            conn = new MySqlConnection(oradb);
            conn.Open();
        }
        public Form7()
        {
            InitializeComponent();
        }
        public static String fno;
        public static String mea;
        public static String s_nu;
        public static String a__t;
        public static String d__t;
        private void button3_Click(object sender, EventArgs e)
        {
            connectDatabase();
            fno = textBox4.Text;
            if (radioButton1.Checked)
                mea = "VEG";
            else
                mea = "NON-VEG";
            s_nu = textBox5.Text;
            ta2 = new DataTable();
            String com2 = "select dep_time,arr_time from flight_plan where f_no = "+textBox5.Text;
            dataAdapter2 = new MySqlDataAdapter(com2, conn);
            dataAdapter2.Fill(ta2);
            a__t = ta2.Rows[0][0].ToString();
            d__t = ta2.Rows[0][1].ToString();
        
            Hide();
            Form8 form = new Form8();
            form.ShowDialog();
            Show();


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
                d = textBox1.Text;
                f = textBox2.Text;
                t = textBox3.Text;


                String command = "call book('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "')";
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
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            

        }
    }
}
