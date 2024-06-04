using Fungus;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AccrossTheEvergate
{
    public class Stone : MonoBehaviour
    {

        [SerializeField] private Flowchart _Chart;
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                _Chart.ExecuteBlock("Stone");
                _Chart.SetBooleanVariable("SS_isDone", true);
            }
        }
    }
}
