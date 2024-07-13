using EventSystem;
using Inventory;
using TMPro;
using UnityEngine;

namespace ShopUI
{
    public class GoldUI : MonoBehaviour
    {
        private const string GOLD_TEXT = "GOLD: {0}";

        private void Start()
        {
            EventManager.Subscribe<OnWalletUpdated>(UpdateText);
            UpdateText(null);
        }

        private void OnDestroy()
        {
            EventManager.Unsubscribe<OnWalletUpdated>(UpdateText);
        }

        private void UpdateText(IEvent eventMessage)
        {
            var text = GetComponent<TextMeshProUGUI>();
            text.text = string.Format(GOLD_TEXT, WalletController.Gold);
        }
    }
}