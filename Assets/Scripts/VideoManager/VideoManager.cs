using System;
using System.Collections;
using System.Collections.Generic;
//using UnityEditor.Rendering.LookDev;
using UnityEngine;
using UnityEngine.Video;

namespace AccrossTheEvergate
{
    public class VideoManager : MonoBehaviour
    {
        [SerializeField] VideoPlayer videoPlayer;
        [SerializeField] GameObject renderVideoScreen;
        [SerializeField] RenderTexture defaultRenderTexture;
        [SerializeField] VideoClip[] videoClips;

        private FadeManagerMenu _FadeManager; //Replace it with FadeManagerMenu 
        private void OnEnable()
        {
            videoPlayer.loopPointReached += OnVideoEnded;
        }

        private void Start() => _FadeManager = ServiceLocator.Instance.GetService<FadeManagerMenu>();

        public void PlayVideo(int vidIndex)
        {
            StartCoroutine(CinematicSatrt(vidIndex));
            //if (vidIndex == 0)
            //{
            //    videoPlayer.Play();
            //}
            //else
            //{
            //    StartCoroutine(CinematicSatrt(vidIndex));
            //}
        }

        private void OnVideoEnded(VideoPlayer source)
        {
            StartCoroutine(CinematicEnded());
        }

        IEnumerator CinematicEnded()
        {
            //Fade out to black
            yield return StartCoroutine(_FadeManager.FadeOut());

            //Empty the video player and the texture
            videoPlayer.clip = null;
            defaultRenderTexture.Release();

            yield return StartCoroutine(_FadeManager.FadeIn());
        }

        IEnumerator CinematicSatrt(int vidIndex)
        {
            //FadeOut
            yield return StartCoroutine(_FadeManager.FadeOut());

            //Assign the cinematic and start fade in to the screen
            videoPlayer.clip = videoClips[vidIndex];
            StartCoroutine(_FadeManager.FadeIn());

            videoPlayer.Play();

        }

    }
}
