using Fungus;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AccrossTheEvergate
{
    public class EverHeart_Interact : MonoBehaviour, IInteractable
    {
        [SerializeField] string promptText;
        [SerializeField] Relic relicType;
        [SerializeField] string animationStateName;
        private Animator parentAnimator;

        public Relic RelicType { get => relicType;}

        private void Start()
        {
            parentAnimator = transform.parent.GetComponent<Animator>();
        }
        public void Interact()
        {
            
            gameObject.SetActive(false);
            parentAnimator.Play(animationStateName);
            
        }

        public string GetPrompt()
        {
            return promptText;
        }
    }
}
