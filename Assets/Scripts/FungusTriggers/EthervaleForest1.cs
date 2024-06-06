
using Fungus;
using UnityEngine;

namespace AccrossTheEvergate
{
    public class EthervaleForest1 : MonoBehaviour
    {
        [SerializeField] private Flowchart _Chart;
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                _Chart.ExecuteBlock("Ethervale");
                _Chart.SetBooleanVariable("EF1_isDone", true);
            }
        }
    }
}
