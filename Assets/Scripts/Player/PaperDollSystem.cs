using System;
using EventSystem;
using Inventory;
using UnityEngine;

namespace Player
{
    public class PaperDollSystem : MonoBehaviour
    {
        [SerializeField] private Slot _spriteSlot;
        [SerializeField] private SpriteRenderer _slotRenderer;
        [SerializeField] private SpriteRenderer _baseRenderer;

        private const string SPRITE_BASE_NAME = "char_a_p1_0bas_humn_v01_";
        private Item _item;
        
        private void Start()
        {
            _item = InventoryController.GetEquippedItem(_spriteSlot);
            EventManager.Subscribe<OnPurchaseItem>(EquipPurchased);
            EventManager.Subscribe<OnEquipItem>(Equip);
            EventManager.Subscribe<OnSellItem>(Unequip);
        }

        private void OnDestroy()
        {
            EventManager.Unsubscribe<OnPurchaseItem>(EquipPurchased);
            EventManager.Unsubscribe<OnSellItem>(Unequip);
            EventManager.Unsubscribe<OnEquipItem>(Equip);
        }
        
        private void Equip(IEvent eventMessage)
        {
            var message = (OnEquipItem) eventMessage;
            if (message.EquippedItem.Slot != _spriteSlot) return;
            
            _item = message.EquippedItem;
        }

        private void EquipPurchased(IEvent eventMessage)
        {
            var message = (OnPurchaseItem) eventMessage;
            if (message.PurchasedItem.Slot != _spriteSlot) return;
            
            _item = message.PurchasedItem;
        }
        
        private void Unequip(IEvent eventMessage)
        {
            var message = (OnSellItem) eventMessage;
            if (message.SoldItem.Slot != _spriteSlot) return;
            
            _item = null;
            _slotRenderer.sprite = null;
        }
        
        private void Update()
        {
            if (_item == null) return;
            
            var current = _baseRenderer.sprite.name.Replace(SPRITE_BASE_NAME, _item.AnimationKey);
            _slotRenderer.sprite = _item.GetFrame(current);
        }
    }
}