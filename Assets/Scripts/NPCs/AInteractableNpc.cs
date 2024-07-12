using UnityEngine;

namespace NPCs
{
    public abstract class AInteractableNpc : MonoBehaviour
    {
        [SerializeField] protected GameObject _dialogCanvas;
        
        private void Update()
        {
            if (!_dialogCanvas.gameObject.activeSelf || !Input.GetKeyDown(KeyCode.E)) return;
            
            Interact();
        }
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            _dialogCanvas.gameObject.SetActive(true);
        }
    
        private void OnTriggerExit2D(Collider2D other)
        {
            _dialogCanvas.gameObject.SetActive(false);
        }
        
        protected abstract void Interact();
    }
}