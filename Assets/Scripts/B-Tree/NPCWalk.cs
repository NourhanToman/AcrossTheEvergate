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
        public SharedBool WithinRange;

        public override void OnStart()
        {
            //WithinRange = false;
            navMeshAgent = GetComponent<NavMeshAgent>();
            animator = GetComponent<Animator>();
            if (!WithinRange.Value)
            {
                // animator.SetFloat("RUN", 0.5f, 0.1f, Time.deltaTime);
                navMeshAgent.speed = 1.5f;
                navMeshAgent.SetDestination(destination.Value);
            }
        }


        public override TaskStatus OnUpdate()
        {
            if (WithinRange.Value)
                return TaskStatus.Failure;

            animator.SetFloat("RUN", 0.5f, 0.1f, Time.deltaTime);
            if (!navMeshAgent.pathPending && navMeshAgent.remainingDistance <= 0.1f)
            {

                return TaskStatus.Success;

            }

            return TaskStatus.Running;
        }
    }
}