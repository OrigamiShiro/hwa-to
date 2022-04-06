using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace HwaTo
{
    public class UIManager : MonoBehaviour
    {
        private static GameObject _rootLayer;
        private static GameObject _rootCanvas;
        private static Vector2 _currentResolution;
        private static GameObject _eventSystem;

        public static void Initialize()
        {
            _eventSystem = new GameObject("EventSystem");
            _eventSystem.AddComponent<EventSystem>();
            _eventSystem.AddComponent<StandaloneInputModule>();
            
            _rootCanvas = new GameObject("RootCanvas");
            _rootCanvas.layer = 5;
            var canvas = _rootCanvas.AddComponent<Canvas>();
            var rootCanvasRect = canvas.GetComponent<RectTransform>();
            var canvasScaler = _rootCanvas.AddComponent<CanvasScaler>();
            var graphicRaycaster = _rootCanvas.AddComponent<GraphicRaycaster>();
            
            canvas.renderMode = RenderMode.ScreenSpaceOverlay;
            canvasScaler.uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;
            canvasScaler.screenMatchMode = CanvasScaler.ScreenMatchMode.Expand;
            canvasScaler.referenceResolution = new Vector2(1920, 1080);
            SetStretch(rootCanvasRect);
        }

        public static T ShowScreen<T>() where T : BaseScreen
        {
            var screen = new GameObject(typeof(T).Name);
            var rect = screen.AddComponent<RectTransform>();
            rect.SetParent(_rootCanvas.transform, false);
            screen.layer = 5;
            SetStretch(rect);

            return screen.AddComponent<T>();
        }
        
        public static void SetStretch(RectTransform rect)
        {
            rect.anchorMin = Vector2.zero;
            rect.anchorMax = Vector2.one;
            rect.offsetMax = Vector2.zero;
            rect.offsetMin = Vector2.zero;
            rect.pivot = new Vector2(0.5f, 0.5f);
        }
    }
}