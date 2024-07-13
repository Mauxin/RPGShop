using Inventory;

namespace EventSystem
{
    public class OnSellItem : IEvent
    {
        public Item SoldItem;
    }
}