using System;
using UnityEngine;

namespace Player
{
    public class PlayerInventoryPresenter : MonoBehaviour
    {
        private static readonly Lazy<GameObject> inventoryScreen =
            new(() => Resources.Load<GameObject>("Prefabs/InventoryScreen"));
        
        private GameObject _inventoryScreen = null;
        
        private void Update()
        {
            if (Input.GetKey(KeyCode.I))
            {
                OpenInventory();
            }
        }

        private  void OpenInventory()
        {
            if (_inventoryScreen != null) return;
            
            _inventoryScreen = Instantiate(inventoryScreen.Value);
        }
    }
}