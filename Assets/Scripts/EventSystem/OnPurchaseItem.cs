using Inventory;

namespace EventSystem
{
    public class OnPurchaseItem : IEvent
    {
        public Item PurchasedItem;
    }
}