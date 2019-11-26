using UnityEngine;
using System.Collections;

namespace TacticRPG
{
    [System.Serializable]
    public class Level
    {
        public int level { private set; get; }

        public void LevelUp()
        {
            level++;
        }
    }
}
