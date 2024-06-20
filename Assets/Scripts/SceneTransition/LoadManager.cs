using Fungus;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

namespace AccrossTheEvergate
{
    public class LoadManager : MonoBehaviour
    {
        string loadingScene = "testTransition";
        private string videoPlayerObj = "VideoPlayer";
        public static LoadManager instance;
        private FadeManagerMenu _fadeManager;
        
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
            _fadeManager = ServiceLocator.Instance.GetService<FadeManagerMenu>();

        }

        public void LoadScene(int sceneIndex)
        {
            if (sceneIndex == 1)
                StartCoroutine(LoadSceneAsyncVideo(sceneIndex));
            else
                StartCoroutine(LoadSceneAsync(sceneIndex)); 
        }

        private VideoPlayer EnableVideoPlayer()
        {
            GameObject videoObject = GameObject.Find(videoPlayerObj);
            if (videoObject == null)
            {
                Debug.LogError("Video object not found: " + videoPlayerObj);
                return null;
            }

            VideoPlayer videoPlayer = videoObject.GetComponent<VideoPlayer>();
            if (videoPlayer == null)
            {
                Debug.LogError("VideoPlayer component not found on object: " + videoPlayerObj);
                return null;
            }

            videoPlayer.enabled = true;
            return videoPlayer;
        }

        IEnumerator LoadSceneAsyncVideo(int sceneIndex)
        {
            yield return StartCoroutine(_fadeManager.FadeOut());

            //Load transition scene
            SceneManager.LoadScene(loadingScene);
            yield return null;

            VideoPlayer videoPlayer = EnableVideoPlayer();

            AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(sceneIndex);
            asyncOperation.allowSceneActivation = false;

            // Wait for the transition scene to load and fade in
            /*yield return*/ StartCoroutine(_fadeManager.FadeIn());

            // Wait for the video to finish playing
            yield return StartCoroutine(WaitForVideoToEnd(videoPlayer));

            // Fade out before loading the target scene
            yield return StartCoroutine(_fadeManager.FadeOut());

            while (!asyncOperation.isDone || asyncOperation.allowSceneActivation == false)
            {
                if (asyncOperation.progress >= 0.9f)
                {
                    asyncOperation.allowSceneActivation = true;
                }
                yield return null;
            }

            // Fade in after loading the target scene
           /* yield return*/ StartCoroutine(_fadeManager.FadeIn());
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

            while (!asyncOperation.isDone)
            {
                if (asyncOperation.progress >= 0.9f)
                {
                    asyncOperation.allowSceneActivation = true;
                }
                yield return null;
            }

            //yield return null;

            // Fade in
            /*yield return*/ StartCoroutine(_fadeManager.FadeIn());
        }

        IEnumerator WaitForVideoToEnd(VideoPlayer videoPlayer)
        {
            //GameObject videoObject = GameObject.Find(videoPlayerObj);
            //if (videoObject == null)
            //{
            //    Debug.LogError("Video object not found: " + videoPlayerObj);
            //    yield break;
            //}

            //VideoPlayer videoPlayer = videoObject.GetComponent<VideoPlayer>();
            //if (videoPlayer == null)
            //{
            //    Debug.LogError("VideoPlayer component not found on object: " + videoPlayerObj);
            //    yield break;
            //}

            bool videoEnded = false;
            videoPlayer.loopPointReached += vp => videoEnded = true;

            // Wait until the video has ended
            yield return new WaitUntil(() => videoEnded);
        }

    }
}