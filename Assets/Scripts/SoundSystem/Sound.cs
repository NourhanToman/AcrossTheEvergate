using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Sound
{
    public string name;

    public AudioClip clip;

    [Range(0, 1)]
    public float volume;

    [Range(0, 3)]
    public float pitch;

    [Range(0, 1)]
    public float spatialBlend;

    public bool playOnAwake;

    public bool isLoop;

    [Range(0,256)]
    public int priotity;

    [HideInInspector]
    public AudioSource audSrc;
}