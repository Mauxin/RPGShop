using System;
using System.Collections.Generic;
using UnityEngine;

namespace EventSystem
{
    public interface IEvent { }

    public class EventManager : MonoBehaviour {

        private Dictionary<Type, Action<IEvent>> eventDictionary;

        private static EventManager Instance { get; set; }
        
        private void Awake() 
        {
            if (Instance != null && Instance != this) 
            { 
                Destroy(this); 
            } 
            else 
            { 
                Instance = this; 
                Instance.Setup();
            } 
        }

        private void Setup()
        {
            DontDestroyOnLoad(gameObject);
            eventDictionary ??= new Dictionary<Type, Action<IEvent>>();
        }

        public static void Subscribe<T>(Action<IEvent> listener) where T : IEvent
        {
            var eventType = typeof(T);
            
            if (Instance.eventDictionary.TryAdd(eventType, listener)) return;
            
            Instance.eventDictionary[eventType] += listener;
        }

        public static void Unsubscribe<T>(Action<IEvent> listener) where T : IEvent
        {
            var eventType = typeof(T);
            
            if (Instance == null) return;
            if (!Instance.eventDictionary.ContainsKey(eventType)) return;
            
            Instance.eventDictionary[eventType] -= listener;
        }

        public static void Trigger(IEvent eventInstance)
        {
            if (!Instance.eventDictionary.TryGetValue(eventInstance.GetType(), out var thisEvent)) return;

            thisEvent.Invoke(eventInstance);
        }
    }
}