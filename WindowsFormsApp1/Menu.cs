using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            uC_Cars2.BringToFront();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            uC_Drivers2.BringToFront();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            uС_MainMenu2.BringToFront();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            uCorder2.BringToFront();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            uC_disp2.BringToFront();
            
        }

      
    }
}
