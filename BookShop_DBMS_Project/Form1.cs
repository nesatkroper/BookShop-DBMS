using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookShop_DBMS_Project
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        bool done = false;

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            timer1.Interval = 10;
            if (panel1.Width > 50 && !done)
            {
                panel1.Width -= 10;
                if (panel1.Width == 50)
                {
                    timer1.Stop();
                    done = true;
                }
            }
            if (panel1.Width == 50 && done)
            {
                panel1.Width += 10;
                if (panel1.Width == 250)
                {
                    timer1.Stop();
                    done = false;
                }
            }
        }
    }
}
