using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace AccrossTheEvergate
{
    public class WorldMapOG : MonoBehaviour
    {
        public RectTransform mapImage;  // The UI element for the map background (RectTransform)
        public RectTransform playerIcon;  // The UI element for the player icon (RectTransform)
        public Transform player;  // Reference to the player in the world

        public Vector2 terrainSize;  // Size of the terrain in world space
        public Vector2 mapSize;  // Size of the map in UI space

        void Update()
        {
            UpdatePlayerPosition();
        }

        void UpdatePlayerPosition()
        {
            // Get player's current position in world space
            Vector3 playerWorldPosition = player.position;

            // Normalize the player's position relative to the terrain size
            float normalizedX = (playerWorldPosition.x / terrainSize.x);
            float normalizedZ = (playerWorldPosition.z / terrainSize.y);

            // Convert normalized position to map coordinates
            float mapX = normalizedX * mapSize.x;
            float mapY = normalizedZ * mapSize.y;

            // Set the player's icon position on the map
            playerIcon.anchoredPosition = new Vector2(mapX, mapY);
        }
    }
}
