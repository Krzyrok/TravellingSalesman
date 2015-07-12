using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravellingSalesman
{
    public class Position
    {
        public int X { get; private set; }
        public int Y { get; private set; }

        public Position(int x, int y)
        {
            if (x < 0 || x > 500 || y < 0 || y > 500)
            {
                throw new ArgumentException("X or Y value is wrong - only in the range <0, 500>");
            }

            X = x;
            Y = y;
        }
    }
}
