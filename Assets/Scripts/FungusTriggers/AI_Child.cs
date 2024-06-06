using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AccrossTheEvergate
{
    public class AI_Child : MonoBehaviour
    {
        [SerializeField] GameObject parentObject;  
        [SerializeField] GameObject childObject;

       
        public void SetChildAndReset()
        {
            if (parentObject != null && childObject != null)
            {
                
                childObject.transform.SetParent(parentObject.transform);

                
                childObject.transform.localPosition = Vector3.zero;
                childObject.transform.localRotation = Quaternion.identity;
                childObject.transform.localScale = Vector3.one;

                
                Vector3 newPosition = childObject.transform.localPosition;
                newPosition.y = 0.09f;
                childObject.transform.localPosition = newPosition;
            }
            
        }
    }
}
