using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AccrossTheEvergate
{
    public class testCollect : MonoBehaviour, IInteractable
    {
        [SerializeField] public string promptText;
        public void Interact()
        {
            //Debug.Log("collect");
            gameObject.SetActive(false);
        }

        public string GetPrompt()
        {
            return promptText;
        }
    }
}
