using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TacticRPG
{
    [System.Serializable]
    public struct NodeCost
    {
        public int travelDistance;
        public int distanceToDestinationNode;
        public int totalCost { get { return travelDistance + distanceToDestinationNode; } }

        public NodeCost(Node current, int travelDistance, Node start)
        {
            this.travelDistance = Node.GetDistance(current, start);
            distanceToDestinationNode = travelDistance + 1;
        }

        public static bool operator >(NodeCost a, NodeCost b)
        {
            if(a.totalCost > b.totalCost)
            {
                return true;
            }

            if(a.distanceToDestinationNode > b.distanceToDestinationNode)
            {
                return true;
            }

            return false;
        }

        public static bool operator <(NodeCost a, NodeCost b)
        {
            if (a.totalCost < b.totalCost)
            {
                return true;
            }

            if (a.distanceToDestinationNode < b.distanceToDestinationNode)
            {
                return true;
            }

            return false;
        }

        public override string ToString()
        {
            return $"travelDistance : {travelDistance} | distanceToDestinationNode {distanceToDestinationNode} | totalCost : {totalCost}";
        }
    }
}
