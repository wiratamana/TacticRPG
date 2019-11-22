using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TacticRPG
{
    public class GameManager : SingletonMonobehaviour<GameManager>
    {
        protected override void Awake()
        {
            if(Instance != null)
            {
                Destroy(gameObject);
                return;
            }

            base.Awake();

            var initializer = new Initializer();

            SM.CreateInstance();
        }

        private void Start()
        {
            SM.Instance.LoadImmediate(SM.SceneList.Home);
        }
    }
}
