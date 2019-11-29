using UnityEngine;
using System.Collections;

namespace TacticRPG
{
    public class BattlefieldInstantiator : SingletonMonobehaviour<BattlefieldInstantiator>
    {
        public int width = 10;
        public int height = 10;
        public GameObject prefab;

        public Pathfinding pathfinding;
        public Battlefield battlefield;

        public Node start;
        public Node destination;

        public GameObject top;
        public GameObject bot;
        public GameObject left;
        public GameObject right;

        void Start()
        {
            battlefield = InstantiateBattlefield();
            InstantiateNode(battlefield);

            pathfinding = InstantiatePathfinding();
        }

        public void Click(Node node)
        {
            if(start == null)
            {
                Clear();
                start = node;
                return;
            }

            if(destination == null)
            {
                destination = node;
                pathfinding.GetPath(start, destination);
                start = null;
                destination = null;
            }
        }

        private void Clear()
        {
            foreach(var a in battlefield.field)
            {
                if(a.isTraversible == false)
                {
                    continue;
                }

                var go = GameObject.Find(a.coordinate.ToString());
                if(go != null)
                {
                    Destroy(go);
                }

                a.GetComponent<SpriteRenderer>().color = Color.white;
            }
        }

        public Battlefield InstantiateBattlefield()
        {
            var go = new GameObject("Battlefield");
            return go.AddComponent<Battlefield>();
        }

        private void InstantiateNode(Battlefield battlefield)
        {
            battlefield.field = new Node[width, height];

            for(int x = 0; x < width; x++)
            {
                for(int y = 0; y < height; y++)
                {
                    var node = Instantiate(prefab);
                    node.transform.position = new Vector3(x, y);

                    var nodeComponent = node.GetComponent<Node>();
                    nodeComponent.Setup(battlefield, new Coordinate(x, y));
                    nodeComponent.isTraversible = true;

                    if(x == 1 && y < 5)
                    {
                        nodeComponent.isTraversible = false;
                        nodeComponent.GetComponent<SpriteRenderer>().color = Color.gray;
                    }

                    if(x > 2 && y == 5)
                    {
                        nodeComponent.isTraversible = false;
                        nodeComponent.GetComponent<SpriteRenderer>().color = Color.gray;
                    }

                    if (x > 1 && x < height - 1 && y == 3)
                    {
                        nodeComponent.isTraversible = false;
                        nodeComponent.GetComponent<SpriteRenderer>().color = Color.gray;
                    }

                    battlefield.field[x, y] = nodeComponent;
                }
            }
        }

        private Pathfinding InstantiatePathfinding()
        {
            var go = new GameObject("Pathfinding").AddComponent<Pathfinding>();
            go.battlefield = battlefield;
            return go;
        }

        public void InstantiateDirectionArrow(CheckedNode.Direction dir, Coordinate coor)
        {
            var duplicate = GameObject.Find(coor.ToString());
            if (duplicate != null)
            {
                Destroy(duplicate);
            }

            GameObject go = null;
            switch (dir)
            {
                case CheckedNode.Direction.None:
                    break;
                case CheckedNode.Direction.Up:
                    go = Instantiate(top);
                    break;
                case CheckedNode.Direction.Down:
                    go = Instantiate(bot);
                    break;
                case CheckedNode.Direction.Right:
                    go = Instantiate(right);
                    break;
                case CheckedNode.Direction.Left:
                    go = Instantiate(left);
                    break;
            }

            if(go != null)
            {
                go.name = coor.ToString();
                go.transform.position = new Vector3(coor.x, coor.y);
            }
        }
    }
}