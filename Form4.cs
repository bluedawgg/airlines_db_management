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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form5 form = new Form5();
            form.ShowDialog();
            Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Hide();
            Form14 form = new Form14();
            form.ShowDialog();
            Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Hide();
            Form12 form = new Form12();
            form.ShowDialog();
            Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Hide();
            Homepage form = new Homepage();
            form.ShowDialog();
            Show();
        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }
    }
}
