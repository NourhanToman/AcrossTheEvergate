using UnityEngine;
using UnityEngine.UI;

public class AudioPanelController : MonoBehaviour
{
    public Slider musicSlider, SFXSlider;

    private ServiceLocator ServiceLocator => ServiceLocator.Instance;
    private AudioManager audioManager;

    private void Start() => audioManager = ServiceLocator.GetService<AudioManager>();

    public void ToggleMusic()
    {
        audioManager.PlaySFX("Button");
        audioManager.ToggleMusic();
    }

    public void ToggleSFX()
    {
        audioManager.PlaySFX("Button");
        audioManager.ToggleSFX();
    }

    public void MusicVolume()
    {
        audioManager.PlaySFX("Button");
        audioManager.MusicVolume(musicSlider.value);
    }

    public void SFXVolume()
    {
        audioManager.PlaySFX("Button");
        audioManager.SFXVolume(SFXSlider.value);
    }
}