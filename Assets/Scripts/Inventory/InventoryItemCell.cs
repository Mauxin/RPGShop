using EventSystem;

namespace Inventory
{
    public class InventoryItemCell : AItemCell
    {
        protected override bool Interactable => InventoryController.IsItemOwned(Item.Id) 
                                                && !InventoryController.IsItemEquipped(Item.Id, Item.Slot);
        
        protected override void OnActionButtonClick()
        {
            InventoryController.EquipItem(Item, Item.Slot);
            EventManager.Trigger(new OnEquipItem { EquippedItem = Item });
        }
    }
}