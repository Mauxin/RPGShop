using System;
using UnityEngine;

namespace NPCs
{
    public class Shopkeeper : MonoBehaviour
    {
        [SerializeField] private GameObject _shopkeeperCanvas;

        private static readonly Lazy<GameObject> shopScreen =
            new(() => Resources.Load<GameObject>("Prefabs/ShopScreen"));
    
        private GameObject _shopScreen = null;

        private void Update()
        {
            if (_shopkeeperCanvas.gameObject.activeSelf 
                && Input.GetKeyDown(KeyCode.E) 
                && _shopScreen == null)
            {
                _shopScreen = Instantiate(shopScreen.Value);
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            _shopkeeperCanvas.gameObject.SetActive(true);
        }
    
        private void OnTriggerExit2D(Collider2D other)
        {
            _shopkeeperCanvas.gameObject.SetActive(false);
        }
    }
}
