using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("Audio Sources")]
    public AudioSource musicSource;
    public AudioSource SFXSource;

    [Header("Audios")]
    public Sound[] musicSounds;
    public Sound[] SFXSounds;

    public static AudioManager instance;

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

    private void Start() => PlayMusic("Theme");
    

    ////////////////////////////////////////////
    //Functions to play music & sfx
    public void PlayMusic(string name)
    {
        Sound currentSound = Array.Find(musicSounds, sound => sound.name == name);

        if (currentSound == null)
        {
            Debug.Log("Sound not found");
        }
        else
        {
            if (musicSource.isPlaying)
                musicSource.Stop();

            // Start the new music
            musicSource.clip = currentSound.clip;
            musicSource.Play();
        }
    }

    public void PlaySFX(string name)
    {
        Sound currentSound = Array.Find(SFXSounds, sound => sound.name == name);

        if (currentSound == null)
        {
            Debug.Log("Sound not found");
        }
        else
        {
            SFXSource.clip = currentSound.clip;
            SFXSource.Play();
        }
    }

    ////////////////////////////////////////////
    //Functions to mute or turn on music & sfx
    public void ToggleMusic() => musicSource.mute = !musicSource.mute;

    public void ToggleSFX() => SFXSource.mute = !SFXSource.mute;

    ////////////////////////////////////////////
    //Functions to increase or decrease volume
    public void MusicVolume(float volume) => musicSource.volume = volume;

    public void SFXVolume(float volume) => SFXSource.volume = volume;
}