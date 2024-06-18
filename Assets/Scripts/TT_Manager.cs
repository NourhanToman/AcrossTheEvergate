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

        [Header("GameObjects")]
        [SerializeField] GameObject newMap;
        [SerializeField] GameObject currentMap;
        [SerializeField] GameObject FutureAssets;
        [SerializeField] GameObject PastAssets;
        [SerializeField] GameObject liberaryVolum;
        [SerializeField] GameObject FutureVolume;
        [SerializeField] GameObject BooksLiberary;

        [Header("Colors")]
        public Color villageFog;
        public Color liberaryFog;
        public Color hdrAmbientLightColor = new Color(0.1589609f, 0.1946179f, 0.3419144f, 1.0f);

        [Header("Settings")]
        public float SecondTransition = 7;
        public float FirstTransitoin = 2;
        public float villageFogDensity;
        public float liberaryFogDensitiy;

        [Header("Matrials")]
        public Material SkyboxPast;
        public Cubemap pastCubeMap;

        private bool phase1;
        private bool phase2;
        private bool phase3;
        private void Start()
        {
            phase1 = false;
            phase2 = false;
            phase3 = false;
        }
        private void Update()
        {
            if (phase2 == true && shad.pause == false && phase3 == false)
            {
                if (shad.distanceValue < 0.05f)
                {
                    newMap.SetActive(true);
                    PastAssets.SetActive(true);
                    FutureAssets.SetActive(false);
                    RenderSettings.skybox = SkyboxPast;
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
            if (phase1 == true && phase2 == false)
            {
                yield return new WaitForSeconds(2);
                ChangeRenderSettings();
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
                yield return new WaitForSeconds(SecondTransition);

                currentMap.SetActive(false);
                GameObject temp;
                temp = newMap;
                newMap = currentMap;
                currentMap = temp;
                this.gameObject.SetActive(false);
            }
        }
        public void ChangeRenderSettings()
        {
            RenderSettings.fogColor = villageFog;
            RenderSettings.fogDensity = villageFogDensity;
            RenderSettings.defaultReflectionMode = DefaultReflectionMode.Custom;
            RenderSettings.customReflectionTexture = pastCubeMap;
            RenderSettings.ambientMode = AmbientMode.Flat;
            RenderSettings.ambientLight = hdrAmbientLightColor;
        }
    }
}
