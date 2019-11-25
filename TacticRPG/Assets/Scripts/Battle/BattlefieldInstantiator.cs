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
    }
}
