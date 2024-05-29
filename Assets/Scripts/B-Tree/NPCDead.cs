using BehaviorDesigner.Runtime;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

namespace AccrossTheEvergate
{

    public class NPCDead : MonoBehaviour
    {
       // [SerializeField] private Material _dissolveShader;
        private BehaviorTree _NPCtree;
        private NavMeshAgent _Agent;
        [SerializeField] private GameObject Arachilion;
        private DissolvingController dissolve;
        private Animator animator;
        private bool _attacked = false;
        private float _currentValue = 0f;

        private void Start()
        {
            _Agent = GetComponent<NavMeshAgent>();
            _NPCtree = GetComponent<BehaviorTree>();
            dissolve = GetComponent<DissolvingController>();
            animator = GetComponent<Animator>();
        }

        //counter for the number of attacks needed

        void Update()
        {
            /*if (_attacked)
            {
                _currentValue = Mathf.Lerp(_currentValue, 1f, 1f * Time.deltaTime);
                _dissolveShader.SetFloat("_Dissolve", _currentValue);
                if (_currentValue >= 0.9f)
                {
                    _attacked = false;

                }

            }*/
        }

     /*   private void OnTriggerEnter(Collider other)
        {
            if (other.tag == "Arrow")
            {
               // _attacked = true;
                _NPCtree.enabled = false;
                Destroy(Arachilion.gameObject);
            }
        }
*/
        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Arrow"))
            {
                Debug.Log("Attack");
                // _attacked = true;
                _Agent.speed = 0f;
                _NPCtree.enabled = false;
                animator.SetFloat("RUN", 0.0f, 0.0f, Time.deltaTime); 
                dissolve.Dissolve();
                Destroy(Arachilion.gameObject,2.0f);
            }
        }
    }
}
