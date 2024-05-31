
using Fungus;
using UnityEngine;

namespace AccrossTheEvergate
{
    public class EthervaleTree : MonoBehaviour
    {
        [SerializeField] private Flowchart _ETree;
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                _ETree.ExecuteBlock("Ethervale2");
                _ETree.SetBooleanVariable("ET_isDone", true);
            }
        }
    }
}

