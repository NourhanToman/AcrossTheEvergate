using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AccrossTheEvergate
{
    //A script just to test the world map
    public class OpenArea : MonoBehaviour
    {
        [SerializeField] int AreaID;
        private WorldMap _worldMap;
        private void Start()
        {
            _worldMap = ServiceLocator.Instance.GetService<WorldMap>();
        }

        private void OnTriggerEnter(Collider other)
        {
            //_worldMap.OpenArea(AreaID);
            if(other.CompareTag("Player"))
                _worldMap.PlayerPositionOnMap(AreaID);
        }
    }
}
