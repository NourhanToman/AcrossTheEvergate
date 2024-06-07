using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AccrossTheEvergate
{
    public class Inventory : MonoBehaviour
    {

        bool bowCheck;
        bool bloomCheck;
        bool heartCheck;

        public bool BowCheck { get => bowCheck; set => bowCheck = value; }
        public bool BloomCheck { get => bloomCheck; set => bloomCheck = value; }
        public bool HeartCheck { get => heartCheck; set => heartCheck = value; }

        private void Awake() => ServiceLocator.Instance.RegisterService(this);

    }
}
