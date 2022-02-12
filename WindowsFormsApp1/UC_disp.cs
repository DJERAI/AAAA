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
    public partial class UC_disp : UserControl
    {
        public UC_disp()
        {
            InitializeComponent();
        }
        
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            uC_client1.Visible = radioButton1.Checked;
            uC_dfd1.Visible = radioButton2.Checked;
            
        }

        private void UC_disp_Load(object sender, EventArgs e)
        {

        }
    }
}
