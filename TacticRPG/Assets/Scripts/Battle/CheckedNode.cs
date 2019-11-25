using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TacticRPG
{
    public struct CheckedNode
    {
        public Coordinate coordinate;
        public NodeCost nodeCost;

        public CheckedNode(Coordinate coordinate, NodeCost nodeCost)
        {
            this.coordinate = coordinate;
            this.nodeCost = nodeCost;
        }
    }
}
