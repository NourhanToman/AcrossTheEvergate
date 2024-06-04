using Fungus;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Portal : MonoBehaviour
{
    public DistanceShader shad;
    public GameObject newMap;
    public GameObject currentMap;



    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            newMap.SetActive(true);
            this.gameObject.GetComponent<BoxCollider>().enabled = false;
            if(shad.activate == false)
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
