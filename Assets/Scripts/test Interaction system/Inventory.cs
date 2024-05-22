using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AccrossTheEvergate
{
    public class Inventory : MonoBehaviour
    {
        public int NumberOfRelics { get; private set; }
        public int NumberOfPlants { get; private set; }
        public bool Grimore { get; private set; }

        private void Awake() => ServiceLocator.Instance.RegisterService(this);


    }
}
