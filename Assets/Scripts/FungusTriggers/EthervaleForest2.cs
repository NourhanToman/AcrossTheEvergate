
using Fungus;
using UnityEngine;

namespace AccrossTheEvergate
{
    public class EthervaleForest2 : MonoBehaviour
    {
        [SerializeField] private Flowchart _EForest;
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                _EForest.ExecuteBlock("Ethervale");
                _EForest.SetBooleanVariable("EF2_isDone", true);
            }
        }
    }
}
