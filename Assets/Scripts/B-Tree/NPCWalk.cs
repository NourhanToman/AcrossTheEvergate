using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using UnityEngine;
using UnityEngine.AI;

namespace AccrossTheEvergate
{
    [TaskCategory("Behavior")]
    public class NPCWalk : Action
    {
        private Animator animator;
        private NavMeshAgent navMeshAgent;
        public SharedVector3 destination;

        public override void OnStart()
        {
            navMeshAgent = GetComponent<NavMeshAgent>();
            animator = GetComponent<Animator>();
            navMeshAgent.SetDestination(destination.Value);
            
            // animator.SetBool("Walk", true);
        }


        public override TaskStatus OnUpdate()
        {
            animator.SetFloat("RUN", 0.5f, 0.1f, Time.deltaTime);
            if (!navMeshAgent.pathPending && navMeshAgent.remainingDistance <= 0.1f)
            {
                   // animator.SetBool("Walk", false);
                    return TaskStatus.Success;
               
            }

            return TaskStatus.Running;
        }
    }
}