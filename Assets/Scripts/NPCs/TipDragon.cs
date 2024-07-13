using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace NPCs
{
    public class TipDragon : AInteractableNpc
    {
        [SerializeField] TextMeshPro _tipText;
        
        private int _interactCount = 0;
        private List<string> _tips = new List<string>
        {
            "Press <color=\"yellow\"><I>(E)</I></color> to interact with NPCs",
            "Press <color=\"yellow\"><I>(I)</I></color> to open the inventory",
            "ROAR! I'm a dragon!",
            "WOW NICE STYLE YOU GOT THERE!",
        };
        
        private void Start()
        {
            SetTip();
        }

        protected override void Interact()
        {
            SetTip();
        }

        private void SetTip()
        {
            if (_interactCount >= _tips.Count)
            {
                _interactCount = 0;
            }
            
            _tipText.text = _tips[_interactCount];
            _interactCount++;
        }
    }
}