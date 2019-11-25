using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TacticRPG
{
    [System.Serializable]
    public struct Coordinate
    {
        public int x;
        public int y;

        public Coordinate(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public static Coordinate operator +(Coordinate a, Coordinate b)
        {
            return new Coordinate(a.x + b.x, a.y + b.y);
        }

        public static Coordinate operator -(Coordinate a, Coordinate b)
        {
            return new Coordinate(a.x - b.x, a.y - b.y);
        }
    }
}
