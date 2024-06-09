using Fungus;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AccrossTheEvergate
{
    public class F_Trigger : MonoBehaviour
    {
       
        [SerializeField] private Flowchart _Chart;
        [SerializeField] private string _EXName;
        [SerializeField] private string _BName;
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                _Chart.ExecuteBlock(_EXName);
                _Chart.SetBooleanVariable(_BName, true);
            }
        }
    }
}
