using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TacticRPG
{
    public class SceneTransitionButton : MonoBehaviour
    {
        [SerializeField] private SM.SceneList backToScene;

        public virtual void OnClick()
        {
            SM.Instance.ChangeScene(backToScene);
        }
    }
}
