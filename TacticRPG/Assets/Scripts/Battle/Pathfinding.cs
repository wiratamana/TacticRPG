using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace TacticRPG
{
    public class Pathfinding : MonoBehaviour
    {
        public Battlefield battlefield;

        private Queue<Node> listAvailableNode = new Queue<Node>();
        private Dictionary<Coordinate, CheckedNode> checkedNode = new Dictionary<Coordinate, CheckedNode>();

        private Node destination;
        private Node start;

        public Queue<Node> GetPath(Node start, Node destination)
        {
            listAvailableNode.Clear();
            checkedNode.Clear();

            this.destination = destination;
            this.start = start;

            listAvailableNode.Enqueue(start);

            bool isPathToDestinationFound = false;
            while(isPathToDestinationFound == false && listAvailableNode.Count > 0)
            {
                var resultOpenNode = OpenNode(listAvailableNode.Dequeue());      

                foreach(var openedNode in resultOpenNode)
                {
                    listAvailableNode.Enqueue(battlefield.GetNode(openedNode.coordinate));
                }

                listAvailableNode = new Queue<Node>(listAvailableNode.Distinct().ToArray());
            }
            
            return null;
        }

        private List<CheckedNode> OpenNode(Node node)
        {
            var retval = new List<CheckedNode>();

            var checkCoordinate = node.coordinate + new Coordinate(0, 1);
            AddOpenNode(checkCoordinate, retval);

            checkCoordinate = node.coordinate + new Coordinate(0, -1);
            AddOpenNode(checkCoordinate, retval);

            checkCoordinate = node.coordinate + new Coordinate(1, 0);
            AddOpenNode(checkCoordinate, retval);

            checkCoordinate = node.coordinate + new Coordinate(-1, 0);
            AddOpenNode(checkCoordinate, retval);

            return retval;
        }

        private void AddOpenNode(Coordinate checkCoordinate, List<CheckedNode> nodes)
        {
            if (battlefield.isNodeAccessible(checkCoordinate) == false)
            {
                return;
            }

            var neighbourNode = battlefield.GetNode(checkCoordinate);
            var cost = new NodeCost(neighbourNode, destination, start);
            neighbourNode.GetComponent<SpriteRenderer>().color = Color.red;
            if (checkedNode.ContainsKey(checkCoordinate) == false)
            {
                nodes.Add(new CheckedNode(checkCoordinate, cost));
                checkedNode.Add(checkCoordinate, new CheckedNode(checkCoordinate, cost));
                return;
            }

            if (cost < checkedNode[checkCoordinate].nodeCost)
            {
                checkedNode[checkCoordinate] = new CheckedNode(checkCoordinate, cost);
            }
        }
    }
}
