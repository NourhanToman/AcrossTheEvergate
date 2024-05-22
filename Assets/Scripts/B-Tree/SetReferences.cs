using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime.Tasks;
using UnityEngine.AI;
using BehaviorDesigner.Runtime;
namespace AccrossTheEvergate
{
    [TaskCategory("Behavior")]
    public class SetReferences : Action
    {
        public SharedTransform playerTransform; 
        public LayerMask playerLayerMask; 

        public override TaskStatus OnUpdate()
        {
            
            RaycastHit hit;
            bool raycastHit = Physics.Raycast(transform.position, transform.forward, out hit, float.PositiveInfinity, playerLayerMask);

            if (raycastHit)
            {          
                if (hit.collider != null && ((1 << hit.collider.gameObject.layer) & playerLayerMask) != 0)
                {
                    playerTransform.Value = hit.collider.transform;
                    return TaskStatus.Success;
                }
            }

            
            return TaskStatus.Running;
        }
    }
}
