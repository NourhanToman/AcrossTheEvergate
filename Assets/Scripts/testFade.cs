using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AccrossTheEvergate
{
    public class testFade : MonoBehaviour, IInteractable
    {
        [SerializeField] public string promptText;
        private FadeManager _fader;

        // Start is called before the first frame update
        void Start()
        {
            _fader = ServiceLocator.Instance.GetService<FadeManager>();
        }

        public string GetPrompt()
        {
            return promptText;
        }

        public void Interact()
        {
            StartCoroutine(_fader.Fade());
        }

    }
}
