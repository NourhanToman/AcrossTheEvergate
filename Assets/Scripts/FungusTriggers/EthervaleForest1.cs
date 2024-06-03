
using Fungus;
using UnityEngine;

namespace AccrossTheEvergate
{
    public class EthervaleForest1 : MonoBehaviour
    {
        [SerializeField] private Flowchart _EForest;
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                _EForest.ExecuteBlock("EthervaleForest1");
                _EForest.SetBooleanVariable("EF1_isDone", true);
            }
        }
    }
}
