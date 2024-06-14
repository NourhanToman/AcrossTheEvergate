using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AccrossTheEvergate
{
    public class SpawnObj : MonoBehaviour
    {
       
       // public Vector3 spawnPosition;


        public void SpawnRelic(GameObject Relic)
        {
            Instantiate(Relic, transform.position, Relic.transform.rotation, transform);
        }
    }
}
