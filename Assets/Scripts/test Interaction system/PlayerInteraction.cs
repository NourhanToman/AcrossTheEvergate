using System;
using System.Collections;
using System.Collections.Generic;
//using System.Diagnostics;
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
        Relic relicType;
        private InputManager _inputManager; //Rhods
        private Inventory _inventory; //Rhods

        private void OnEnable()
        {
            //InputSystem.onAnyButtonPress += OnAnyButtonPress;
            InputSystem.onDeviceChange += OnDeviceChange;
        }

        private void Start()
        {
            promptUIPanel.gameObject.SetActive(false);
            playerInteracting = false;
            CurrentInteractable = null;
            relicType = Relic.None;
            //InputUser.onChange += OnInputDeviceChanged;
            
            _inputManager = ServiceLocator.Instance.GetService<InputManager>(); //Rhods
            _inventory = ServiceLocator.Instance.GetService<Inventory>();
        }

        //or on disable check y it didn't use on e & on dis
        private void OnDestroy()
        {
            // Unregister device change events
            //InputUser.onChange -= OnInputDeviceChanged;
        }

        private void OnDisable()
        {
            InputSystem.onDeviceChange -= OnDeviceChange;
        }

        private void Update()
        {
            if (playerInteracting && CurrentInteractable != null && _inputManager.playerInteracted) //Rhods
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
                    if (other.CompareTag("Relic"))
                    {
                        if (other.gameObject.TryGetComponent(out CollectRelic relicCollected))
                        {
                            relicType = relicCollected.RelicType;
                        }
                    }
                }
            }
        }

        private void OnTriggerExit(Collider other)
        {
            promptUIPanel.SetActive(false);
            playerInteracting = false;
            CurrentInteractable = null;
            relicType = Relic.None;
        }

        private void CallInteract(IInteractable interactObject)
        { 
            interactObject.Interact();
            playerInteracting = false;
            CurrentInteractable = null;
            promptUIPanel.SetActive(false);

            if(relicType != Relic.None)
            {
                switch (relicType)
                {
                    case Relic.Bow:
                        _inventory.BowCheck = true;
                        break;
                    case Relic.Bloom:
                        _inventory.BloomCheck = true;
                        break;
                    case Relic.Heart:
                        _inventory.HeartCheck = true;
                        break;
                }
            }
        }

        private void OnDeviceChange(InputDevice device, InputDeviceChange change)
        {
            if (change == InputDeviceChange.Added || change == InputDeviceChange.Reconnected)
            {
                //UpdatePromptForDevice(device);
            }
        }

        //private void UpdatePromptForDevice(InputDevice device)
        //{
        //    if()
        //}

        //private void OnInputDeviceChanged(InputUser user, InputUserChange change, InputDevice device)
        //{
        //    // Respond to device changes
        //    if (/*change == InputUserChange.ControlSchemeChanged ||*/
        //        change == InputUserChange.DevicePaired ||
        //        change == InputUserChange.DeviceUnpaired)
        //    {
        //        CheckDevices();
        //        Debug.Log(device.ToString());
        //    }
        //}
        //Check it works
        private void CheckDevices()
        {
            bool usingKeyboardMouse = false;

            foreach (var device in InputSystem.devices)
            {
                if (device is Keyboard || device is Mouse)
                {
                    usingKeyboardMouse = true;
                    Debug.Log("true");
                }
            }

            if (usingKeyboardMouse)
            {
                promptUIKeyText.gameObject.SetActive(true);
                promptUIController.gameObject.SetActive(false);
                Debug.Log("KM");
            }
            else
            {
                promptUIKeyText.gameObject.SetActive(false);
                promptUIController.gameObject.SetActive(true);
                Debug.Log("else");
            }
        }
    }
}
