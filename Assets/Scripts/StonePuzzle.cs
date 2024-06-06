using Fungus;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AccrossTheEvergate
{
    public class StonePuzzle : MonoBehaviour
    {

       // private bool isSolved = false;
        [SerializeField] private Flowchart _Chart;

        /*     private void OnTriggerStay(Collider other)
             {
                 if (other.gameObject.CompareTag("Player"))
                 {
                     Vector3 ThisForward = transform.forward;
                     Vector3 OtherForward = other.transform.forward;
                     if (Vector3.Dot(ThisForward, OtherForward) > 0.9f)
                     {
                         // Debug.Log("Puzzle Solved");
                         // isSolved = true;
                         _Chart.SetBooleanVariable("SSP_isDone", true);
                         _Chart.ExecuteBlock("SSPuzzle");

                     }
                     *//* else
                      {
                          Debug.Log("Dot answer: " + Vector3.Dot(ThisForward, OtherForward));
                      }*//*
                 }
             }*/
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                Vector3 ThisForward = transform.forward;
                Vector3 OtherForward = other.transform.forward;
                if (Vector3.Dot(ThisForward, OtherForward) > 0.9f)
                {
                     Debug.Log("Puzzle Solved");
                    // isSolved = true;
                    _Chart.SetBooleanVariable("SSP_isDone", true);
                    _Chart.ExecuteBlock("SSPuzzle");

                }
                else
                {
                    Debug.Log("Dot answer: " + Vector3.Dot(ThisForward, OtherForward));
                }
            }
        }
    }
}
