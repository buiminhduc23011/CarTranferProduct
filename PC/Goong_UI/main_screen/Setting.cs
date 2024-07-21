using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Configuration;
using System.Text.Json.Serialization;

namespace main_screen
{
    public partial class Setting : UserControl
    {
        public Setting()
        {
            InitializeComponent();
            Load += LoadHandler;  // Thêm sự kiện Load
            timer3.Start();
        }

        private void LoadHandler(object sender, EventArgs e)
        {
            string json = File.ReadAllText("config.txt");
            var data_Setting = System.Text.Json.JsonSerializer.Deserialize<Dictionary<string, string>>(json);
            txb_COM.Text = data_Setting["COM"];
            textBox_IP.Text = data_Setting["IP"];
            textBox_PORT.Text = data_Setting["Port"];
        }
        ~Setting()
        {
            timer3.Stop();
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
        string Input_string_dialog()
        {
            using (var form = new Input_screen())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    return form.VAL_string;
                }
                else
                    return "0";
            }
        }
        private void timer3_Tick(object sender, EventArgs e)
        {
            textBox_poisitionroto1.Text = Program.AgvProcess.Distance_roto1_target.ToString();
            textBox_poisitionroto2.Text = Program.AgvProcess.Distance_roto2_target.ToString();
            textBox_poisitionbt.Text = Program.AgvProcess.Distance_bt_target.ToString();
        }
        private void textBox_poisitionroto1_MouseDown(object sender, MouseEventArgs e)
        {
            Program.AgvProcess.Distance_roto1_target = Input_dialog();
        }
        private void textBox_poisitionroto2_MouseDown(object sender, MouseEventArgs e)
        {
            Program.AgvProcess.Distance_roto2_target = Input_dialog();
        }

        private void textBox_poisitionbt_MouseDown(object sender, MouseEventArgs e)
        {
            Program.AgvProcess.Distance_bt_target = Input_dialog();
        }

        private void bt_Save_Click(object sender, EventArgs e)
        {
            Program.AgvProcess.Distance_Set = 1;
            try
            {
                File.WriteAllText("config.txt", String.Empty);
                object data_Setting = new
                {
                    Socket = "http://" + textBox_IP.Text + ":" + textBox_PORT.Text + "/",
                    IP = textBox_IP.Text,
                    Port = textBox_PORT.Text,
                    COM = txb_COM.Text,

                };
                string json = System.Text.Json.JsonSerializer.Serialize(data_Setting);
                File.WriteAllText("config.txt", json);
                
            }
            catch { }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (Program.AgvProcess.loa != 1) Program.AgvProcess.loa = 1;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (Program.AgvProcess.loa != 2) Program.AgvProcess.loa = 2;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Program.AgvProcess.led != 1) Program.AgvProcess.led = 1;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (Program.AgvProcess.led != 2) Program.AgvProcess.led = 2;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (Program.AgvProcess.led != 3) Program.AgvProcess.led = 3;
        }
        private void setup_screen_Load(object sender, EventArgs e)
        {
                try
                {
                    using (StreamReader sr = new StreamReader("config.txt"))
                    {
                        string config;
                        if (((config = sr.ReadToEnd()) != null))
                        {
                            var data_config = config.Split('^').ToList();
                        }
                    }
                }
                catch { }
        }

    }
}
