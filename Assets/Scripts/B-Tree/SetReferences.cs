using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime.Tasks;
using UnityEngine.AI;
using BehaviorDesigner.Runtime;
using UnityEngine.UIElements;

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
            Vector3 origin = new Vector3(transform.position.x,transform.position.y+1.5f,transform.position.z);
            bool raycastHit = Physics.Raycast(origin, transform.forward, out hit, float.PositiveInfinity, playerLayerMask);

           // Debug.DrawLine(origin, origin + transform.forward * 100f, Color.cyan);
            if (raycastHit)
            {
                if (hit.collider != null && ((1 << hit.collider.gameObject.layer) & playerLayerMask) != 0)
                {
                    playerTransform.Value = hit.collider.transform;
                    return TaskStatus.Success;
                }
            }

            
            return TaskStatus.Failure;
        }
    }
}
