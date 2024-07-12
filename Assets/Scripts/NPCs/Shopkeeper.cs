using System;
using UnityEngine;

namespace NPCs
{
    public class Shopkeeper : AInteractableNpc
    {
        private static readonly Lazy<GameObject> shopScreen =
            new(() => Resources.Load<GameObject>("Prefabs/ShopScreen"));
    
        private GameObject _shopScreen = null;

        protected override void Interact()
        {
            if (_shopScreen != null) return;
            
            _shopScreen = Instantiate(shopScreen.Value);
        }
    }
}
