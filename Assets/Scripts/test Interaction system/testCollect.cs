using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AccrossTheEvergate
{
    public class testCollect : MonoBehaviour, IInteractable
    {
        [SerializeField] public string promptText;
        //event of the object/quest/objective
        private ServiceLocator _serviceLocator;
        private Inventory _inventory;

        private void Awake()
        {
            _serviceLocator = ServiceLocator.Instance;
        }

        private void Start() => _inventory = _serviceLocator.GetService<Inventory>();

        public void Interact()
        {
            //Debug.Log("collect");
            //invoke the event to trigger it being collected and increase inventory and trigger quest from there or the event of the quest to increase its count
            //if it's the AI then make the player its parent
            gameObject.SetActive(false);
        }

        public string GetPrompt()
        {
            return promptText;
        }
    }
}
