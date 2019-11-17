using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TacticRPG
{
    public class SingletonMonobehaviour<T> : MonoBehaviour where T : MonoBehaviour
    {
        public static T Instance { private set; get; }

        protected virtual void Awake()
        {
            Instance = this as T;
        }
    }
}
