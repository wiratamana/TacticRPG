using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TacticRPG
{
    public class Initializer
    {
        public GameObject EventSystem { private set; get; }
        public Canvas MainCanvas { private set; get; }

        public Initializer()
        {
            EventSystem = UIFactory.CreateEventSystem();
            MainCanvas = UIFactory.CreateCanvas("MainCanvas");
        }
    }
}
