using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using BusinessLayer;
using System.IO.Ports;
using System.Net.Sockets;
using System.IO;
namespace main_screen
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            string json = File.ReadAllText("config.txt");
            var data_Setting = System.Text.Json.JsonSerializer.Deserialize<Dictionary<string, string>>(json);
            AgvProcess = new AGVProcess(data_Setting["COM"]);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Main());
            Thread.Sleep(100);
        }
        public static AGVProcess AgvProcess;
        static string[] ports = SerialPort.GetPortNames();
    }
}

