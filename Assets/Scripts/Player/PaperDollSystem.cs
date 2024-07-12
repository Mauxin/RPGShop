using UnityEngine;
using UnityEngine.U2D;

namespace Player
{
    public class PaperDollSystem : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer _slotRenderer;
        [SerializeField] private SpriteRenderer _baseRenderer;

        private const string SPRITE_BASE_NAME = "char_a_p1_0bas_humn_v01_";
        
        public SpriteAtlas itemSpriteAtlas;
        [SerializeField] private string _spriteSlotName = "char_a_p1_5hat_pfht_v04_";
        
        //TODO: ADD ITEM SETUP
        private void Start()
        {
            
        }
        
        private void Update()
        {
            var current = _baseRenderer.sprite.name.Replace(SPRITE_BASE_NAME, _spriteSlotName);
            _slotRenderer.sprite = LoadSpriteByName(current);
        }
        
        private Sprite LoadSpriteByName(string spriteName)
        {
            if (itemSpriteAtlas == null) return null;

            var sprite = itemSpriteAtlas.GetSprite(spriteName);
            return sprite == null ? null : sprite;
        }
    }
}