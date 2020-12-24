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
    public partial class Payment_final : Form
    {
        public Payment_final()
        {
            InitializeComponent();
        }

        MySqlConnection conn;
        MySqlDataAdapter dataAdapter, dataAdapter2, dataAdapter3, dataAdapter4;
        DataTable table;
        private void connectDatabase()
        {
            String oradb = "server=localhost;user id=root;password=bhaga1234;database=air";
            conn = new MySqlConnection(oradb);
            conn.Open();
        }
        int i = 0;
        public static String f_num;
        public static String usr_;
        public static String mea1;
        public static String snu;
        public static int b_i;
        public static String total_name;

        private void button1_Click(object sender, EventArgs e)
        {
            Ticket t = new Ticket();
            t.Show();
            f_num = Form7.fno;
             usr_ = Homepage.usr;
             mea1 = Form7.mea;
            snu = Form7.s_nu;
            connectDatabase();
            DataTable c_i = new DataTable();
            DataTable c_i2 = new DataTable();
            DataTable c_i3 = new DataTable();
            String ci = "select c_id from customer_login where c_user = '" + usr_ + "'";
           
            dataAdapter2 = new MySqlDataAdapter(ci, conn);
            dataAdapter2.Fill(c_i);
            String ccc = c_i.Rows[0][0].ToString();
            int cccc = Int32.Parse(ccc);

            String ci2 = "select first_name,last_name from customer where c_id = " + cccc ;
            dataAdapter3 = new MySqlDataAdapter(ci2, conn);
            dataAdapter3.Fill(c_i2);
            total_name = c_i2.Rows[0][0].ToString() + " " +  c_i2.Rows[0][1].ToString();


            String timeStamp = DateTime.Now.ToString();
            table = new DataTable();
            String command = "insert into ticket values ("+ ++i +",'"+ f_num + "','" + timeStamp + "','" + mea1 + "'," +snu+ "," +  cccc +" )";
            dataAdapter = new MySqlDataAdapter(command, conn);
            dataAdapter.Fill(table);
            b_i = i;

            String cm3 = "update flight_plan set f_cap=f_cap-1";
            dataAdapter4 = new MySqlDataAdapter(cm3, conn);
            dataAdapter4.Fill(c_i3);
            // Ticket.textBox1.Text = b_i.ToString();


        }
    }
}
