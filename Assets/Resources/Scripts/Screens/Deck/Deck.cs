using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HwaTo
{
    public class Deck : BaseScreen
    {
        private void Awake()
        {
            ResourceManager.InstantiateScreen("Prefabs/UI/Deck/Deck", transform);
        }
    }
}
