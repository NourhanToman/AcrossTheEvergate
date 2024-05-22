using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

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

        bool playerInteracting;
        IInteractable CurrentInteractable;

        private void Start()
        {
            promptUIPanel.gameObject.SetActive(false);
            playerInteracting = false;
            CurrentInteractable = null;
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
    }
}
