using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AccrossTheEvergate
{
    public class SmallCurse : MonoBehaviour
    {
        private Animator anim;
        private void Start()
        {
            anim = GetComponent<Animator>();
        }
        public void Interact()
        {
            anim.SetTrigger("BreakCurse");
        }

        public string GetPrompt()
        {
            return "";
        }
    }
}
