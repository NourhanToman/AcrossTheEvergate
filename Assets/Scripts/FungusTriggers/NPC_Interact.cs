using Fungus;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AccrossTheEvergate
{
    public class NPC_Interact : MonoBehaviour, IInteractable
    {
        [SerializeField] public string promptText;
        [SerializeField] private Flowchart _Chart;
        [SerializeField] private string _EXName;
        public void Interact()
        {
            _Chart.ExecuteBlock(_EXName);
        }

        public string GetPrompt()
        {
            return promptText;
        }
    }
}
