using Fungus;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AccrossTheEvergate
{
    public class F_Trigger : MonoBehaviour
    {

        [SerializeField] private Flowchart _ETree;
        [SerializeField] private string _EXName;
        [SerializeField] private string _BName;
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                _ETree.ExecuteBlock(_EXName);
                _ETree.SetBooleanVariable(_BName, true);
            }
        }
    }
}
