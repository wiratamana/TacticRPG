using UnityEngine;
using System.Collections;

namespace TacticRPG
{
    public class Battlefield : MonoBehaviour
    {
        public Node[,] field;     
        private int width { get { return field?.GetLength(0) ?? 0; } }
        private int height { get { return field?.GetLength(1) ?? 0; } }

        public bool isNodeAccessible(Coordinate coordinate)
        {
            if(coordinate.x >= width || coordinate.x < 0 || coordinate.y >= height || coordinate.y < 0)
            {
                return false;
            }

            if(GetNode(coordinate).isTraversible == false)
            {
                return false;
            }

            return true;
        }

        public Node GetNode(Coordinate coordinate)
        {
            return field[coordinate.x, coordinate.y];
        }
    }
}
