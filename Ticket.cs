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
    public partial class Ticket : Form
    {
        public Ticket()
        {
            InitializeComponent();
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        public void Ticket_Load(object sender, EventArgs e)
        {
            
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = Payment_final.b_i.ToString();
            textBox2.Text = Payment_final.total_name;
            textBox3.Text = Payment_final.mea1;
            textBox4.Text = Payment_final.f_num;
            textBox5.Text = Form7.d;
            textBox6.Text = Form7.d__t;
            textBox7.Text = Form7.f;
            textBox8.Text = Form7.t;
            textBox9.Text = Form7.a__t;
            textBox10.Text = DateTime.Now.ToString();

        }
    }
}
