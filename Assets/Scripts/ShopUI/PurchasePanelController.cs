using System;
using Inventory;
using UnityEngine;
using UnityEngine.UI;

namespace ShopUI
{
    public class PurchasePanelController : MonoBehaviour
    {
        [SerializeField] private Button _exitButton;
        [SerializeField] private GameObject _itemsRow;
        [SerializeField] private StoreItemList _itemList;

        private static readonly Lazy<PurchaseItemCell> purchaseCell =
            new(() => Resources.Load<PurchaseItemCell>("Prefabs/PurchaseItemCell"));
        
        private ShopScreenController _shopScreenController;
        
        private void Start()
        {
            _shopScreenController = GetComponentInParent<ShopScreenController>();
            _exitButton.onClick.AddListener(_shopScreenController.OpenWelcomePanel);
            SetupCells();
        }

        private void SetupCells()
        {
            foreach (var item in _itemList.Items)
            {
                var newItemCell = Instantiate(purchaseCell.Value, _itemsRow.transform);
                newItemCell.SetItem(item);
            }
        }
    }
}