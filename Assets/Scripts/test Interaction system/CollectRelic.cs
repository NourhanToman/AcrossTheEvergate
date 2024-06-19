using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AccrossTheEvergate
{
    public enum Relic
    {
        None =0,
        Bow=1,
        Bloom=2,
        Heart=3
    }
    public class CollectRelic : MonoBehaviour, IInteractable
    {
        [SerializeField] string promptText;
        [SerializeField] Relic relicType;
        [SerializeField] string animationStateName;
        private Animator parentAnimator;
        public Relic RelicType { get => relicType;/* set => relicType = value;*/ }

        // [SerializeField] private GameObject spellInteract;
        private void Start()
        {
            if(relicType == Relic.Heart)
                parentAnimator = transform.parent.GetComponent<Animator>();
        }
        public void Interact()
        {
          //  Instantiate(spellInteract, transform.position, Quaternion.identity);
            // questSys.increaseIteam();

            gameObject.SetActive(false);
            if(relicType == Relic.Heart)
                parentAnimator.Play(animationStateName);
        }

        public string GetPrompt()
        {
            return promptText;
        }
    }
}
