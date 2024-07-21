using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace main_screen
{
    public partial class confirmscreen : Form
    {
        public confirmscreen()
        {
            InitializeComponent();
            button1.Click += new System.EventHandler(this.IN);
            button2.Click += new System.EventHandler(this.IN);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //if (Program.AgvProcess.bit_xacnhan_write != 2 )
                Program.AgvProcess.bit_xacnhan_write = 2;
            if (Program.AgvProcess.bit_xacnhan_write == 2)
            { button1.BackColor = Color.Khaki; }
            else
                button1.BackColor = Color.LightGray;
            Close();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            //if (Program.AgvProcess.bit_xacnhan_write != 3)
                Program.AgvProcess.bit_xacnhan_write = 3;
            if (Program.AgvProcess.bit_xacnhan_write == 3)
            { button2.BackColor = Color.Khaki; }
            else
                button2.BackColor = Color.LightGray;
                Close();
        }
        private void IN(object sender, EventArgs e)
        {
            Button D = (Button)sender;
        }
    }
}
