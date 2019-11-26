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
            Home, Unit, Story, Option,
            ChangeFormation, ChangeEquipment, ChangeJob, UpgradeSkill,
            Conversation, BattlePreparation
        }

        public static EventManager<SceneList> OnBeforeUnload { private set; get; } = new EventManager<SceneList>();
        public static EventManager<SceneList> OnAfterUnload  { private set; get; } = new EventManager<SceneList>();
        public static EventManager<SceneList> OnBeforeLoad { private set; get; } = new EventManager<SceneList>();
        public static EventManager<SceneList> OnAfterLoad { private set; get; } = new EventManager<SceneList>();

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

        public void ChangeScene(SceneList scene)
        {
            var loadScene = scene;
            StartCoroutine(ChangeSceneCoroutine(scene));
        }
        
        private IEnumerator ChangeSceneCoroutine(SceneList scene)
        {
            OnBeforeUnload?.Invoke(CurrentActiveScene);
            OnBeforeUnload.RemoveAllListeners();
            var unloadProgress = SceneManager.UnloadSceneAsync(CurrentActiveScene.ToString());

            yield return unloadProgress;

            OnAfterUnload?.Invoke(CurrentActiveScene);
            OnAfterUnload?.RemoveAllListeners();
            OnBeforeLoad?.Invoke(scene);
            OnBeforeLoad?.RemoveAllListeners();
            unloadProgress = SceneManager.LoadSceneAsync(scene.ToString(), LoadSceneMode.Additive);

            yield return unloadProgress;

            OnAfterLoad?.Invoke(scene);
            OnAfterLoad?.RemoveAllListeners();
            CurrentActiveScene = scene;
        }
    }
}