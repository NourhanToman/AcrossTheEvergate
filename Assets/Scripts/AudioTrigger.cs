using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AccrossTheEvergate
{
    public class AudioTrigger : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                AudioManager.instance.PlaySFX("Wosh");
            }
        }
    }
}
