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
        public SharedBool WithinRange;

        private float fleeDistance = 20f; 
        private float detectionRange = 20f; 

        private NavMeshAgent navMeshAgent;
        private Transform npcTransform;
        private Animator npcAnimation;
        public override void OnStart()
        {
           // WithinRange.Value = false;
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
                WithinRange.Value = true;
                //  Debug.Log("Within Range");
                Vector3 fleeDirection = (npcTransform.position - playerTransform.Value.position).normalized;
                Vector3 newGoal = npcTransform.position + fleeDirection * fleeDistance;

                NavMeshHit hit;
                if (NavMesh.SamplePosition(newGoal, out hit, fleeDistance * 1.5f, NavMesh.AllAreas))
                {
                    navMeshAgent.speed = 3.0f;
                    navMeshAgent.SetDestination(hit.position);
                    npcAnimation.SetFloat("RUN", 1.0f, 0.1f, Time.deltaTime);
                    // npcAnimation.SetBool("Run",true);
                    if(transform.position == hit.position)
                    {
                        WithinRange.Value = false;
                        return TaskStatus.Success;
                    }
                     
                }
                return TaskStatus.Running;
            }
            
            return TaskStatus.Failure;
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
