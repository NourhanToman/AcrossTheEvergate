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
        
        private float fleeDistance = 30f; 
        private float detectionRange = 40f; 

        private NavMeshAgent navMeshAgent;
        private Transform npcTransform;
        private Animator npcAnimation;
        private bool isSucess;
        public override void OnStart()
        {
            isSucess = false;
            navMeshAgent = GetComponent<NavMeshAgent>();
            npcAnimation = GetComponent<Animator>();
            npcTransform = transform;
        }


        public override TaskStatus OnUpdate()
        {
            /*            if (isSucess)
                        {
                            return TaskStatus.Success;
                        }*/
            if (Vector3.Distance(npcTransform.position, playerTransform.Value.position) <= detectionRange)
            {
                Debug.Log("Within Range");
                Vector3 fleeDirection = (npcTransform.position - playerTransform.Value.position).normalized;
                Vector3 newGoal = npcTransform.position + fleeDirection * fleeDistance;

                NavMeshHit hit;
                if (NavMesh.SamplePosition(newGoal, out hit, fleeDistance * 1.5f, NavMesh.AllAreas))
                {
                    navMeshAgent.speed = 2.0f;
                    navMeshAgent.SetDestination(hit.position);
                    npcAnimation.SetFloat("RUN", 1.0f, 0.1f, Time.deltaTime);
                    // npcAnimation.SetBool("Run",true);
                    return TaskStatus.Running;
                }
                //return TaskStatus.Success;

            }

            return TaskStatus.Success;
        }


        /*public override void OnTriggerEnter(Collider other)
        {
           if(other.tag == "Player")
            {
                Vector3 fleeDirection = (npcTransform.position - playerTransform.Value.position).normalized;
                Vector3 newGoal = npcTransform.position + fleeDirection * fleeDistance;

                NavMeshHit hit;
                if (NavMesh.SamplePosition(newGoal, out hit, fleeDistance * 1.5f, NavMesh.AllAreas))
                {
                    navMeshAgent.SetDestination(hit.position);
                    npcAnimation.SetFloat("RUN", 1.0f, 0.1f, Time.deltaTime);
                    // npcAnimation.SetBool("Run",true);
                    isSucess = true;    
                }

            }
        }*/

    }
}
