using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

namespace AccrossTheEvergate
{
    public class VideoManager : MonoBehaviour
    {
        [SerializeField] VideoPlayer videoPlayer;
        [SerializeField] VideoClip[] videoClips;
        [SerializeField] GameObject renderVideoScreen;

        private void OnEnable()
        {
            videoPlayer.loopPointReached += OnVideoEnded;
        }

        private void OnVideoEnded(VideoPlayer source)
        {
            throw new NotImplementedException();
        }

        public void PlayVideo(int vidIndex)
        {
            //fadeout first
            renderVideoScreen.SetActive(true);
            videoPlayer.clip = videoClips[vidIndex];
            videoPlayer.Play();
            //fadeIn
            //StartCoroutine(DisableVideoScreen());
        }

        //private VideoPlayer.EventHandler VideoEnded(VideoPlayer vp)
        //{
        //    //fadeout first
        //    renderVideoScreen.SetActive(false);
        //    //fadein
        //}

        //IEnumerator DisableVideoScreen()
        //{
        //    if (videoPlayer.isPlaying)
        //    {
        //        yield return null;

        //    }

        //    //fadeout
        //    renderVideoScreen.SetActive(false);

        //    //fadein
        //}
    }
}
