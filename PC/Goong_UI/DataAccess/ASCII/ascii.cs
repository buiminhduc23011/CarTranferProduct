using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;
using System.Threading;

namespace DataAccess.ASCII
{
    public class Data
    {
        public int addr { get; set; }
        public int value { get; set; }
        public Data(int addr, int value)
        {
            this.addr = addr;
            this.value = value;
        }
        ~Data()
        {

        }
    }
    public class ascii
    {
        SerialPort myport;
        public string Re = "";
        public bool busy = false;
        public int Timeout = 0;
        public string send = "";
        public bool Connected = false;
        public Queue<Data> queueMb;
        public ascii(string comport, int baudrate, Parity par, int dataBits, StopBits stopbit, int startReg, int Len)
        {
            DD = new int[Len];
            queueMb = new Queue<Data>();
            start_Add = startReg;
            myport = new SerialPort(comport, baudrate, par, dataBits, stopbit);
            myport.ReadTimeout = 800;
            myport.Handshake = Handshake.None;
            if (myport.IsOpen != true) try { myport.Open(); }
                catch { }
            O = new Thread(loop);
            O.IsBackground = true;
            O.Start();
        }
        ~ascii()
        {
            myport.Close();
            O.Join();
        }
        int begin = -1;
        public int[] ReadReg(int address, int length)
        {
            if (myport.IsOpen != true)
            {
                try
                {
                    myport.Close();
                    myport.Open();
                }
                catch
                {
                    Connected = false;
                }
                return null;
            }
            else
            {
                busy = false;
            }
            if (!busy)
            {
                busy = true;
                try
                {
                    string F = ":0103";
                    int addd = address + 4096;
                    F += int24char(addd);
                    F += int24char(length);
                    int sum = -(4 + addd / 256 + addd % 256 + length / 256 + length % 256);
                    F += sum.ToString("x").ToUpper().Substring(6, 2);
                    send = F;
                    F += "\r\n";
                    Send(F);
                    try
                    {
                        Re = myport.ReadLine();
                    }
                    catch
                    {
                        Connected = false;
                        return null;
                    }
                    begin = Re.LastIndexOf(":");
                    if (begin >= 0 && Re.Length > 4 + begin && Re[4] + begin == '3' && Re.Length + begin >= length * 4 + 7) // day la phan hoi cho lenh doc va độ dài  đủ
                    {
                        string d = Re.Substring(7 + begin, length * 4); // lay ky tu tu sau header độ dài = length
                        int[] result = new int[length];
                        for (int i = 0; i < length; i++)
                        {
                            result[i] = T4byte(d.Substring(i * 4, 4));
                        }
                        Connected = true;
                        busy = false;
                        return result;
                    }
                    else
                    {
                        Connected = false;
                    }
                }
                catch (TimeoutException ex)
                {
                    send = "Read EX  : " + ex.ToString();
                    Connected = false;
                }
                busy = false;
            }
            return null;
        }
        public bool Write_S_Reg(int address, int Data)
        {
            if (!busy)
            {
                busy = true;
                try
                {
                    if (Data < 0)
                    {
                        Data += ushort.MaxValue + 1;
                    }
                    int aadd = address + 4096;
                    string F = ":0106";
                    F += int24char(aadd);
                    F += int24char(Data);
                    int sum = -(7 + aadd / 256 + aadd % 256 + Data / 256 + Data % 256);
                    F += sum.ToString("x").ToUpper().Substring(6, 2);
                    send = F;
                    F += "\r\n";
                    Re = "";
                    Send(F);
                    Re = myport.ReadLine();
                    begin = Re.LastIndexOf(":");
                    if (begin >= 0 && Re != "" && Re.Length > 3 + begin)
                    {
                        busy = false;
                        return true;
                    }
                }
                catch (Exception ex)
                {
                    send = "Write S EX  : " + ex.ToString(); Connected = false;
                }
                busy = false;
            }
            return false;
        }
        public bool Write_M_Reg(int address, int[] data)
        {

            if (!busy)
            {
                busy = true;
                try
                {
                    int aadd = address + 4096;
                    string F = ":0110";
                    F += int24char(aadd);
                    int sum = 17 + aadd / 256 + aadd % 256; // sum add
                    F += int24char(data.Length);
                    sum += data.Length / 256 + data.Length % 256; // sum reg number
                    if (data.Length * 2 < 16)
                    {
                        F += "0" + (data.Length * 2).ToString("x").ToUpper();
                    }
                    else
                    {
                        F += (data.Length * 2).ToString("x").ToUpper();
                    }
                    sum += data.Length * 2; //sum byte count
                    for (int i = 0; i < data.Length; i++)
                    {
                        if (data[i] < 0)
                        {
                            data[i] += ushort.MaxValue + 1;
                        }
                        F += int24char(data[i]);
                        sum += data[i] / 256 + data[i] % 256;
                    }
                    F += (-sum).ToString("x").ToUpper().Substring(6, 2);
                    send = F;
                    F += "\r\n";
                    Send(F);
                    Re = myport.ReadLine();
                    begin = Re.LastIndexOf(":");
                    if (begin >= 0 && Re != "" && Re.Length > 3 + begin)
                    {
                        busy = false;
                        return true;
                    }
                }
                catch (Exception ex)
                {
                    send = "Write M EX  : " + ex.ToString(); Connected = false;
                }
                busy = false;
            }
            return false;
        }
        void Send(string data)
        {
            Re = "";
            begin = -1;
            myport.Write(data);
        }
        string int24char(int dec)
        {
            string F = "";
            int DecH = dec / 256;
            if (DecH == 0)
            {
                F += "00";
            }
            else if (DecH < 16)
            {
                F += "0" + DecH.ToString("x").ToUpper();
            }
            else
            {
                F += DecH.ToString("x").ToUpper();
            }
            int DecL = dec % 256;
            if (DecL == 0)
            {
                F += "00";
            }
            else if (DecL < 16)
            {
                F += "0" + DecL.ToString("x").ToUpper();
            }
            else
            {
                F += DecL.ToString("x").ToUpper();
            }
            return F;
        }
        int T4byte(string ascii)
        {
            return int.Parse(ascii, System.Globalization.NumberStyles.HexNumber);
        }
        Thread O;
        int start_Add = 0;
        int WMA = -1;
        int[] ValM;
        public int[] DD;
        void loop()
        {
            while (true)
            {
                if (queueMb.Count > 0)
                {
                    Data Item = queueMb.Dequeue();
                    Write_S_Reg(Item.addr, Item.value);
                    Thread.Sleep(100);
                }
                int[] Datafa = ReadReg(start_Add, DD.Length);
                if (Datafa != null && Datafa.Length == DD.Length)
                {
                    DD = Datafa;
                }
                Thread.Sleep(100);
                if (WMA >= 0)
                {
                    Write_M_Reg(WMA, ValM);
                    WMA = -1;
                    Thread.Sleep(100);
                }
            }
        }
        public int READ(int add)
        {
            return DD[add - start_Add];
        }
        public void WRITE(int ADD, int VAL)
        {
            Data Item = new Data(ADD, VAL);
            queueMb.Enqueue(Item);
        }
        public void WRITE_M(int ADD, int[] VAL)
        {
            WMA = ADD;
            ValM = VAL;
        }

        public int WriteDataIsDone()
        {
            return queueMb.Count;
        }
    }

}
