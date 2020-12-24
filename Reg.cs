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
    public partial class Reg : Form
    {
        public Reg()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        MySqlConnection conn;
        MySqlDataAdapter dataAdapter,dataAdapter2;
        DataTable table;
        public void connectDatabase()
        {
            String oradb = "server=localhost;user id=root;password=bhaga1234;database=air";
            conn = new MySqlConnection(oradb);
            conn.Open();
        }
        public static int i = 1;
        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
                connectDatabase();
                String tr1;
                table = new DataTable();
                DataTable t2 = new DataTable();
                //String command = "select * from customer_login where c_user = '" + textBox1.Text + "' and c_pw = '" + textBox2.Text + "'";
                i++;
                if(textBox8.Text != textBox9.Text)
                {
                    MessageBox.Show("Passwords not matching!");
                }
                if(radioButton1.Checked)
                tr1 = "insert into customer values (" + i +",'" + textBox1.Text + "'," + "'" + textBox2.Text + "'," + "'" + textBox3.Text + "'," +"'M'," +"'" + textBox4.Text + "'," + "'" + textBox5.Text + "'," + "'" + textBox6.Text + "')";
                else
                tr1 = "insert into customer values (" + i + ",'" + textBox1.Text + "'," + "'" + textBox2.Text + "'," + "'" + textBox3.Text + "'," + "'F'," + "'" + textBox4.Text + "'," + "'" + textBox5.Text + "'," + "'" + textBox6.Text + "')";

                String tr = "insert into customer_login values('" + textBox7.Text + "','" + textBox8.Text + "'," + i + " )";

                //String tr = "deli";
                dataAdapter2 = new MySqlDataAdapter(tr1, conn);
                dataAdapter2.Fill(t2);
                dataAdapter = new MySqlDataAdapter(tr, conn);
                dataAdapter.Fill(table);
                
                Homepage form = new Homepage();
                form.Show();
                Hide();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Homepage form = new Homepage();
            form.Show();
            Hide();
        }
    }
}
