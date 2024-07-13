using EventSystem;

namespace Inventory
{
    public class PurchaseItemCell : AItemCell
    {
        protected override bool Interactable => Item.CanPurchase;

        protected override void OnActionButtonClick()
        {
            if (!Item.CanPurchase) return;
            
            WalletController.RemoveGold(Item.Price);
            InventoryController.AddItem(Item);
            InventoryController.EquipItem(Item, Item.Slot);
            
            EventManager.Trigger( new OnPurchaseItem {PurchasedItem = Item});
        }
    }
}