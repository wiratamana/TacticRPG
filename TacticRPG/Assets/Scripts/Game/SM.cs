using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

namespace TacticRPG
{
    public class SM : SingletonMonobehaviour<SM>
    {
        private const string GAMEOBJECT_NAME = "SceneManager";

        public enum SceneList
        {
            Home, Unit, Story, Option
        }

        private static SceneList CurrentActiveScene = SceneList.Home;

        protected override void Awake()
        {
            if(Instance != null)
            {
                Destroy(gameObject);
                return;
            }

            base.Awake();
        }

        public static SM CreateInstance()
        {
            var go = new GameObject(GAMEOBJECT_NAME);
            var comp = go.AddComponent<SM>();

            return comp;
        }

        public void LoadImmediate(SceneList scene)
        {
            SceneManager.LoadScene(scene.ToString(), LoadSceneMode.Additive);
            CurrentActiveScene = scene;
        }

        public void LoadScene(SceneList scene)
        {
            var loadScene = scene;
            StartCoroutine(UnloadScene(() => 
            {
                SceneManager.LoadScene(scene.ToString(), LoadSceneMode.Additive);
                CurrentActiveScene = loadScene;
            }));
        }
        
        private IEnumerator UnloadScene(UnityAction afterUnload)
        {
            var unloadProgress = SceneManager.UnloadSceneAsync(CurrentActiveScene.ToString());

            yield return unloadProgress;

            afterUnload?.Invoke();
        }
    }
}