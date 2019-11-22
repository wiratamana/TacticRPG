using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace TacticRPG
{
    public static class UIFactory
    {
        public static Canvas CreateCanvas(string name = "Canvas")
        {
            var go = new GameObject(name);

            SetupCanvasScaler(go.AddComponent<UnityEngine.UI.CanvasScaler>());
            go.AddComponent<UnityEngine.UI.GraphicRaycaster>();

            return SetupCanvas(go.GetComponent<Canvas>());
        }

        public static GameObject CreateEventSystem()
        {
            var go = new GameObject("EventSystem");
            go.AddComponent<EventSystem>();
            go.AddComponent<StandaloneInputModule>();
            go.AddComponent<BaseInput>();

            return go;
        }

        private static Canvas SetupCanvas(Canvas canvas)
        {
            canvas.renderMode = RenderMode.ScreenSpaceOverlay;
            return canvas;
        }

        private static UnityEngine.UI.CanvasScaler SetupCanvasScaler(UnityEngine.UI.CanvasScaler canvasScaler)
        {
            canvasScaler.uiScaleMode = UnityEngine.UI.CanvasScaler.ScaleMode.ScaleWithScreenSize;
            canvasScaler.referenceResolution = new Vector2(1920, 1080);
            canvasScaler.screenMatchMode = UnityEngine.UI.CanvasScaler.ScreenMatchMode.MatchWidthOrHeight;
            canvasScaler.matchWidthOrHeight = 1.0f;

            return canvasScaler;
        }
    }
}
