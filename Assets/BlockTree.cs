using Fungus;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AccrossTheEvergate
{
    public class BlockTree : MonoBehaviour
    {
        private Animator m_Animator;
        [SerializeField] Flowchart _Chart;
        [SerializeField] string _EBName;

        private void Start()
        {
            m_Animator = GetComponentInParent<Animator>();
        }
        private void OnTriggerExit(Collider other)
        {
           if (other.gameObject.CompareTag("Player") && Vector3.Distance(other.transform.position , this.transform.position) > 10)
           {
               
              
                _Chart.ExecuteBlock(_EBName);
                m_Animator.SetTrigger("Play");
                //Destroy(gameObject);
            }
        }
    }
}
