using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TacticRPG
{
    public class StartupAnimator : MonoBehaviour
    {
        [SerializeField] private AnimationClip animation;

        void Start()
        {
            var animator = GetComponent<Animator>();
            animator.Play(animation.name);
        }
    }
}
