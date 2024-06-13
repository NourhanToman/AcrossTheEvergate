using Fungus;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AccrossTheEvergate
{
    public class Fungus_Update : MonoBehaviour
    {
        [SerializeField] private Flowchart _Chart;
        [SerializeField] private Flowchart _MainChart;

        [SerializeField] private string _C_EXName;
        [SerializeField] private string _C_VName;
        [SerializeField] private string _M_VName;

        private void Update()
        {
            if (_Chart.GetBooleanVariable(_C_VName))
            {
                if (!_MainChart.GetBooleanVariable(_M_VName))
                {
                    _Chart.ExecuteBlock(_C_EXName);
                }
            }
        }
    }
}
