using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public interface iAGVDataController
    {
        int RunCommand { get; set; }
        int RunSpeed { get; set; }
        int RunSpeed_manual { get; set; }
        int Distance_roto1_target { get; set; }
        int Distance_roto2_target { get; set; }
        int Distance_bt_target { get; set; }
        int Distance_Set { get; set; }
        int Error { get; }
        int Error_Reset { set; }
        int RotoCommand { get; set; }
        int DoneCommand { get; set; }
        int Direction { get; set; }
        int Mode { get; set; }
        int Convenyor1 { get; set; }
        int Convenyor2 { get; set; }
        int Convenyor3 { get; set; }
        int Convenyor4 { get; set; }
        int test_Toyov1 { get; set; }
        int bit_xacnhan_read { get; set; }
        int bit_xacnhan_write { get; set; }
        int stop { get; set; }
        int led { get; set; }
        int loa { get; set; }
        int Target { get; set; }
        int traytrong { get; set; }
        bool[] Sick { get; }
    }
}
