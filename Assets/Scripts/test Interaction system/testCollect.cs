using Fungus;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AccrossTheEvergate
{
    public class testCollect : MonoBehaviour, IInteractable
    {

        [SerializeField] public string promptText;
        [SerializeField] public Flowchart _Chart;
        [SerializeField] private string _EXName;
        // [SerializeField] private string _BName;
        private QuestSystem questSys;
        private void Start() => questSys = ServiceLocator.Instance.GetService<QuestSystem>();
        public void Interact()
        {
            questSys.increaseIteam();
            gameObject.SetActive(false);
            if (questSys.CurrentAmount()>=5)
            {
                _Chart.ExecuteBlock(_EXName);
            }

        }

        public string GetPrompt()
        {
            return promptText;
        }

    }
}
