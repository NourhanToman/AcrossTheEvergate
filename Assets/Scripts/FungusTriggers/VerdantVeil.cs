
using Fungus;
using UnityEngine;

namespace AccrossTheEvergate
{
    public class VerdantVeil : MonoBehaviour
    {
        [SerializeField] private Flowchart _ETree;
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                _ETree.ExecuteBlock("VerdantVeil");
                _ETree.SetBooleanVariable("VV_isDone", true);
            }
        }
    }
}

