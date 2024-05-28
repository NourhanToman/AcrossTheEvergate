using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Users;
using UnityEngine.UI;

namespace AccrossTheEvergate
{
    public interface IInteractable
    {
        public void Interact();
        public string GetPrompt();
    }
    public class PlayerInteraction : MonoBehaviour
    {
        [SerializeField] LayerMask interactionLayer;
        [SerializeField] GameObject promptUIPanel;
        [SerializeField] TextMeshProUGUI promptUIText;
        [SerializeField] TextMeshProUGUI promptUIKeyText;
        [SerializeField] Image promptUIController;
        
        bool playerInteracting;
        IInteractable CurrentInteractable;
        

        private void Start()
        {
            promptUIPanel.gameObject.SetActive(false);
            playerInteracting = false;
            CurrentInteractable = null;
            InputUser.onChange += OnInputDeviceChanged;
        }

        //or on disable check y it didn't use on e & on dis
        private void OnDestroy()
        {
            // Unregister device change events
            InputUser.onChange -= OnInputDeviceChanged;
        }

        private void Update()
        {
            if (playerInteracting && CurrentInteractable != null && InputManager.instance.playerInteracted)
            {
                CallInteract(CurrentInteractable);
            }
        }
        private void OnTriggerEnter(Collider other)
        {
            if (((1 << other.gameObject.layer) & interactionLayer) != 0)
            {
                if (other.gameObject.TryGetComponent(out IInteractable InteractObj))
                {
                    playerInteracting = true;
                    CurrentInteractable = InteractObj;
                    promptUIText.text = CurrentInteractable.GetPrompt();
                    promptUIPanel.SetActive(true);
                }
            }
        }

        private void OnTriggerExit(Collider other)
        {
            promptUIPanel.SetActive(false);
            playerInteracting = false;
            CurrentInteractable = null;
        }

        private void CallInteract(IInteractable interactObject)
        {
            interactObject.Interact();
            playerInteracting = false;
            CurrentInteractable = null;
            promptUIPanel.SetActive(false);
        }

        private void OnInputDeviceChanged(InputUser user, InputUserChange change, InputDevice device)
        {
            // Respond to device changes
            if (/*change == InputUserChange.ControlSchemeChanged ||*/
                change == InputUserChange.DevicePaired ||
                change == InputUserChange.DeviceUnpaired)
            {
                CheckDevices();
            }
        }
        //Check it works
        private void CheckDevices()
        {
            //throw new NotImplementedException();
            bool usingKeyboardMouse = false;

            foreach (var device in InputSystem.devices)
            {
                if (device is Keyboard || device is Mouse)
                {
                    usingKeyboardMouse = true;
                }
            }

            if (usingKeyboardMouse)
            {
                promptUIKeyText.gameObject.SetActive(true);
                promptUIController.gameObject.SetActive(false);
            }
            else
            {
                promptUIKeyText.gameObject.SetActive(false);
                promptUIController.gameObject.SetActive(true);
            }
        }
    }
}
