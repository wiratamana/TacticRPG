using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TacticRPG
{
    [CreateAssetMenu(fileName = "Character", menuName = "Create/Character", order = 1)]
    public class Character : ScriptableObject
    {
        public Sprite characterFace;
        public int level;
        public int hp;
        public int mp;

        public int attack;
        public int defense;
        public int magicAttack;
        public int magicDefense;
        public int luck;
    }
}
