using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AccrossTheEvergate
{
    public class PresentationManager : MonoBehaviour
    {
        public GameObject[] Cameras;
        public int currentCamera;

        private void Start()
        {
            currentCamera = 0;
        }
        // Update is called once per frame
        void Update()
        {
            MoveInPresentation();
        }

        public void MoveInPresentation()
        {
            if(Input.GetKeyDown(KeyCode.RightArrow))
            {
                if (currentCamera < Cameras.Length -1 && currentCamera >= 0)
                {
                    DeactivateCameras();
                    currentCamera++;
                }
            }
            else if(Input.GetKeyDown(KeyCode.LeftArrow))
            {
                if (currentCamera <= Cameras.Length && currentCamera > 0)
                {
                    currentCamera--;
                    ActivateCameras();
                }
            }
        }

        public void ActivateCameras()
        {
            if (Cameras[currentCamera].activeInHierarchy == false)
            {
                Cameras[currentCamera].SetActive(true);
            }
        }

        public void DeactivateCameras()
        {
            if (Cameras[currentCamera].activeInHierarchy == true)
            {
                Cameras[currentCamera].SetActive(false);
            }
        }
    }
}
