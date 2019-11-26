using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace TacticRPG
{
    public class Pathfinding : MonoBehaviour
    {
        public Battlefield battlefield;

        private List<Node> listAvailableNode = new List<Node>();
        private Dictionary<Coordinate, CheckedNode> checkedNode = new Dictionary<Coordinate, CheckedNode>();

        private Node destination;
        private Node start;

        private bool isPathToDestinationFound;

        public Queue<Node> GetPath(Node start, Node destination)
        {
            Benchmark.Start();

            this.destination = destination;
            this.start = start;
            listAvailableNode.Clear();
            checkedNode.Clear();

            listAvailableNode.Add(start);
            checkedNode.Add(start.coordinate, new CheckedNode(start.coordinate, new NodeCost(start, destination, start), CheckedNode.Direction.None));

            isPathToDestinationFound = false;
            while (isPathToDestinationFound == false && listAvailableNode.Count > 0)
            {
                var resultOpenNode = OpenNode(listAvailableNode[0]);
                listAvailableNode.RemoveAt(0);

                foreach (var openedNode in resultOpenNode)
                {
                    listAvailableNode.Add(battlefield.GetNode(openedNode.coordinate));
                }

                listAvailableNode = listAvailableNode.Distinct().ToList();

                listAvailableNode = listAvailableNode.OrderBy(x => new NodeCost(x, destination, start).totalCost + new NodeCost(x, destination, start).distanceToDestinationNode).ToList();
            }

            if(isPathToDestinationFound == true)
            {
                var dir = new List<Coordinate>();
                dir.Add(destination.coordinate);

                var coor = destination.coordinate;
                Debug.Log($"coor = x:{coor.x} y:{coor.y}");
                while(true)
                {
                    var comeFrom = checkedNode[coor].comeFrom;
                    coor = coor + CheckedNode.GetCoordinateDirection(comeFrom);
                    dir.Add(coor);

                    if (coor == start.coordinate)
                    {
                        break;
                    }
                }
                
                for(int i = 0; i < dir.Count; i++)
                {
                    battlefield.field[dir[i].x, dir[i].y].GetComponent<SpriteRenderer>().color = Color.red;
                }
            }

            Benchmark.Stop();
            return null;
        }

        private List<CheckedNode> OpenNode(Node node)
        {
            var retval = new List<CheckedNode>();

            AddOpenNode(node, CheckedNode.Direction.Up, retval);
            AddOpenNode(node, CheckedNode.Direction.Down, retval);
            AddOpenNode(node, CheckedNode.Direction.Right, retval);
            AddOpenNode(node, CheckedNode.Direction.Left, retval);

            return retval;
        }

        private void AddOpenNode(Node node, CheckedNode.Direction dir, List<CheckedNode> nodes)
        {
            var checkCoordinate = node.coordinate + CheckedNode.GetCoordinateFromDirection(dir);
            if (isPathToDestinationFound == true || battlefield.isNodeAccessible(checkCoordinate) == false)
            {
                return;
            }

            var neighbourNode = battlefield.GetNode(checkCoordinate);
            var cost = new NodeCost(neighbourNode, destination, start);

            var checkedNode = new CheckedNode(checkCoordinate, cost, CheckedNode.GetReverseDirection(dir));

            if (neighbourNode == destination)
            {
                this.checkedNode.Add(checkCoordinate, checkedNode);
                isPathToDestinationFound = true;
                return;
            }

            if (this.checkedNode.ContainsKey(checkCoordinate) == false)
            {
                nodes.Add(checkedNode);
                this.checkedNode.Add(checkCoordinate, checkedNode);
                return;
            }

            if (cost < this.checkedNode[checkCoordinate].nodeCost)
            {
                this.checkedNode[checkCoordinate] = checkedNode;
            }
        }
    }
}
