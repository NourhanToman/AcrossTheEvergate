using Fungus;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AccrossTheEvergate
{
    public class Past : MonoBehaviour
    {

        [SerializeField] private Flowchart _Chart;
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                _Chart.ExecuteBlock("Past");
                _Chart.SetBooleanVariable("P_isDone", true);
            }
        }
    }
}
