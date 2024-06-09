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
        [SerializeField] RectTransform mapRectTransform;
       // [SerializeField] Terrain _terrain;
        [SerializeField] GameObject[] areaNames;
        bool mapIsOpen;
        private InputManager _inputManager;
        int areaIndex;

        private void Awake()
        {
            ServiceLocator.Instance.RegisterService<WorldMap>(this);
        }

        private void Start()
        {
            _inputManager = ServiceLocator.Instance.GetService<InputManager>();
            mapCanvas.enabled = false;
            mapIsOpen = false;
            areaIndex = 1;
        }

        // Update is called once per frame
        void Update()
        {
            if (_inputManager.isMapOpen)
                ToggleMap();

            if (mapIsOpen)
            {
                Vector3 playerPos = PlayerPositionOnMap(playerObj.position);
                playerIconTransform.anchoredPosition = playerPos;
            }
        }

        Vector2 PlayerPositionOnMap(Vector3 player)
        {
            //terrain dimensions
            float terrainWidth = 1250f;//937.5f
            float terrainHeight = 1000f;//875f

            //convert
            float normalizedX = player.x / terrainWidth;
            float normalizedZ = player.z / terrainHeight;

            //to map coord
            float mapWidth = mapRectTransform.rect.width;
            float mapHeight = mapRectTransform.rect.height;

            //scale
            float mapX = normalizedX * mapWidth;
            float mapZ = normalizedZ * mapHeight;

            return new Vector2(mapX, mapZ);
        }

        public void ToggleMap()
        {
            mapCanvas.enabled = !mapCanvas.enabled;
            mapIsOpen = mapCanvas.enabled;

            if (mapIsOpen)
            {
                playerIconTransform.anchoredPosition = PlayerPositionOnMap(playerObj.position);
            }

            _inputManager.isMapOpen = false;
        }

        public void OpenArea(int areaId)
        {
            if(areaId == areaIndex)
            {
                areaNames[areaIndex].gameObject.SetActive(true);
                areaIndex++;
            }
            
        }
    }
}
