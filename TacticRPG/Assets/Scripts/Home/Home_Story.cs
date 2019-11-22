using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TacticRPG
{
    public class Home_Story : MonoBehaviour
    {
        public void OnClick()
        {
            SM.Instance.LoadScene(SM.SceneList.Story);
        }
    }
}
