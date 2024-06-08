using Fungus;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AccrossTheEvergate
{
    public class StonePuzzle : MonoBehaviour
    {

        [SerializeField] private Flowchart _Chart;
        [SerializeField] private Flowchart _MainChart;

        private void Update()
        {
            if (_Chart.GetBooleanVariable("SSP_isDone"))
            {
                if (!_MainChart.GetBooleanVariable("Interacted"))
                {
                    _Chart.ExecuteBlock("InteractLoop");
                }
            }
        }

        private void OnTriggerStay(Collider other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                Vector3 ThisForward = transform.forward;
                Vector3 OtherForward = other.transform.forward;
                if (Vector3.Dot(ThisForward, OtherForward) > 0.9f)
                {
                    _Chart.ExecuteBlock("SSPuzzle");

                }
            }
        }
       
    }
}
