using UnityEngine;
using UnityEngine.U2D;

namespace Inventory
{
    [CreateAssetMenu(menuName = "ScriptableObjects/Items")]
    public class Item : ScriptableObject
    {
        [SerializeField] private string _id;
        [SerializeField] private Slot _slot;
        [SerializeField] private int _price;
        [SerializeField] private Sprite _thumbnail;
        [SerializeField] private string _name;
        [SerializeField] private string _description;
        [SerializeField] private string _animation_key;
        [SerializeField] private SpriteAtlas _atlas;

        public string Id => _id;
        public Slot Slot => _slot;
        public int Price => _price;
        public Sprite Thumbnail => _thumbnail;
        public string Name => _name;
        public string Description => _description;
        public bool IsOwned => InventoryController.IsItemOwned(_id);
        public bool CanPurchase => WalletController.Gold >= _price && !IsOwned;
        public string AnimationKey => _animation_key;
        
        public Sprite GetFrame(string spriteName)
        {
            if (_atlas == null) return null;

            var sprite = _atlas.GetSprite(spriteName);
            return sprite == null ? null : sprite;
        }
    }
}