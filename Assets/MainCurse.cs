using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;

namespace AccrossTheEvergate
{
    public class MainCurse : MonoBehaviour, IInteractable
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
