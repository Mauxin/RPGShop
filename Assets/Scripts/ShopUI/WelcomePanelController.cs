using UnityEngine;
using UnityEngine.UI;

namespace ShopUI
{
    public class WelcomePanelController : MonoBehaviour
    {
        [SerializeField] private Button _buyButton;
        [SerializeField] private Button _sellButton;
        [SerializeField] private Button _exitButton;
        
        private ShopScreenController _shopScreenController;

        private void Start()
        {
            _shopScreenController = GetComponentInParent<ShopScreenController>();
            _buyButton.onClick.AddListener(_shopScreenController.OpenPurchasePanel);
            _sellButton.onClick.AddListener(_shopScreenController.OpenSellPanel);
            _exitButton.onClick.AddListener(_shopScreenController.CloseShop);
        }
    }
}