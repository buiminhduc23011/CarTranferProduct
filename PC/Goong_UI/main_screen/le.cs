using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace main_screen
{
    internal class le
    {
        static public string Read(string filename)
        {
            try
            {
                using (StreamReader sr = new StreamReader(filename))
                {
                    var file = sr.ReadToEnd();
                    string FF = file;
                    return FF;
                }
            }
            catch
            {
                return null;
            }
        }
        static public bool Save(string message, string filename)
        {
            try
            {
                using (StreamWriter sr = new StreamWriter(filename))
                {
                    sr.Write(message);
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
        static public void WriteNewRow(string message, string filename)
        {
            StreamWriter sw = null;
            try
            {
                sw = new StreamWriter(AppDomain.CurrentDomain.BaseDirectory + "\\" + filename, true);
                sw.WriteLine(message);
                sw.Flush();
                sw.Close();
            }
            catch
            {
            }
        }
        static string[] EL = Read("Error_code.txt").Split('\n');
        static public string Error(short E1)
        {
            List<bool> list = new List<bool>();
            list.AddRange(ToBits(E1, 16));
            string Re = "Lỗi chưa khai báo";
            try
            {
                for (int i = 0; i < list.Count; i++)
                {
                    if (list[i] && EL.Length > i)
                    {
                        Re = EL[i];
                    }
                }
            }
            catch (Exception e)
            {
                Re = "mã lỗi " + E1.ToString() + "     " + e.ToString();
            }
            return Re;
        }
        static bool[] ToBits(int input, int numberOfBits)
        {
            return Enumerable.Range(0, numberOfBits)
            .Select(bitIndex => 1 << bitIndex)
            .Select(bitMask => (input & bitMask) == bitMask)
            .ToArray();
        }
    }

}
