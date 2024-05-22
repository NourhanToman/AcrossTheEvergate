using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AccrossTheEvergate
{
    public class testOpen : MonoBehaviour, IInteractable
    {
        [SerializeField] public string promptText;
        private ServiceLocator _serviceLocator;
        private LoadManager _Loader;

        private void Awake()
        {
            _serviceLocator = ServiceLocator.Instance;
        }

        private void Start() => _Loader = _serviceLocator.GetService<LoadManager>();

        public void Interact()
        {
            _Loader.LoadDungeonScene();
        }

        public string GetPrompt()
        {
            return promptText;
        }
    }
}