using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HwaTo
{
    public class MainCamera : MonoBehaviour
    {
        private void Awake()
        {
            UIManager.Initialize();
            UIManager.ShowScreen<Deck>();
        }
    }
}