using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.IO;

namespace main_screen
{

    public partial class History : UserControl
    { 
        public string copy;
        public int y = 1;
        public History()
        {
            InitializeComponent();
            dgv_alarm.RowHeadersVisible = true;
            this.Load += UserControl_Load;
            this.Disposed += UserControl_Unload;
            
        }

        private void UserControl_Load(object sender, EventArgs e)
        {
            timer5.Start();
            panel1.Controls.Clear();
            panel1.Controls.Add(dgv_alarm);
            dgv_alarm.Rows.Clear();
            load();

        }

        private void UserControl_Unload(object sender, EventArgs e)
        {
            timer5.Stop();
        }

        private void timer5_Tick(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            panel1.Controls.Add(dgv_alarm);
            dgv_alarm.Rows.Clear();
            load();
        }
        private void load()
        {
            for (int i = 0; i < dgv_alarm.Columns.Count; i++)
            {
                dgv_alarm.Columns[0].Width = (dgv_alarm.Size.Width - 15) / dgv_alarm.Columns.Count;
            }
            if (dgv_alarm.Columns.Count < 3)
            {
                dgv_alarm.Columns.Add("STT", "STT");
                dgv_alarm.Columns.Add("Nguyên nhân lỗi", "Nguyên nhân lỗi");
                dgv_alarm.Columns.Add("Thời gian lỗi", "Thời gian lỗi");
            }
            {
                string HTR1 = le.Read("History1.ini");
                string[] row1 = HTR1.Split('\n');

                for (int i = row1.Length-1; i >= 0; i--)
                {
                  string[] E4 = row1[i].Split('^');
                    if (E4.Length > 1)
                    {  
                        dgv_alarm.Rows.Add(i-1, E4[1], E4[2]);
                    }
                }
            }
        }

    }
}
