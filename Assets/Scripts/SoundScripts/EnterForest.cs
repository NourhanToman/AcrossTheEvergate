using BehaviorDesigner.Runtime.Tasks.Unity.UnityVector2;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AccrossTheEvergate
{
    public class EnterForest : MonoBehaviour
    {
        private AudioManager m_AudioManager;
        private bool inForest;
        private bool inVillage;

        private void Start()
        {
            m_AudioManager = ServiceLocator.Instance.GetService<AudioManager>();
            inForest = false;
            inVillage = false;
        }

        private void OnTriggerExit(Collider other)
        {
            if(other.gameObject.CompareTag("Player"))
            {
                if(Vector3.Distance(transform.position,other.transform.position) < 15 && inForest == false)
                {
                    Debug.Log(Vector3.Distance(transform.position, other.transform.position));
                    m_AudioManager.PlayMusic("ForestAmbience");
                    inForest = true;
                    inVillage = false;
                }
                else if (inVillage == false)
                {
                    Debug.Log(Vector3.Distance(transform.position, other.transform.position));
                    m_AudioManager.PlayMusic("PastVillage");
                    inForest = false;
                    inVillage = true;
                }
            }
        }
    }
}
