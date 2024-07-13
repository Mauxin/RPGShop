using System;
using EventSystem;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Inventory
{
    public abstract class AItemCell : MonoBehaviour
    {
        [SerializeField] private Image _thumbnail;
        [SerializeField] private TextMeshProUGUI _nameText;
        [SerializeField] private TextMeshProUGUI _descriptionText;
        [SerializeField] private TextMeshProUGUI _priceText;
        [SerializeField] private Button _actionButton;

        protected Item Item { get; private set; }

        protected void Start()
        {
            EventManager.Subscribe<OnPurchaseItem>(UpdateState);
            EventManager.Subscribe<OnSellItem>(UpdateState);
            EventManager.Subscribe<OnEquipItem>(UpdateState);
        }
        
        protected void OnDestroy()
        {
            EventManager.Unsubscribe<OnPurchaseItem>(UpdateState);
            EventManager.Unsubscribe<OnSellItem>(UpdateState);
            EventManager.Unsubscribe<OnEquipItem>(UpdateState);
        }
        
        private void UpdateState(IEvent eventMessage)
        {
            _actionButton.interactable = Interactable;
        }

        public void SetItem(Item item)
        {
            Item = item;
            _thumbnail.sprite = item.Thumbnail;
            _nameText.text = item.Name;
            _descriptionText.text = item.Description;
            _actionButton.onClick.AddListener(OnActionButtonClick);
            _actionButton.interactable = Interactable;
            
            if (_priceText == null) return;
            
            _priceText.text = item.Price.ToString();
        }
        
        protected abstract bool Interactable { get; }
        
        protected abstract void OnActionButtonClick();
    }
}