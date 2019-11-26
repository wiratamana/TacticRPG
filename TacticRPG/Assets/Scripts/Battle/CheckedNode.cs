using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TacticRPG
{
    public struct CheckedNode
    {
        public enum Direction
        {
            None,
            Up,
            Down,
            Right,
            Left
        }

        public Coordinate coordinate;
        public NodeCost nodeCost;
        public Direction comeFrom;

        public CheckedNode(Coordinate coordinate, NodeCost nodeCost, Direction comeFrom)
        {
            this.coordinate = coordinate;
            this.nodeCost = nodeCost;
            this.comeFrom = comeFrom;
        }

        public static Coordinate GetCoordinateFromDirection(Direction direction)
        {
            switch (direction)
            {                
                case Direction.Up:
                    return Coordinate.directionUp;
                case Direction.Down:
                    return Coordinate.directionDown;
                case Direction.Right:
                    return Coordinate.directionRight;
                case Direction.Left:
                    return Coordinate.directionLeft;

                default:
                    return Coordinate.directionZero;
            }
        }

        public static Coordinate GetCoordinateDirection(Direction coor)
        {
            switch (coor)
            {
                case Direction.Up:
                    return Coordinate.directionUp;
                case Direction.Down:
                    return Coordinate.directionDown;
                case Direction.Right:
                    return Coordinate.directionRight;
                case Direction.Left:
                    return Coordinate.directionLeft;

                default:
                    return Coordinate.directionZero;
            }
        }

        public static Direction GetReverseDirection(Direction coor)
        {
            switch (coor)
            {
                case Direction.Up:
                    return Direction.Down;
                case Direction.Down:
                    return Direction.Up;
                case Direction.Right:
                    return Direction.Left;
                case Direction.Left:
                    return Direction.Right;

                default:
                    return Direction.None;
            }
        }
    }
}