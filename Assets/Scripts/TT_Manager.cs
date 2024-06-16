using System.Collections;
using System.Collections.Generic;
using System.Runtime.ExceptionServices;
using UnityEngine;
using UnityEngine.Rendering;

namespace AccrossTheEvergate
{
    public class TT_Manager : MonoBehaviour
    {
        public DistanceShader shad;
        public GameObject newMap;
        public GameObject currentMap;
        public GameObject[] FutureAssets;
        public GameObject[] PastAssets;
        public float SecondTransition = 7;
        public float FirstTransitoin = 2;
        public Color villageFog;
        public float villageFogDensity;
        public Color liberaryFog;
        public float liberaryFogDensitiy;
        [SerializeField] GameObject liberaryVolum;
        [SerializeField] GameObject FutureVolume;
        public bool phase1;
        public bool phase2;
        public bool phase3;
        public GameObject BooksLiberary;
        public Material SkyboxPast;
        public Cubemap pastCubeMap;
        private void Start()
        {
            phase1 = false;
            phase2 = false;
            phase3 = false;
        }
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.P))
            {
                Activate();
            }

            if (phase2 == true && shad.pause == false && phase3 == false)
            {
                if(shad.distanceValue < 0.05f)
                {
                    //shad.pause = true;
                    newMap.SetActive(true);
                    StartCoroutine(wait());
                }
            }
        }
        public void Activate()
        {
            if (phase1 == false && phase2 == false && phase3 == false)
            {
                phase1TimeTravel();
            }
            else if (phase2 == false && phase1 == true && phase3 == false)
            {
                phase2TimeTravel();
            }
            //liberaryVolum.SetActive(false);

        }

        public void phase1TimeTravel()
        {
            phase1 = true;
            if (shad.activate == false)
            {
                shad.activate = true;
            }
            else
            {
                shad.activate = false;
            }
            BooksLiberary.SetActive(false);
            StartCoroutine(wait());
        }

        public void phase2TimeTravel()
        {
            phase2 = true;
            //BooksLiberary.SetActive(true);
            if (shad.activate == false)
            {
                shad.activate = true;
            }
            else
            {
                shad.activate = false;
            }
        }
        IEnumerator wait()
        {
            if(phase1 == true && phase2 == false)
            {
                yield return new WaitForSeconds(2);
                RenderSettings.fogColor = villageFog;
                RenderSettings.fogDensity = villageFogDensity;
                RenderSettings.skybox = SkyboxPast;
                RenderSettings.defaultReflectionMode = DefaultReflectionMode.Custom;
                RenderSettings.customReflectionTexture = pastCubeMap;
                liberaryVolum.SetActive(false);
                FutureVolume.SetActive(true);
            }
            else
            {
                phase3 = true;
                yield return new WaitForSeconds(1);
                if (shad.activate == false)
                {
                    shad.activate = true;
                }
                else
                {
                    shad.activate = false;
                }
                shad.DissolveTime = shad.DissolveTime / 1.3f;
                shad.ReverseTime = shad.ReverseTime / 1.3f;
                //shad.pause = false;
                for (int i = 0; i < PastAssets.Length; i++)
                {
                    PastAssets[i].SetActive(true);
                }
                yield return new WaitForSeconds(SecondTransition);
                currentMap.SetActive(false);
                for (int i = 0; i < PastAssets.Length; i++)
                {
                    PastAssets[i].SetActive(true);
                }
                GameObject temp;
                temp = newMap;
                newMap = currentMap;
                currentMap = temp;
                this.gameObject.SetActive(false);
            }

        }
    }
}
