using UnityEngine;
using System.Collections;

namespace TacticRPG
{
    [System.Serializable]
    public class Status
    {
        public Level level;
        public Experience experience;

        public StatusBase statusBase;    
    }
}