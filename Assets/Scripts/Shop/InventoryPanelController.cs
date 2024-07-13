using System;
using Inventory;
using UnityEngine;
using UnityEngine.UI;

namespace Shop
{
    public class InventoryPanelController : MonoBehaviour
    {
        [SerializeField] private Button _exitButton;
        [SerializeField] private GameObject _itemsRow;

        private static readonly Lazy<InventoryItemCell> inventoryCell =
            new(() => Resources.Load<InventoryItemCell>("Prefabs/InventoryItemCell"));
    
        private void Start()
        {
            _exitButton.onClick.AddListener(() => { Destroy(this); });
            SetupCells();
        }

        private void SetupCells()
        {
            foreach (var itemId in InventoryController.Inventory.Items)
            {
                var item = InventoryController.GetItem(itemId);
                if (item.Slot == Slot.Underwear) continue;
            
                var newItemCell = Instantiate(inventoryCell.Value, _itemsRow.transform);
                newItemCell.SetItem(item);
            }
        }
    }
}