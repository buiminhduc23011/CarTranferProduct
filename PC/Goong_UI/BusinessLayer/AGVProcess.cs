using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Network;
using DataAccess.ASCII;
using System.IO.Ports;

namespace BusinessLayer
{
    public class AGVProcess : SocketIOClient11, iAGVDataController
    {
        public ascii DELTA;
        public AGVProcess(string com)
        {
            try
            {
                DELTA = new ascii(com, 9600, Parity.Even, 7, StopBits.One, 1, 100);
                base.Connect();
            }
            catch
            {

            }
        }
        ~AGVProcess()
        {

        }
        public int RunCommand { get { return DELTA.READ(10); } set { DELTA.WRITE(10, value); } }
        public int RunSpeed { get { return DELTA.READ(50); } set { DELTA.WRITE(50, value); } }
        public int RunSpeed_manual { get { return DELTA.READ(6); } set { DELTA.WRITE(6, value); } }
        public int Distance_roto1_target { get { return DELTA.READ(62); } set { DELTA.WRITE(62, value); } }
        public int Distance_roto2_target { get { return DELTA.READ(64); } set { DELTA.WRITE(64, value); } }
        public int Distance_bt_target { get { return DELTA.READ(66); } set { DELTA.WRITE(66, value); } }
        public int Distance_Set { get { return DELTA.READ(30); } set { DELTA.WRITE(30, value); } }
        public int Distance { get { return DELTA.READ(2); } set { DELTA.WRITE(2, value); } }
        public int Error { get { return DELTA.READ(31); } set { DELTA.WRITE(31, value); } }
        public int Error_Reset  { get { return DELTA.READ(44); } set { DELTA.WRITE(44, value); } }
        public int RotoCommand { get { return DELTA.READ(38); } set { DELTA.WRITE(38, value); } }
        public int Command_Real { get { return DELTA.READ(39); } set { DELTA.WRITE(39, value); } }
        public int DoneCommand { get { return DELTA.READ(42); } set { DELTA.WRITE(42, value); } }
        public int DoneTarget { get { return DELTA.READ(39); } set { DELTA.WRITE(39, value); } }
        public int Direction { get { return DELTA.READ(28); } set { DELTA.WRITE(28, value); } }
        public int Mode { get { return DELTA.READ(4); } set { DELTA.WRITE(4, value); } }
        public int Convenyor1{ get { return DELTA.READ(11); } set { DELTA.WRITE(11, value); } }
        public int Convenyor2{ get { return DELTA.READ(12); } set { DELTA.WRITE(12, value); } }
        public int Convenyor3 { get { return DELTA.READ(13); } set { DELTA.WRITE(13, value); } }
        public int Convenyor4 { get { return DELTA.READ(14); } set { DELTA.WRITE(14, value); } }
        public int test_Toyov1 { get { return DELTA.READ(41); } set { DELTA.WRITE(41, value); } }
        public int bit_xacnhan_read { get { return DELTA.READ(45); } set { DELTA.WRITE(45, value); } }
        public int bit_xacnhan_write { get { return DELTA.READ(46); } set { DELTA.WRITE(46, value); } }
        public int stop { get { return DELTA.READ(5); } set { DELTA.WRITE(5, value); } }
        public int led { get { return DELTA.READ(15); } set { DELTA.WRITE(15, value); } }
        public int loa { get { return DELTA.READ(16); } set { DELTA.WRITE(16, value); } }
        public int Target { get { return DELTA.READ(68); } set { DELTA.WRITE(68, value); } }
        public int traytrong { get { return DELTA.READ(96); } set { DELTA.WRITE(96, value); } }
        public int STATUS { get { return DELTA.READ(29); } set { DELTA.WRITE(29, value); } }
        public bool[] Sick
        {
            get
            {
                return WordToBits.ToBits(DELTA.READ(60), 16);
            }
        }
        public string TaskInfo()
        {

            string I = "\r\nKết nối: " + base.Isconnect.ToString();
            if (Command_Real == 0)
            {
                I += "\r\nLệnh thực hiện: " + "Không có lệnh";
            }
            if (Command_Real == 1)
            {
                I += "\r\nLệnh thực hiện: " + "Cấp Tray Máy Roto No.1";
            }
            if (Command_Real == 2)
            {
                I += "\r\nLệnh thực hiện: " + "Lấy Tray Trống Máy Roto No.1";
            }
            if (Command_Real == 3)
            {
                I += "\r\nLệnh thực hiện: " + "Cấp Tray Máy Roto No.2";
            }
            if (Command_Real == 4)
            {
                I += "\r\nLệnh thực hiện: " + "Lấy Tray Trống Máy Roto No.2";
            }
            return I;
        }
        public string Info()
        {
            string I = "Lệnh: " + Command_Real.ToString() + "/" + RotoCommand.ToString() + "/" + Mode.ToString() +  "\t\tTốc độ: " + RunSpeed.ToString();
            I += "\r\nKhoảng cách: " + Distance.ToString();
            I += "\r\nSick trước: " + Sick[11].ToString() + "/" + Sick[10].ToString() + "/" + Sick[9].ToString();
            I += "\r\nSick sau: " + Sick[8].ToString() + "/" + Sick[7].ToString() + "/" + Sick[6].ToString();
            I += "\r\nTrạng thái băng tải: "+ Sick[15].ToString()+ "/"+ Sick[14].ToString()+"/"+Sick[13].ToString()+"/"+Sick[12].ToString();
            return I;
        }
    }
}
