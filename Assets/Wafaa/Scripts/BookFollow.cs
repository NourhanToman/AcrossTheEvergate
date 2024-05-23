using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AccrossTheEvergate
{
    public class BookFollow : MonoBehaviour
    {
        [SerializeField] Transform playerTransform;
        [SerializeField] float distance;
        //[SerializeField] float maxDis;
        private void Update()
        {
            if (Vector3.Distance(this.transform.position,playerTransform.position)>= distance)
                
            {
                this.transform.position= playerTransform.position;
            }
        }

    }
}
