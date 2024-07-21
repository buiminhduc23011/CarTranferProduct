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
    public partial class Input_screen : Form
    {
        public int VAL
        {
            get; set;
        }
        public string VAL_string
        {
            get; set;
        }
        public Input_screen()
        {
            InitializeComponent();
            button10.Click += new System.EventHandler(this.IN);
            button2.Click += new System.EventHandler(this.IN);
            button3.Click += new System.EventHandler(this.IN);
            button4.Click += new System.EventHandler(this.IN);
            button5.Click += new System.EventHandler(this.IN);
            button6.Click += new System.EventHandler(this.IN);
            button7.Click += new System.EventHandler(this.IN);
            button8.Click += new System.EventHandler(this.IN);
            button9.Click += new System.EventHandler(this.IN);
            button14.Click += new System.EventHandler(this.IN);
            button13.Click += new System.EventHandler(this.IN);
            button12.Click += new System.EventHandler(this.IN);
        }
        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                VAL_string = txtInput.Text;
                VAL = Convert.ToInt32(txtInput.Text);
            }
            catch
            {

            }
            Close();
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void IN(object sender, EventArgs e)
        {
            Button D = (Button)sender;
            txtInput.Text += D.Text;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtInput.Text = "";
        }
    }
    
}
