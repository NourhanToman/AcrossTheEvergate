using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace AccrossTheEvergate
{
    public class WorldMap : MonoBehaviour
    {
        [SerializeField] Transform playerObj;
        [SerializeField] Canvas mapCanvas;
        [SerializeField] RectTransform playerIconTransform;
        [SerializeField] GameObject[] areaNames;
        [SerializeField] RectTransform[] areaPos;

        bool mapIsOpen;
        private InputManager _inputManager;

        private void Awake()
        {
            ServiceLocator.Instance.RegisterService<WorldMap>(this);
        }

        private void Start()
        {
            _inputManager = ServiceLocator.Instance.GetService<InputManager>();
            mapCanvas.enabled = false;
            mapIsOpen = false;
        }

        // Update is called once per frame
        void Update()
        {
            if (_inputManager.isMapOpen)
                ToggleMap();
        }

        public void PlayerPositionOnMap(int areaIndex)
        {
            if(areaIndex >= 0 && areaIndex < areaPos.Length)
            {
                playerIconTransform.anchorMin = areaPos[areaIndex].anchorMin;
                playerIconTransform.anchorMax = areaPos[areaIndex].anchorMax;
                playerIconTransform.pivot = areaPos[areaIndex].pivot;

                playerIconTransform.anchoredPosition = areaPos[areaIndex].anchoredPosition;
                playerIconTransform.sizeDelta = areaPos[areaIndex].sizeDelta;
            }
        }

        public void ToggleMap()
        {
            mapCanvas.enabled = !mapCanvas.enabled;
            mapIsOpen = mapCanvas.enabled;
            _inputManager.isMapOpen = false;
        }

        public void OpenArea(int areaId)
        {
            if (areaId >= 0 && areaId < areaNames.Length)
            {
                areaNames[areaId].gameObject.SetActive(true);
            }
        }
    }
}
