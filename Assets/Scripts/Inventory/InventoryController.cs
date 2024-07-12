using System;
using System.Collections.Generic;
using UnityEngine;

namespace Inventory
{
    public static class InventoryController
    {
        private const string SAVE_DATA_KEY = "Inventory";
        
        public static Inventory Inventory { get; } = ReadFromSaveData();

        public static bool IsItemOwned(string itemId)
        {
            return Inventory.Items.Contains(itemId);
        }
        
        public static bool IsItemEquipped(string itemId, Slot slot)
        {
            return Inventory.Equipped.Exists(e => e.ItemId == itemId && e.Slot == slot);
        }
        
        public static void EquipItem(Item item, Slot slot)
        {
            if (IsItemEquipped(item.Id, slot)) return;

            if (Inventory.Equipped.Exists(e => e.Slot == slot))
            {
                Inventory.Equipped.Remove(Inventory.Equipped.Find(e => e.Slot == slot));
            }
            
            Inventory.Equipped.Add(new EquipSlot { Slot = slot, ItemId = item.Id });
            WriteToSaveData();
        }
        
        public static List<EquipSlot> GetEquippedItems()
        {
            return Inventory.Equipped;
        }
        
        public static Item GetEquippedItem(Slot slot)
        {
            return !Inventory.Equipped.Exists(e => e.Slot == slot) ?
                null : Resources.Load<Item>("Data/Items/" + Inventory.Equipped.Find(e => e.Slot == slot).ItemId);
        }
    
        public static Item GetItem(string itemId)
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
            var json = JsonUtility.ToJson(Inventory);
            Debug.Log(json);
            PlayerPrefs.SetString(SAVE_DATA_KEY, JsonUtility.ToJson(Inventory));
            PlayerPrefs.Save();
        }
    }

    [Serializable]
    public class Inventory
    {
        public List<string> Items = new();
        public List<EquipSlot> Equipped = new();
    }
    
    [Serializable]
    public class EquipSlot
    {
        public Slot Slot;
        public string ItemId;
        
        public override string ToString()
        {
            return $"Slot: {Slot}, ItemId: {ItemId}";
        }
    }
}
