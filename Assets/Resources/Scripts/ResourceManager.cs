using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HwaTo
{
    public class ResourceManager : MonoBehaviour
    {
        public static GameObject InstantiateScreen(string path, Transform parent)
        {
            var prefab = Resources.Load<GameObject>(path);
            var inst = Instantiate(prefab, parent);
            var rect = inst.GetComponent<RectTransform>();
            UIManager.SetStretch(rect);
            
            return prefab;
        }
    }
}
