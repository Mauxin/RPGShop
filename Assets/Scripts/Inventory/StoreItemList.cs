using UnityEngine;

namespace Inventory
{
    [CreateAssetMenu(menuName = "ScriptableObjects/StoreItemList")]
    public class StoreItemList : ScriptableObject
    {
        [SerializeField] private Item[] _items;
        
        public Item[] Items => _items;
    }
}