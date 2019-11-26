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
        public int distanceFromStartingNode;
        public int distanceToDestinationNode;
        public int totalCost { get { return distanceFromStartingNode + distanceToDestinationNode; } }

        public NodeCost(Node current, Node destination, Node start)
        {
            distanceFromStartingNode = Node.GetDistance(current, start);
            distanceToDestinationNode = Node.GetDistance(current, destination);
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
    }
}
