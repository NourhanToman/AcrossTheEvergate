using UnityEngine;
using UnityEngine.UI;

public class AudioPanelController : MonoBehaviour
{
    [SerializeField] Slider musicSlider, SFXSlider;

    private ServiceLocator ServiceLocator => ServiceLocator.Instance;
    private AudioManager audioManager;
    float mixerVolumeDB;

    private void Start() 
    { 
        audioManager = ServiceLocator.GetService<AudioManager>();

        audioManager.myAudioMixer.GetFloat("AmbienceVolume", out mixerVolumeDB);
        mixerVolumeDB = Mathf.Pow(10f, mixerVolumeDB / 45f);
        musicSlider.value = Mathf.Clamp(mixerVolumeDB, 0.001f, 1f);

        audioManager.myAudioMixer.GetFloat("SFXVolume", out mixerVolumeDB);
        mixerVolumeDB = Mathf.Pow(10f, mixerVolumeDB / 45f);
        SFXSlider.value = Mathf.Clamp(mixerVolumeDB, 0.001f, 1f);
    }

    public void ToggleMusic()
    {
        //audioManager.PlaySFX("Button");
        audioManager.ToggleMusic();
    }

    public void ToggleSFX()
    {
        //audioManager.PlaySFX("Button");
        audioManager.ToggleSFX();
    }

    public void MusicVolume()
    {
        //audioManager.PlaySFX("Button");
        audioManager.MusicVolume(musicSlider.value);
    }

    public void SFXVolume()
    {
        //audioManager.PlaySFX("Button");
        audioManager.SFXVolume(SFXSlider.value);
    }
}