
using Fungus;
using UnityEngine;

namespace AccrossTheEvergate
{
    public class LibraryEntrance : MonoBehaviour
    {
        [SerializeField] private Flowchart _ETree;
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                _ETree.ExecuteBlock("TMP");
               // _ETree.SetBooleanVariable("E_isDone", true);
            }
        }
    }
}

