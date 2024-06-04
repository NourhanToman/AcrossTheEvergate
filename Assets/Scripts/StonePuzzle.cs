using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AccrossTheEvergate
{
    public class StonePuzzle : MonoBehaviour
    {

        private bool isSolved = false;
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                Vector3 ThisForward = transform.forward;
                Vector3 OtherForward = other.transform.forward;
                if(Vector3.Dot(ThisForward,OtherForward) > 0.9f)
                {
                    Debug.Log("Puzzle Solved");
                    isSolved = true;
                }
               /* else
                {
                    Debug.Log("Dot answer: " + Vector3.Dot(ThisForward, OtherForward));
                }*/
            }
        }
    }
}
