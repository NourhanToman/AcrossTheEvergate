using Fungus;
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
        [SerializeField] private Flowchart _Chart;


        public bool BowCheck { get => bowCheck; set => bowCheck = value; }
        public bool BloomCheck { get => bloomCheck; set => bloomCheck = value; }
        public bool HeartCheck { get => heartCheck; set => heartCheck = value; }

        private void Awake() => ServiceLocator.Instance.RegisterService(this);

        public void isBow() { if (BowCheck)  _Chart.SetBooleanVariable("isBow",true); }
        public void isBloom() { if (BloomCheck)  _Chart.SetBooleanVariable("isBloom", true);}
        public void isHeart() {  if(HeartCheck)  _Chart.SetBooleanVariable("isHeart", true);}
    }
}
