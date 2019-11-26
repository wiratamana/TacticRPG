using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TacticRPG
{
    [CreateAssetMenu(fileName = "Character", menuName = "Create/Character", order = 1)]
    public class Character : ScriptableObject
    {
        public Status status;
    }
}
