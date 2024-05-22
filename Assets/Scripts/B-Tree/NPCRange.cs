using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime.Tasks;
using UnityEngine.AI;
using BehaviorDesigner.Runtime;

namespace AccrossTheEvergate
{
    [TaskCategory("Behavior")]
    public class NPCRange : Action
    {
        public SharedTransform playerTransform; 
        
        public float fleeDistance = 10f; 
        public float detectionRange = 20f; 

        private NavMeshAgent navMeshAgent;
        private Transform npcTransform;
        private Animator npcAnimation;

        public override void OnStart()
        {
            navMeshAgent = GetComponent<NavMeshAgent>();
            npcAnimation = GetComponent<Animator>();
            npcTransform = transform;
        }


        public override TaskStatus OnUpdate()
        {
            if (Vector3.Distance(npcTransform.position, playerTransform.Value.position) <= detectionRange)
            {
                Vector3 fleeDirection = (npcTransform.position - playerTransform.Value.position).normalized;
                Vector3 newGoal = npcTransform.position + fleeDirection * fleeDistance;

                NavMeshHit hit;
                if (NavMesh.SamplePosition(newGoal, out hit, fleeDistance * 1.5f, NavMesh.AllAreas))
                {
                    navMeshAgent.SetDestination(hit.position);
                    npcAnimation.SetFloat("RUN", 1.0f, 0.1f, Time.deltaTime);
                    // npcAnimation.SetBool("Run",true);
                    return TaskStatus.Success;
                }


            }

            return TaskStatus.Failure;
        }

      
    }
}
