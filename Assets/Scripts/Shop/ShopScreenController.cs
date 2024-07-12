using UnityEngine;

namespace Shop
{
    public class ShopScreenController : MonoBehaviour
    {
        [SerializeField] private GameObject _welcomePanel;
        [SerializeField] private GameObject _purchasePanel;
        [SerializeField] private GameObject _sellPanel;
    
        private void Start()
        { 
            OpenWelcomePanel();
        }
    
        public void OpenWelcomePanel()
        {
            _welcomePanel.SetActive(true);
            _purchasePanel.SetActive(false);
            _sellPanel.SetActive(false);
        }
    
        public void OpenPurchasePanel()
        {
            _welcomePanel.SetActive(false);
            _purchasePanel.SetActive(true);
            _sellPanel.SetActive(false);
        }
    
        public void OpenSellPanel()
        {
            _welcomePanel.SetActive(false);
            _purchasePanel.SetActive(false);
            _sellPanel.SetActive(true);
        }
    
        public void CloseShop()
        {
            Destroy(gameObject);
        }
    }
}
