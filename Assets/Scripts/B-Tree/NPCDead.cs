using BehaviorDesigner.Runtime;
using Fungus;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

namespace AccrossTheEvergate
{

    public class NPCDead : MonoBehaviour
    {
        [SerializeField] private Flowchart _Chart;
        [SerializeField] private Flowchart _ARChart;
        private BehaviorTree _NPCtree;
        private NavMeshAgent _Agent;
        [SerializeField] private GameObject Arachilion;
        private DissolvingController dissolve;
        private Animator animator;
        private float _currentValue = 0f;

        private void Start()
        {
            _Agent = GetComponent<NavMeshAgent>();
            _NPCtree = GetComponent<BehaviorTree>();
            dissolve = GetComponent<DissolvingController>();
            animator = GetComponent<Animator>();
        }

        private void OnCollisionEnter(UnityEngine.Collision collision)
        {
            if (collision.gameObject.CompareTag("Arrow"))
            {
                if (_ARChart.GetBooleanVariable("isCollect"))
                {
                    _Chart.ExecuteBlock("isHit");
                    if (_currentValue <= 0)
                    {
                        _currentValue++;
                    }
                }
                else
                {
                    _Agent.speed = 0f;
                    _NPCtree.enabled = false;
                    animator.SetFloat("RUN", 0.0f, 0.0f, Time.deltaTime);
                    dissolve.Dissolve();
                    Destroy(Arachilion.gameObject, 2.0f);
                    _ARChart.ExecuteBlock("Collect");
                }
            }
        }
    }
}
