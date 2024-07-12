using System;
using System.Collections.Generic;
using UnityEngine;

namespace Inventory
{
    public static class InventoryController
    {
        private const string SAVE_DATA_KEY = "Inventory";
        
        public static Inventory Inventory { get; } = ReadFromSaveData();

        public static bool IsItemOwned(int itemId)
        {
            return Inventory.Items.Contains(itemId);
        }
    
        public static Item GetItem(int itemId)
        {
            return IsItemOwned(itemId) ? Resources.Load<Item>("Data/Items/" + itemId) : null;
        }
    
        public static void AddItem(Item item)
        {
            Inventory.Items.Add(item.Id);
            WriteToSaveData();
        }
    
        public static void RemoveItem(Item item)
        {
            Inventory.Items.Remove(item.Id);
            WriteToSaveData();
        }

        private static Inventory ReadFromSaveData()
        {
            return !PlayerPrefs.HasKey(SAVE_DATA_KEY) ? new Inventory() : 
                JsonUtility.FromJson<Inventory>(PlayerPrefs.GetString(SAVE_DATA_KEY));
        }
        
        private static void WriteToSaveData()
        {
            PlayerPrefs.SetString(SAVE_DATA_KEY, JsonUtility.ToJson(Inventory));
            PlayerPrefs.Save();
        }
    }

    [Serializable]
    public class Inventory
    {
        public List<int> Items = new();
    }
}
