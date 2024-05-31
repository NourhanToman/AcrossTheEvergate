
using Fungus;
using UnityEngine;

namespace AccrossTheEvergate
{
    public class EthervaleForest : MonoBehaviour
    {
        [SerializeField] private Flowchart _EForest;
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                _EForest.ExecuteBlock("Ethervale1");
                _EForest.SetBooleanVariable("EF_isDone", true);
            }
        }
    }
}
