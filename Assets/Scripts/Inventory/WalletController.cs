using EventSystem;
using UnityEngine;

namespace Inventory
{
    public static class WalletController
    {
        private const string SAVE_DATA_KEY = "GOLD";
        public static int Gold { get; private set; } = ReadFromSaveData();
        
        public static void AddGold(int amount)
        {
            Gold += amount;
            EventManager.Trigger(new OnWalletUpdated {Gold = Gold});
            WriteToSaveData();
        }
        
        public static void RemoveGold(int amount)
        {
            Gold -= amount;
            EventManager.Trigger(new OnWalletUpdated {Gold = Gold});
            WriteToSaveData();
        }
        
        private static int ReadFromSaveData()
        {
            return !PlayerPrefs.HasKey(SAVE_DATA_KEY) ? 200 : PlayerPrefs.GetInt(SAVE_DATA_KEY);
        }
        
        private static void WriteToSaveData()
        {
            PlayerPrefs.SetInt(SAVE_DATA_KEY, Gold);
            PlayerPrefs.Save();
        }
    }
    
    public class OnWalletUpdated : IEvent
    {
        public int Gold { get; set; }
    }
}