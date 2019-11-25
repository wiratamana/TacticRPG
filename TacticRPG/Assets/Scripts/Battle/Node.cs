using UnityEngine;
using System.Collections;

namespace TacticRPG
{
    public class Node : MonoBehaviour
    {
        public Battlefield battlefield;
        public Coordinate coordinate;

        public bool isTraversible;
        public void Setup(Battlefield battlefield, Coordinate coordinate)
        {
            this.battlefield = battlefield;
            this.coordinate = coordinate;
        }
        
        public static int GetDistance(Node a, Node b)
        {
            return Mathf.Abs(a.coordinate.x - b.coordinate.x) + Mathf.Abs(a.coordinate.y - b.coordinate.y);
        }

        private void OnMouseDown()
        {
            Debug.Log(transform.position);
            BattlefieldInstantiator.Instance.Click(this);
        }
    }
}
