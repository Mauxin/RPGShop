using System;
using Inventory;
using UnityEngine;
using UnityEngine.UI;

namespace Shop
{
    public class SellPanelController : MonoBehaviour
    {
        [SerializeField] private Button _exitButton;
        [SerializeField] private GameObject _itemsRow;

        private static readonly Lazy<SellItemCell> sellCell =
            new(() => Resources.Load<SellItemCell>("Prefabs/SellItemCell"));
        
        private ShopScreenController _shopScreenController;
        
        private void Start()
        {
            _shopScreenController = GetComponentInParent<ShopScreenController>();
            _exitButton.onClick.AddListener(_shopScreenController.OpenWelcomePanel);
            SetupCells();
        }

        private void SetupCells()
        {
            foreach (var itemId in InventoryController.Inventory.Items)
            {
                var newItemCell = Instantiate(sellCell.Value, _itemsRow.transform);
                newItemCell.SetItem(InventoryController.GetItem(itemId));
            }
        }
    }
}