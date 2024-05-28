using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

namespace AccrossTheEvergate
{
    [TaskCategory("Behavior")]
    public class NPCIdle : Action
    {
        private Animator animator;
        public SharedBool WithinRange;
        public override void OnStart()
        {
            if (!WithinRange.Value)
            {
                animator = GetComponent<Animator>();
            }
           
        }

        public override TaskStatus OnUpdate()
        {
            animator.SetFloat("RUN", 0.0f, 0.0f, Time.deltaTime);
            return TaskStatus.Success;
                
        }


    }
}
