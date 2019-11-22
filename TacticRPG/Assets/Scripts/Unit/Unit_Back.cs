using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TacticRPG
{
    public class Unit_Back : MonoBehaviour
    {
        public void OnClick()
        {
            SM.Instance.LoadScene(SM.SceneList.Home);
        }
    }
}