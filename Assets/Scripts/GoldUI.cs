using Inventory;
using TMPro;
using UnityEngine;

public class GoldUI : MonoBehaviour
{
    private const string GOLD_TEXT = "GOLD: {0}";

    private void Start()
    {
        var text = GetComponent<TextMeshProUGUI>();
        text.text = string.Format(GOLD_TEXT, WalletController.Gold);
    }
}
