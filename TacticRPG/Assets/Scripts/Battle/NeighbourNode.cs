using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TacticRPG
{
    [System.Serializable]
    public class NeighbourNode
    {
        public Node top;
        public Node bot;
        public Node right;
        public Node left;
    }
}
