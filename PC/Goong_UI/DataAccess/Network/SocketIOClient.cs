using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SocketIOClient;
using System.Threading;
using System.Net.NetworkInformation;
using System.Windows.Forms;
using System.IO;
using System.Net.Sockets;

namespace DataAccess.Network
{
    public abstract class SocketIOClient11
    {
        SocketIO socketclient; // khai báo SocketIO

        public Thread luongSocketIO;

        public bool Isconnect = false;

        public bool statuschange = false;

        public int statusmiddle;

        public int status;

        public string statusagv_roto = null;

        public int flag_change;

        public int n = 0;
        public static bool Sendmac;
        private string Socket;
        public static string GetMacAddress()
        {
            string macAddress = "";
            foreach (NetworkInterface nic in NetworkInterface.GetAllNetworkInterfaces())
            {
                if (nic.OperationalStatus == OperationalStatus.Up && !nic.Description.ToLower().Contains("virtual") && !nic.Description.ToLower().Contains("pseudo"))
                {
                    if (nic.NetworkInterfaceType == NetworkInterfaceType.Wireless80211) // Check if it's a Wi-Fi interface
                    {
                        byte[] macBytes = nic.GetPhysicalAddress().GetAddressBytes();
                        macAddress = string.Join(":", macBytes.Select(b => b.ToString("X2")));
                        break;
                    }
                }
            }
            return macAddress;
        }
        public SocketIOClient11()
        {
            luongSocketIO = new Thread(LoopSocketIO) { IsBackground = true };
        }
        public void Connect()
        {
            string json = File.ReadAllText("config.txt");
            var data_Setting = System.Text.Json.JsonSerializer.Deserialize<Dictionary<string, string>>(json);
            Socket = data_Setting["Socket"];
            luongSocketIO.Start();
        }
        public async void LoopSocketIO()
        {
            SocketIO socketclient = new SocketIO(Socket);
            while (true)
            {
                try
                {
                    if (!Isconnect)
                    {
                        await socketclient.ConnectAsync();
                        Isconnect = true;
                        Thread.Sleep(100);
                    }
                    socketclient.OnConnected += (eventSender, eventArgs) =>
                    {
                        Sendmac = false;
                    };
                    socketclient.OnDisconnected += (eventSender, eventArgs) =>
                    {
                        Isconnect = false;
                        // socketclient.DisconnectAsync();
                    };
                    if (Isconnect)
                    {
                        if (Sendmac == false)
                        {
                            var mac = new
                            {
                                mac = GetMacAddress(),
                            };
                            await socketclient.EmitAsync("connect-machine", mac);
                            var data = new
                            {
                                mac = GetMacAddress(),
                                status,
                            };
                            await socketclient.EmitAsync("machine-status", data);
                            Sendmac = true;
                        }
                        if (statuschange)
                        {
                            flag_change++;
                            if (flag_change == 1)
                            {
                                var data = new
                                {
                                    mac = GetMacAddress(),
                                    status,
                                };
                                await socketclient.EmitAsync("machine-status", data);
                            }
                        }
                        else
                        {
                            flag_change = 0;
                        }
                        Thread.Sleep(100);
                    }
                    socketclient.On("command-tranfer", response =>
                    {
                        string text = response.ToString();
                        Dictionary<string, object>[] objects = System.Text.Json.JsonSerializer.Deserialize<Dictionary<string, object>[]>(text);
                        if ((String.Compare(objects[0]["machine_id"].ToString(), "1") == 0) && (String.Compare(objects[0]["type"].ToString(), "1") == 0))
                        {
                            n = 1;
                        }
                        else if (objects[0]["machine_id"].ToString() == "1" && objects[0]["type"].ToString() == "2")
                        {
                            n = 2;
                        }
                        else if (objects[0]["machine_id"].ToString() == "2" && objects[0]["type"].ToString() == "1")
                        {
                            n = 3;
                        }
                        else if (objects[0]["machine_id"].ToString() == "2" && objects[0]["type"].ToString() == "2")
                        {
                            n = 4;
                        }
                        else if (objects[0]["machine_id"].ToString() == "3" && objects[0]["type"].ToString() == "1")
                        {
                            n = 6;
                        }
                        else if (objects[0]["machine_id"].ToString() == "3" && objects[0]["type"].ToString() == "2")
                        {
                            n = 7;
                        }
                        else if ((String.Compare(objects[0]["type"].ToString(), "3") == 0))
                        {
                            n = 5;
                        }
                        else { }
                    });
                }
                catch
                {
                }
            }

        }


    }
}
