using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AccrossTheEvergate
{
    public class testOpen : MonoBehaviour, IInteractable
    {
        [SerializeField] public string promptText;
        //private bool doorOpened;

        private void Start()
        {
           // doorOpened = false;
        }

        public void Interact()
        {
            //Debug.Log("action");
            //if(!doorOpened) 
            //{
            //    doorOpened = true;
            //    Debug.Log("open + " + doorOpened);
            //    //animate door? switch to another scene?
            //}
            //else
            //{
            //    doorOpened = false;
            //    Debug.Log("close + " + doorOpened);
            //    //animate door? switch to another scene?
            //}
        }

        //If we will have a door that opens and closes then we have to add an on trigger stay from here to allow for this

        public string GetPrompt()
        {
            return promptText;
        }
    }
}
