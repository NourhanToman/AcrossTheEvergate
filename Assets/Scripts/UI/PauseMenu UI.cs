using AccrossTheEvergate;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuUI : MonoBehaviour
{
    [SerializeField] private Canvas PauseCanvas;
    [SerializeField] private RectTransform MainPanel;
    [SerializeField] private RectTransform SettingsPanel;

    private AudioManager AudioManager;

    private void Start() => AudioManager = ServiceLocator.Instance.GetService<AudioManager>();

    private void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            PauseGame();
        }
    }

    public void PauseGame()
    {
        //AudioManager.PlaySFX("Button");
        Time.timeScale = 0f;
        //set any player/input script as false
        PauseCanvas.gameObject.SetActive(true);
    }

    public void ContinueBttn()
    {
        //AudioManager.PlaySFX("Button");
        Time.timeScale = 1.0f;
        PauseCanvas.gameObject.SetActive(false);
    }

    public void MainMenuBttn()
    {
        //AudioManager.PlaySFX("Button");
        Time.timeScale = 1.0f;
        ServiceLocator.Instance.GetService<LoadManager>().LoadScene(0);//Main Menu Index
    }

    public void SettingsBttn()
    {
        //AudioManager.PlaySFX("Button");
        MainPanel.gameObject.SetActive(false);
        SettingsPanel.gameObject.SetActive(true);
    }

    public void ExitBttn()
    {
        //AudioManager.PlaySFX("Button");
        //in built ver
        Application.Quit();
    }

    //////////////

    public void ReturnToMainBttn()
    {
        //AudioManager.PlaySFX("Button");
        MainPanel.gameObject.SetActive(true);
        SettingsPanel.gameObject.SetActive(false);
    }
}