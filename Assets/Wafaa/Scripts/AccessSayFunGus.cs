using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;
using Convai;
using Convai.Scripts;
using UnityEngine.Events;

namespace AccrossTheEvergate
{
    public class AccessSayFunGus : MonoBehaviour
    {
        [SerializeField]
        ConvaiNPC ConvaiNPC;
        // public Say Say=new Say();
        Localization loc;
        UnityAction NpcPlayerText;
        private string playerText;
        private static AccessSayFunGus _instance;  // Static instance variable

        public static AccessSayFunGus Instance  // Public property for accessing the instance
        {
            get
            {
                // If the instance is null, create it and ensure it persists across scenes
                if (_instance == null)
                {
                    _instance = FindObjectOfType<AccessSayFunGus>();
                    if (_instance == null)
                    {
                        _instance = new GameObject("GameManager").AddComponent<AccessSayFunGus>();
                        DontDestroyOnLoad(_instance.transform.root);
                    }
                }

                return _instance;
            }
        }

        private void Awake()  // Awake is called before Start
        {
            // Check if another instance exists and destroy it if so (prevents duplicates)
            if (_instance != null && _instance != this)
            {
                Destroy(gameObject);
            }
        }
        private void OnEnable()
        {
            //ConvaiNPC += ConvaiNPC.HandleInputSubmission;
        }
        public void GetSay(string SayText)
        {
            playerText = SayText;
            ConvaiNPC.HandleInputSubmission(SayText);
        }
    }
}