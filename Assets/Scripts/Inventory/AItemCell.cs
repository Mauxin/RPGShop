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
        
        protected abstract bool Interactable { get; }
        
        protected abstract void OnActionButtonClick();

        public void SetItem(Item item)
        {
            Item = item;
            _thumbnail.sprite = item.Thumbnail;
            _nameText.text = item.Name;
            _descriptionText.text = item.Description;
            _priceText.text = item.Price.ToString();
            _actionButton.onClick.AddListener(OnActionButtonClick);
            _actionButton.interactable = Interactable;
        }
    }
}