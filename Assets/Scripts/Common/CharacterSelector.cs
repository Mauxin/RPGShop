using Inventory;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Common
{
    public class CharacterSelector : MonoBehaviour
    {
        [SerializeField] private Button _playerSelectionButton;
        [SerializeField] private Item _defaultItem;
        
        private void Start()
        {
            _playerSelectionButton.onClick.AddListener(SelectCharacter);
        }
        
        private void SelectCharacter()
        {
            InventoryController.AddItem(_defaultItem);
            InventoryController.EquipItem(_defaultItem, _defaultItem.Slot);
            PlayerPrefs.SetString(CommonStrings.SAVE_DATA_CHARACTER_KEY, _defaultItem.Id);
            
            SceneManager.LoadScene(CommonStrings.SHOP_SCENE, LoadSceneMode.Single);
        }
        
    }
}