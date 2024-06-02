using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AccrossTheEvergate
{ 
    public class PlayerMapIconController : MonoBehaviour
    {
        [SerializeField] Transform playerObj;
        [SerializeField] CanvasGroup mapCanvas;
        [SerializeField] RectTransform playerIconTransform;
        [SerializeField] RectTransform mapRectTransform;
        [SerializeField] float followSpeed = 2.0f;
        [SerializeField] Terrain _terrain;
        public bool open = false;
        bool mapIsOpen = false;

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.M))
            {
                ToggleMap(open);
            }

            if (mapIsOpen)
            {
                Vector3 playerPos = PlayerPositionOnMap(playerObj.position);
                playerIconTransform.anchoredPosition = playerPos;
            }
        }

        Vector2 PlayerPositionOnMap(Vector3 player)
        {
            //terrain dimensions
            float terrainWidth = _terrain.terrainData.size.x;
            float terrainHeight = _terrain.terrainData.size.z;

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

        public void ToggleMap(bool open)
        {
            mapIsOpen = open;
            mapCanvas.alpha = open ? 1 : 0;
            mapCanvas.interactable = open;
            mapCanvas.blocksRaycasts = open;

            if (open)
            {
                playerIconTransform.anchoredPosition = PlayerPositionOnMap(playerObj.position);
            }
        }

    }
}
