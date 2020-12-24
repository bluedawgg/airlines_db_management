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
    public partial class Form29 : Form
    {
        public Form29()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
        MySqlConnection conn;
        MySqlDataAdapter dataAdapter, dataAdapter2;
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
                
                if (radioButton1.Checked)
                    tr1 = "insert into customer values ('" + textBox1.Text + "'," + "'" + textBox2.Text + "'," + "'" + textBox3.Text + "'," + "'M'," + "'" + textBox4.Text + "'," + "'" + textBox5.Text + "'," + "'" + textBox6.Text + "'," + "'" + textBox7.Text +"')";
                else
                    tr1 = "insert into customer values ('" + textBox1.Text + "'," + "'" + textBox2.Text + "'," + "'" + textBox3.Text + "'," + "'M'," + "'" + textBox4.Text + "'," + "'" + textBox5.Text + "'," + "'" + textBox6.Text + "'," + "'" + textBox7.Text + "')";

                String tr = "insert into customer_login values('" + textBox8.Text + "','" + textBox9.Text + "'," + textBox1.Text + " )";
                
                //String tr = "deli";
                dataAdapter2 = new MySqlDataAdapter(tr1, conn);
                dataAdapter2.Fill(t2);
                dataAdapter = new MySqlDataAdapter(tr, conn);
                dataAdapter.Fill(table);
                MessageBox.Show("User Successfully Added");
                Homepage form = new Homepage();
                form.Show();
                Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
