using UnityEngine;

namespace Inventory
{
    [CreateAssetMenu(menuName = "ScriptableObjects/Items")]
    public class Item : ScriptableObject
    {
        [SerializeField] private int _id;
        [SerializeField] private int _type;
        [SerializeField] private int _price;
        [SerializeField] private Sprite _thumbnail;
        [SerializeField] private string _name;
        [SerializeField] private string _description;
        
        public int Id => _id;
        public int Type => _type;
        public int Price => _price;
        public Sprite Thumbnail => _thumbnail;
        public string Name => _name;
        public string Description => _description;
        public bool IsOwned => InventoryController.IsItemOwned(_id);
        public bool CanPurchase => WalletController.Gold >= _price && !IsOwned;
    }
}