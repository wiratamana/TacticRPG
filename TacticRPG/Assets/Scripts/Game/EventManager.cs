using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace TacticRPG
{
    public class EventManager
    {
        private class EventHelper : UnityEvent { }
        private readonly UnityEvent callbackers = new EventHelper();

        public void AddListener(UnityAction callback)
        {
            callbackers.AddListener(callback);
        }

        public void RemoveListener(UnityAction callback)
        {
            callbackers.RemoveListener(callback);
        }

        public void RemoveAllListeners()
        {
            callbackers.RemoveAllListeners();
        }

        public void Invoke()
        {
            callbackers?.Invoke();
        }
    }

    public class EventManager<T>
    {
        private class EventHelper : UnityEvent<T> { }
        private readonly UnityEvent<T> callbackers = new EventHelper();

        public void AddListener(UnityAction<T> callback)
        {
            callbackers.AddListener(callback);
        }

        public void RemoveListener(UnityAction<T> callback)
        {
            callbackers.RemoveListener(callback);
        }

        public void RemoveAllListeners()
        {
            callbackers.RemoveAllListeners();
        }

        public void Invoke(T param)
        {
            callbackers?.Invoke(param);
        }
    }

    public class EventManager<T1, T2>
    {
        private class EventHelper : UnityEvent<T1, T2> { }
        private readonly UnityEvent<T1, T2> callbackers = new EventHelper();

        public void AddListener(UnityAction<T1, T2> callback)
        {
            callbackers.AddListener(callback);
        }

        public void RemoveListener(UnityAction<T1, T2> callback)
        {
            callbackers.RemoveListener(callback);
        }

        public void RemoveAllListeners()
        {
            callbackers.RemoveAllListeners();
        }

        public void Invoke(T1 param1, T2 param2)
        {
            callbackers?.Invoke(param1, param2);
        }
    }
}
