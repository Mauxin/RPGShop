using Inventory;
using UnityEngine;

namespace Player
{
    public class PaperDollSystem : MonoBehaviour
    {
        //[SerializeField] private Slot _spriteSlot;
        [SerializeField] private Item _item;
        [SerializeField] private SpriteRenderer _slotRenderer;
        [SerializeField] private SpriteRenderer _baseRenderer;

        private const string SPRITE_BASE_NAME = "char_a_p1_0bas_humn_v01_";
        
        //TODO: GET EQUIPPED ITEM
        private void Start()
        {
            
        }
        
        private void Update()
        {
            if (_item == null) return;
            
            var current = _baseRenderer.sprite.name.Replace(SPRITE_BASE_NAME, _item.AnimationKey);
            _slotRenderer.sprite = _item.GetFrame(current);
        }
    }
}