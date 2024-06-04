using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AccrossTheEvergate
{
    public class TT_Manager : MonoBehaviour
    {
        public DistanceShader shad;
        public GameObject newMap;
        public GameObject currentMap;

        public void Activate()
        {
            
                newMap.SetActive(true);
               // this.gameObject.GetComponent<BoxCollider>().enabled = false;
                if (shad.activate == false)
                {
                    shad.activate = true;
                }
                else
                {
                    shad.activate = false;
                }
                //playerController.enabled = false;
                StartCoroutine(wait());

            
        }

        IEnumerator wait()
        {
            yield return new WaitForSeconds(7);
            currentMap.SetActive(false);
            GameObject temp;
            temp = newMap;
            newMap = currentMap;
            currentMap = temp;
            this.gameObject.SetActive(false);
        }
    }
}
