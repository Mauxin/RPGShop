using EventSystem;

namespace Inventory
{
    public class SellItemCell : AItemCell
    {
        protected override bool Interactable => Item.IsOwned;

        protected override void OnActionButtonClick()
        {
            if (!Item.IsOwned) return;
            
            WalletController.AddGold(Item.Price);
            InventoryController.RemoveItem(Item);
            EventManager.Trigger(new OnSellItem{SoldItem = Item});
        }
    }
}