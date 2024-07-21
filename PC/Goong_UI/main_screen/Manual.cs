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
    public partial class Manual : UserControl
    {
        public Manual()
        {
            InitializeComponent();
            timer2.Start();
        }
        ~Manual()
        {
            timer2.Stop();
        }

        private void bt_FWD_Robot_Click(object sender, EventArgs e)
        {
            if(Program.AgvProcess.RunCommand != 1)
            Program.AgvProcess.RunCommand = 1;
        }
        int Input_dialog()
        {
            using (var form = new Input_screen())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    return form.VAL;
                }
                else
                    return 0;
            }
        }
        private void box_speed_MouseDown(object sender, MouseEventArgs e)
        {
            Program.AgvProcess.RunSpeed_manual = Input_dialog();
        }
        private void timer2_Tick(object sender, EventArgs e)
        {
            textbox_speed.Text = Program.AgvProcess.RunSpeed_manual.ToString();
            if(Program.AgvProcess.RunCommand == 1)
            {

            }    
        }
        private void button3_Click(object sender, EventArgs e)
        {
            if (Program.AgvProcess.RunCommand != 2)
                Program.AgvProcess.RunCommand = 2;
 
        }
        private void button12_Click(object sender, EventArgs e)
        {
            if(Program.AgvProcess.RunCommand != 3)
            Program.AgvProcess.RunCommand = 3;

        }
        private void button4_Click(object sender, EventArgs e)
        {
            if(Program.AgvProcess.Convenyor1 != 1 ) Program.AgvProcess.Convenyor1 = 1;
        }
        private void button5_Click(object sender, EventArgs e)
        {
            if(Program.AgvProcess.Convenyor1 != 2 ) Program.AgvProcess.Convenyor1 = 2;
        }
        private void button6_Click(object sender, EventArgs e)
        {
            if(Program.AgvProcess.Convenyor2 != 1 ) Program.AgvProcess.Convenyor2 = 1;
        }
        private void button9_Click(object sender, EventArgs e)
        {
            if(Program.AgvProcess.Convenyor2 != 2 ) Program.AgvProcess.Convenyor2 = 2;
        }
        private void button7_Click(object sender, EventArgs e)
        {
            if(Program.AgvProcess.Convenyor3 != 1) Program.AgvProcess.Convenyor3 = 1;
        }
        private void button10_Click(object sender, EventArgs e)
        {
            if(Program.AgvProcess.Convenyor3 != 2 ) Program.AgvProcess.Convenyor3 = 2;
        }
        private void button8_Click(object sender, EventArgs e)
        {
            if(Program.AgvProcess.Convenyor4 != 1 ) Program.AgvProcess.Convenyor4 = 1;
        }
        private void button11_Click(object sender, EventArgs e)
        {
            if(Program.AgvProcess.Convenyor4 != 2 ) Program.AgvProcess.Convenyor4 = 2;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Program.AgvProcess.RunCommand = 0;
            Program.AgvProcess.Convenyor1 = 0;
            Program.AgvProcess.Convenyor2 = 0;
            Program.AgvProcess.Convenyor3 = 0;
            Program.AgvProcess.Convenyor4 = 0;
        }

    }
}
