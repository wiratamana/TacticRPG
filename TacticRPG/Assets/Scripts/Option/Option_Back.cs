using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TacticRPG
{
    public class Option_Back : MonoBehaviour
    {
        public void OnClick()
        {
            SM.Instance.LoadScene(SM.SceneList.Home);
        }
    }
}
