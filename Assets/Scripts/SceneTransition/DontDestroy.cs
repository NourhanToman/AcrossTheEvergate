using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AccrossTheEvergate
{
    public class DontDestroy : MonoBehaviour
    {
        private void Awake()
        {
                DontDestroyOnLoad(gameObject);
        }
    }
}
