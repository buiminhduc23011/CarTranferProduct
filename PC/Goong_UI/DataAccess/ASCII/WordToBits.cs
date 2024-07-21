using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.ASCII
{
    public class WordToBits
    {
        static public bool[] ToBits(int input, int numberOfBits)
        {
            return Enumerable.Range(0, numberOfBits)
            .Select(bitIndex => 1 << bitIndex)
            .Select(bitMask => (input & bitMask) == bitMask)
            .Reverse().ToArray();
        }
    }
}

