using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

namespace AccrossTheEvergate
{
    public class CinematicManager : MonoBehaviour
    {
        public VideoClip videoClip;
        private VideoPlayer videoPlayer;
        //private int currentVideoIndex = 0;

        void Start()
        {
            videoPlayer = GetComponent<VideoPlayer>();

            // Assign the video clip
            videoPlayer.clip = videoClip;

            // Play the video
            videoPlayer.Play();
        }

       /* public void PlayVideo(int index)
        {
            if (index >= 0 && index < videoClips.Count)
            {
                videoPlayer.clip = videoClips[index];
                videoPlayer.Play();
                //videoPlayer.loopPointReached += OnVideoEnded; 
                Debug.Log("Playing video: " + videoClips[index].name);
            }
            else
            {
                Debug.LogError("Video index out of range: " + index);
            }
        }*/


    }
}
