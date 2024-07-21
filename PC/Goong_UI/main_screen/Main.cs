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
using System.Diagnostics;
using DataAccess.Network;
using DataAccess.ASCII;
using System.IO;
using System.IO.Ports;
using System.Net;





namespace main_screen
{
    public partial class Main : Form
    {
        Manual manualscreen;
        Setting setupscreen;
        History checkscreen;
        private bool mouseUp = false;
        Thread Notice;
        private bool mouseDown;
        private Point lastLocation;
        public int i = 1;
        public int flag = 0;
        public bool flag_confirm = true;
        public Main()
        {
            //Control.CheckForIllegalCrossThreadCalls = false;
            InitializeComponent();
            manualscreen = new Manual();
            setupscreen = new Setting();
            checkscreen = new History();
            Notice = new Thread(MainLoop) { IsBackground = true };
            Notice.Start();
            timer1.Start();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Notice.Abort();
        }
        void confirm()
        {
            bool okay = false;
            while (Program.AgvProcess.bit_xacnhan_write == 0 && !okay)
            {
                using (var form = new confirmscreen())
                {
                    okay = true;
                    if (form.ShowDialog() == DialogResult.OK)
                    {

                    }

                }
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime realtime = DateTime.Now;
            Realtime.Text = realtime.ToString(" dd/MM/yyyy") + "\n " + realtime.ToString("HH : mm : ss");
            if (Program.AgvProcess.Mode == 2)
            {
                bt_Auto.BackColor = Color.Khaki;
                bt_Manu.BackColor = Color.Gainsboro;
            }
            else
            {
                bt_Manu.BackColor = Color.Khaki;
                bt_Auto.BackColor = Color.Gainsboro;
            }
        }

        private void bt_Auto_Click(object sender, EventArgs e)
        {
            Program.AgvProcess.Mode = 2;
            panel_screen_01.Controls.Clear();
            panel_screen_01.Controls.Add(panel_auto);

        }

        private void bt_Manu_Click(object sender, EventArgs e)
        {
            Program.AgvProcess.Mode = 1;
            panel_screen_01.Controls.Clear();
            panel_screen_01.Controls.Add(manualscreen);
            Program.AgvProcess.n = 0;
            Program.AgvProcess.RotoCommand = 0;
            Program.AgvProcess.DoneCommand = 0;
            Program.AgvProcess.bit_xacnhan_write = 0;

        }

        private void bt_setting_Click(object sender, EventArgs e)
        {
            panel_screen_01.Controls.Clear();
            panel_screen_01.Controls.Add(setupscreen);
        }

        private void bt_history_Click(object sender, EventArgs e)
        {
            panel_screen_01.Controls.Clear();
            panel_screen_01.Controls.Add(checkscreen);
        }
        private void MainLoop()
        {
            List<string> ErrorList = new List<string>();
            List<History> WarningList = new List<History>();

            using (StreamReader sr = new StreamReader("ERROR.txt"))
            {
                var file = sr.ReadToEnd();
                ErrorList = file.Split('\n').ToList();
            }
            while (true)
            {
                Thread.Sleep(100);
                Program.AgvProcess.status = Program.AgvProcess.STATUS;
                if (Program.AgvProcess.DoneTarget != 0)
                {
                    if (Program.AgvProcess.DoneTarget == 4)
                    {
                        cb_home.BackColor = Color.Red;
                        cb_ght.BackColor = Color.BlueViolet;
                        cb_ghd.BackColor = Color.BlueViolet;
                        cb_roto1.BackColor = Color.BlueViolet;
                        cb_roto2.BackColor = Color.BlueViolet;
                        cb_bt.BackColor = Color.BlueViolet;
                        pictureBox_agvght.Invoke((MethodInvoker)(() => pictureBox_agvght.Visible = false));
                        agv_ght.Invoke((MethodInvoker)(() => agv_ght.Visible = false));
                        agv_ghd.Invoke((MethodInvoker)(() => agv_ghd.Visible = false));
                        agv_bt.Invoke((MethodInvoker)(() => agv_bt.Visible = false));
                        agv_roto1.Invoke((MethodInvoker)(() => agv_roto1.Visible = false));
                        agv_roto2.Invoke((MethodInvoker)(() => agv_roto2.Visible = false));
                        agv_home.Invoke((MethodInvoker)(() => agv_home.Visible = true));
                        ray1.Invoke((MethodInvoker)(() => ray1.BringToFront()));
                        ray2.Invoke((MethodInvoker)(() => ray2.BringToFront()));
                        agv_home.Invoke((MethodInvoker)(() => agv_home.BringToFront()));
                    }

                    else if (Program.AgvProcess.DoneTarget == 1)
                    {
                        cb_home.BackColor = Color.BlueViolet;
                        cb_ght.BackColor = Color.BlueViolet;
                        cb_ghd.BackColor = Color.BlueViolet;
                        cb_roto1.BackColor = Color.Red;
                        cb_roto2.BackColor = Color.BlueViolet;
                        cb_bt.BackColor = Color.BlueViolet;
                        pictureBox_agvght.Invoke((MethodInvoker)(() => pictureBox_agvght.Visible = false));
                        agv_ght.Invoke((MethodInvoker)(() => agv_ght.Visible = false));
                        agv_ghd.Invoke((MethodInvoker)(() => agv_ghd.Visible = false));
                        agv_bt.Invoke((MethodInvoker)(() => agv_bt.Visible = false));
                        agv_roto1.Invoke((MethodInvoker)(() => agv_roto1.Visible = true));
                        agv_roto2.Invoke((MethodInvoker)(() => agv_roto2.Visible = false));
                        agv_home.Invoke((MethodInvoker)(() => agv_home.Visible = false));
                        ray1.Invoke((MethodInvoker)(() => ray1.BringToFront()));
                        ray2.Invoke((MethodInvoker)(() => ray2.BringToFront()));
                        agv_roto1.Invoke((MethodInvoker)(() => agv_roto1.BringToFront()));
                    }
                    else if (Program.AgvProcess.DoneTarget == 2)
                    {
                        cb_home.BackColor = Color.BlueViolet;
                        cb_ght.BackColor = Color.BlueViolet;
                        cb_ghd.BackColor = Color.BlueViolet;
                        cb_roto1.BackColor = Color.BlueViolet;
                        cb_roto2.BackColor = Color.Red;
                        cb_bt.BackColor = Color.BlueViolet;
                        pictureBox_agvght.Invoke((MethodInvoker)(() => pictureBox_agvght.Visible = false));
                        agv_ght.Invoke((MethodInvoker)(() => agv_ght.Visible = false));
                        agv_ghd.Invoke((MethodInvoker)(() => agv_ghd.Visible = false));
                        agv_bt.Invoke((MethodInvoker)(() => agv_bt.Visible = false));
                        agv_roto1.Invoke((MethodInvoker)(() => agv_roto1.Visible = false));
                        agv_roto2.Invoke((MethodInvoker)(() => agv_roto2.Visible = true));
                        agv_home.Invoke((MethodInvoker)(() => agv_home.Visible = false));
                        ray1.Invoke((MethodInvoker)(() => ray1.BringToFront()));
                        ray2.Invoke((MethodInvoker)(() => ray2.BringToFront()));
                        agv_roto2.Invoke((MethodInvoker)(() => agv_roto2.BringToFront()));
                    }
                    else if (Program.AgvProcess.DoneTarget == 3)
                    {
                        cb_home.BackColor = Color.BlueViolet;
                        cb_ght.BackColor = Color.BlueViolet;
                        cb_ghd.BackColor = Color.BlueViolet;
                        cb_roto1.BackColor = Color.BlueViolet;
                        cb_roto2.BackColor = Color.BlueViolet;
                        cb_bt.BackColor = Color.Red;
                        pictureBox_agvght.Invoke((MethodInvoker)(() => pictureBox_agvght.Visible = false));
                        agv_ght.Invoke((MethodInvoker)(() => agv_ght.Visible = false));
                        agv_ghd.Invoke((MethodInvoker)(() => agv_ghd.Visible = false));
                        agv_bt.Invoke((MethodInvoker)(() => agv_bt.Visible = true));
                        agv_roto1.Invoke((MethodInvoker)(() => agv_roto1.Visible = false));
                        agv_roto2.Invoke((MethodInvoker)(() => agv_roto2.Visible = false));
                        agv_home.Invoke((MethodInvoker)(() => agv_home.Visible = false));
                        ray1.Invoke((MethodInvoker)(() => ray1.BringToFront()));
                        ray2.Invoke((MethodInvoker)(() => ray2.BringToFront()));
                        agv_bt.Invoke((MethodInvoker)(() => agv_bt.BringToFront()));
                    }
                    else if (Program.AgvProcess.DoneTarget == 5)
                    {
                        cb_home.BackColor = Color.BlueViolet;
                        cb_ght.BackColor = Color.Red;
                        cb_ghd.BackColor = Color.BlueViolet;
                        cb_roto1.BackColor = Color.BlueViolet;
                        cb_roto2.BackColor = Color.BlueViolet;
                        cb_bt.BackColor = Color.BlueViolet;
                        pictureBox_agvght.Invoke((MethodInvoker)(() => pictureBox_agvght.Visible = true));
                        agv_ght.Invoke((MethodInvoker)(() => agv_ght.Visible = false));
                        agv_ghd.Invoke((MethodInvoker)(() => agv_ghd.Visible = false));
                        agv_bt.Invoke((MethodInvoker)(() => agv_bt.Visible = false));
                        agv_roto1.Invoke((MethodInvoker)(() => agv_roto1.Visible = false));
                        agv_roto2.Invoke((MethodInvoker)(() => agv_roto2.Visible = false));
                        agv_home.Invoke((MethodInvoker)(() => agv_home.Visible = false));
                        ray1.Invoke((MethodInvoker)(() => ray1.BringToFront()));
                        ray2.Invoke((MethodInvoker)(() => ray2.BringToFront()));
                        pictureBox_agvght.Invoke((MethodInvoker)(() => pictureBox_agvght.BringToFront()));
                    }
                    else if (Program.AgvProcess.DoneTarget == 6)
                    {
                        cb_home.BackColor = Color.BlueViolet;
                        cb_ght.BackColor = Color.BlueViolet;
                        cb_ghd.BackColor = Color.Red;
                        cb_roto1.BackColor = Color.BlueViolet;
                        cb_roto2.BackColor = Color.BlueViolet;
                        cb_bt.BackColor = Color.BlueViolet;
                        pictureBox_agvght.Invoke((MethodInvoker)(() => pictureBox_agvght.Visible = false));
                        agv_ght.Invoke((MethodInvoker)(() => agv_ght.Visible = false));
                        agv_ghd.Invoke((MethodInvoker)(() => agv_ghd.Visible = true));
                        agv_bt.Invoke((MethodInvoker)(() => agv_bt.Visible = false));
                        agv_roto1.Invoke((MethodInvoker)(() => agv_roto1.Visible = false));
                        agv_roto2.Invoke((MethodInvoker)(() => agv_roto2.Visible = false));
                        agv_home.Invoke((MethodInvoker)(() => agv_home.Visible = false));
                        ray1.Invoke((MethodInvoker)(() => ray1.BringToFront()));
                        ray2.Invoke((MethodInvoker)(() => ray2.BringToFront()));
                        agv_ghd.Invoke((MethodInvoker)(() => agv_ghd.BringToFront()));
                    }
                    else { }
                }
                else { }
                if (Program.AgvProcess.Direction == 0)
                {
                    label_dc.Invoke((MethodInvoker)(() => label_dc.Text = " AGV đang dừng"));
                    pictureBox_direction.Image = null;
                }
                else if (Program.AgvProcess.Direction == 1)
                {
                    label_dc.Invoke((MethodInvoker)(() => label_dc.Text = " AGV đang đi tiến"));
                    pictureBox_direction.Image = global::main_screen.Properties.Resources.Capture1213;
                }
                else if (Program.AgvProcess.Direction == 2)
                {
                    label_dc.Invoke((MethodInvoker)(() => label_dc.Text = " AGV đang đi lùi"));
                    pictureBox_direction.Image = global::main_screen.Properties.Resources.Capture1214;
                }
                else { }
                txtInfo.Invoke((MethodInvoker)(() => txtInfo.Text = Program.AgvProcess.Info()));
                txtTaskInfo.Invoke((MethodInvoker)(() => txtTaskInfo.Text = Program.AgvProcess.TaskInfo()));
                if (Program.AgvProcess.Mode == 2)
                {
                    if (Program.AgvProcess.bit_xacnhan_read == 1 && Program.AgvProcess.bit_xacnhan_write == 0 && flag_confirm)
                    {
                        flag_confirm = false;
                        confirm();
                        Thread.Sleep(1000);
                    }
                    if (Program.AgvProcess.bit_xacnhan_write != 0)
                    {
                        flag_confirm = true;
                    }

                }
                if (!Program.AgvProcess.DELTA.Connected)
                {
                    txtStatus.Invoke((MethodInvoker)(() => txtStatus.Text = "Mất kết nối PLC"));
                    txtStatus.Invoke((MethodInvoker)(() => txtStatus.BackColor = Color.Red));
                }
                else if (Program.AgvProcess.Error > 0)
                {

                    try
                    {
                        flag++;
                        txtStatus.Invoke((MethodInvoker)(() => txtStatus.Text = ErrorList[Program.AgvProcess.Error]));
                        txtStatus.Invoke((MethodInvoker)(() => txtStatus.BackColor = Color.Red));
                        if (flag == 1)
                        {
                            string save = i.ToString() + "^" + txtStatus.Text + "^" + DateTime.Now.ToString(); //i.ToString() + "^" +
                            using (StreamWriter sw = File.AppendText("History1.ini"))
                            {
                                sw.WriteLine(save);
                            }
                            i = i + 1;
                            if (i > 2500)
                            {
                                File.WriteAllText("History1.ini", string.Empty);
                                i = 0;
                            }
                        }
                    }
                    catch
                    {
                    }
                }
                else
                {
                    if (Program.AgvProcess.Error == 0)
                    {
                        flag = 0;
                        txtStatus.Invoke((MethodInvoker)(() => txtStatus.Text = "Good AGV"));
                        txtStatus.Invoke((MethodInvoker)(() => txtStatus.BackColor = Color.LightGreen));
                    }
                }

                if (Program.AgvProcess.n != 0)
                {
                    Program.AgvProcess.RotoCommand = Program.AgvProcess.n;
                    Program.AgvProcess.n = 0;
                }
                if (Program.AgvProcess.RotoCommand == 1)
                {
                    Program.AgvProcess.statusagv_roto = "Nhận lệnh máy Roto1 tới cấp tray";
                }
                else if (Program.AgvProcess.RotoCommand == 2)
                {
                    Program.AgvProcess.statusagv_roto = " Nhận lệnh máy Roto1 tới lấy tray";
                }
                else if (Program.AgvProcess.RotoCommand == 3)
                {
                    Program.AgvProcess.statusagv_roto = "Nhận lệnh máy Roto2 tới cấp tray";
                }
                else if (Program.AgvProcess.RotoCommand == 4)
                {
                    Program.AgvProcess.statusagv_roto = "Nhận lệnh máy Roto2 tới lấy tray";
                }
                else if (Program.AgvProcess.RotoCommand == 6)
                {
                    Program.AgvProcess.statusagv_roto = "Nhận lệnh băng tải đơn tới cấp tray";
                }
                else if (Program.AgvProcess.RotoCommand == 7)
                {
                    Program.AgvProcess.statusagv_roto = "Nhận lệnh băng tải đơn tới lấy tray";
                }
                else if (Program.AgvProcess.RotoCommand == 5)
                {
                    Program.AgvProcess.statusagv_roto = "Về Home";
                }
                else { Program.AgvProcess.statusagv_roto = "Free"; }

                if (Program.AgvProcess.statusmiddle != Program.AgvProcess.status)
                {
                    Program.AgvProcess.statuschange = true;
                    Program.AgvProcess.statusmiddle = Program.AgvProcess.status;
                }
                else
                {
                    Program.AgvProcess.statuschange = false;
                }
                bool[] Sick_status = Program.AgvProcess.Sick;
            }

        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                this.Location = new Point(
                    (this.Location.X - lastLocation.X) + e.X, (this.Location.Y - lastLocation.Y) + e.Y);

                this.Update();
            }
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            lastLocation = e.Location;
        }

        private void bt_rst_Click(object sender, EventArgs e)
        {
            Program.AgvProcess.Error_Reset = 1;
        }

        private void bt_Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
