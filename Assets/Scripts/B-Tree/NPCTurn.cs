using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using UnityEngine;
using UnityEngine.AI;

namespace AccrossTheEvergate
{
    [TaskCategory("Behavior")]
    public class NPCTurn : Action
    {
        //private Animator animator;
        private NavMeshAgent navMeshAgent;

        public SharedVector3 destination;
        public SharedBool WithinRange;

        public override void OnStart()
        {
            //animator = GetComponent<Animator>();
            navMeshAgent = GetComponent<NavMeshAgent>();
            if (!WithinRange.Value)
            {
                SetRandomDestination();
            }
        }

        private void SetRandomDestination()
        {
            Vector3 randomDirection = Random.insideUnitSphere * 40.0f;
            randomDirection += transform.position;

            if (NavMesh.SamplePosition(randomDirection, out NavMeshHit hit, 40.0f, NavMesh.AllAreas))
            {
                destination.Value = hit.position;
               // animator.SetTrigger("Turn");
                TurnTowardsDestination();
            }
        }

        private void TurnTowardsDestination()
        {
            Vector3 direction = (destination.Value - transform.position).normalized;
            Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * navMeshAgent.angularSpeed);
        }
    }
}