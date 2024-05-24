using System;
using System.Collections;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    [Header("Variables")]
    public float fadeDuration = 0;

    [Header("Audio Sources")]
    public AudioSource musicSource;
    public AudioSource SFXSource;
    public AudioSource dialogueSource;

    [Header("Audios")]
    public Sound[] musicSounds;
    public Sound[] SFXSounds;
    public Sound[] dialogueSounds;

    public static AudioManager instance;
    private bool justStarted;

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

        justStarted = true;
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
            if (justStarted)
            {
                Debug.Log("first");
                musicSource.clip = currentSound.clip;
                musicSource.Play();
                musicSource.volume = 1.0f;
                justStarted = false;
            }
            else
            {
                StartCoroutine(FadeOutIn(musicSource, currentSound.clip));
            }

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

    //public void PlayDialogue(string name)
    //{
    //    Sound currentSound = Array.Find(dialogueSounds, sound => sound.name == name);

    //    if (currentSound == null)
    //    {
    //        Debug.Log("Sound not found");
    //    }
    //    else
    //    {
    //        if (dialogueSource.isPlaying)
    //            dialogueSource.Stop();

    //        // Start the new music
    //        dialogueSource.clip = currentSound.clip;
    //        dialogueSource.Play();
    //    }
    //}

    ////////////////////////////////////////////
    //Functions to mute or turn on music & sfx
    public void ToggleMusic() => musicSource.mute = !musicSource.mute;

    public void ToggleSFX() => SFXSource.mute = !SFXSource.mute;

    //public void ToggleDialogue() => dialogueSource.mute = !dialogueSource.mute;

    ////////////////////////////////////////////
    //Functions to increase or decrease volume
    public void MusicVolume(float volume) => musicSource.volume = volume;

    public void SFXVolume(float volume) => SFXSource.volume = volume;

    //public void DiaolgueVolume(float volume) => dialogueSource.volume = volume;

    ///////////////////////////////////////////////////////
    // IEnumerators

    private IEnumerator FadeOutIn(AudioSource source, AudioClip clip)
    {
        float startVolume = source.volume;

        for (float t = 0; t < fadeDuration; t += Time.deltaTime)
        {
            source.volume = Mathf.Lerp(startVolume, 0, t / fadeDuration);
            yield return null;
        }

        source.volume = 0;
        source.Stop();

        //Start the new clip
        source.clip = clip;
        source.Play();

        for (float t = 0; t < fadeDuration; t += Time.deltaTime)
        {
            source.volume = Mathf.Lerp(0, startVolume, t / fadeDuration);
            yield return null;
        }

        source.volume = startVolume;
    }

}