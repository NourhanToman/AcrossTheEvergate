using Fungus;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace AccrossTheEvergate
{
    public class LoadManager : MonoBehaviour
    {
        string loadingScene = "testTransition";
        public static LoadManager instance;
        private tempFade _fadeManager;
        //[SerializeField] private Flowchart load;

        private void Awake()
        {
            if (instance != null && instance != this)
            {
                // If an instance already exists and it's not this one, destroy this one
                Destroy(gameObject);
            }
            else
            {
                // If no instance exists, set this one as the instance
                instance = this;
                ServiceLocator.Instance.RegisterService(this);
                DontDestroyOnLoad(gameObject); // Make this object persist across scenes
            }

        }

        private void Start()
        {
            _fadeManager = ServiceLocator.Instance.GetService<tempFade>();

        }

        public void LoadScene(int sceneIndex)
        {
            //load.ExecuteBlock("Load");
            StartCoroutine(LoadSceneAsync(sceneIndex)); 
        }

        IEnumerator LoadSceneAsync(int sceneIndex)
        {
            //FadeOut
            yield return StartCoroutine(_fadeManager.FadeOut());

            //Load transition scene
            SceneManager.LoadScene(loadingScene);
            yield return null;
            
            //load the other scene
            AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(sceneIndex);
            asyncOperation.allowSceneActivation = false;
            //Debug.Log("here");
            while (!asyncOperation.isDone)
            {
                if (asyncOperation.progress >= 0.9f)
                {
                    asyncOperation.allowSceneActivation = true;
                }
                yield return null;
            }

            //Fade in
            yield return null;

            // Fade in
            /*yield return */StartCoroutine(_fadeManager.FadeIn());
        }

    }
}