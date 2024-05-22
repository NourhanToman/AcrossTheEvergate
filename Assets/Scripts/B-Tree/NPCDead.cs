using BehaviorDesigner.Runtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AccrossTheEvergate
{

    public class NPCDead : MonoBehaviour
    {
        [SerializeField] private Material _dissolveShader;
        [SerializeField] private BehaviorTree _NPCtree;
        
        private bool _attacked = false;
        private float _currentValue = 0f;
        
        //counter for the number of attacks needed
      
        void Update()
        {
            if (_attacked)
            {
                _currentValue = Mathf.Lerp(_currentValue, 1f, 1f * Time.deltaTime);
                _dissolveShader.SetFloat("_Dissolve", _currentValue);
                if (_currentValue >= 0.9f)
                {
                    _attacked = false;

                }

            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.tag == "Arrow")
            {
                _attacked = true;
                _NPCtree.enabled = false;
            }
        }
    }
}
