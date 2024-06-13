using Fungus;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AccrossTheEvergate
{
    public class StonePuzzle : MonoBehaviour
    {

        [SerializeField] private Flowchart _Chart;

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
