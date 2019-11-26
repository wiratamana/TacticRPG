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

        public static Coordinate directionZero
        {
            get
            {
                return new Coordinate(0, 0);
            }
        }

        public static Coordinate directionUp
        {
            get
            {
                return new Coordinate(0, 1);
            }
        }

        public static Coordinate directionDown
        {
            get
            {
                return new Coordinate(0, -1);
            }
        }

        public static Coordinate directionRight
        {
            get
            {
                return new Coordinate(1, 0);
            }
        }

        public static Coordinate directionLeft
        {
            get
            {
                return new Coordinate(-1, 0);
            }
        }

        public static Coordinate operator +(Coordinate a, Coordinate b)
        {
            return new Coordinate(a.x + b.x, a.y + b.y);
        }

        public static Coordinate operator -(Coordinate a, Coordinate b)
        {
            return new Coordinate(a.x - b.x, a.y - b.y);
        }

        public static bool operator ==(Coordinate a, Coordinate b)
        {
            return a.x == b.x && a.y == b.y;
        }

        public static bool operator !=(Coordinate a, Coordinate b)
        {
            return a.x != b.x && a.y != b.y;
        }
    }
}
