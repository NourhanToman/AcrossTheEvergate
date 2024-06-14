using AccrossTheEvergate;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class PauseMenuUI : MonoBehaviour
{
    [SerializeField] private Canvas PauseCanvas;
    [SerializeField] private RectTransform MainPanel;
    [SerializeField] private RectTransform SettingsPanel;
    [SerializeField] private RectTransform ControlsPanel;
    //
    [SerializeField] GameObject pauseFirstBttn;
    [SerializeField] GameObject settingsFirstBttn;
    [SerializeField] GameObject controlsFirstBttn;
    [SerializeField] GameObject controlsClosedBttn;
    [SerializeField] GameObject settingsClosedBttn;

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
        //
        //Clear selected obj 1st
        EventSystem.current.SetSelectedGameObject(null);
        //set a new select
        EventSystem.current.SetSelectedGameObject(pauseFirstBttn);
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
        //
        //Clear selected obj 1st
        EventSystem.current.SetSelectedGameObject(null);
        //set a new select
        EventSystem.current.SetSelectedGameObject(settingsFirstBttn);
    }

    public void ControlsBttn()
    {
        SettingsPanel.gameObject.SetActive(false);
        ControlsPanel.gameObject.SetActive(true);
        //AudioManager.PlaySFX("Button");

        //
        //Clear selected obj 1st
        EventSystem.current.SetSelectedGameObject(null);
        //set a new select
        EventSystem.current.SetSelectedGameObject(controlsFirstBttn);
    }

    public void ExitBttn()
    {
        //AudioManager.PlaySFX("Button");
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    //////////////

    public void ReturnToSettingsBttn()
    {
        //MainPanel.gameObject.SetActive(true);
        SettingsPanel.gameObject.SetActive(true);
        //AudioManager.PlaySFX("Button");
        //AudioPanel.gameObject.SetActive(false);
        ControlsPanel.gameObject.SetActive(false);

        //
        //Clear selected obj 1st
        EventSystem.current.SetSelectedGameObject(null);
        //set a new select
        EventSystem.current.SetSelectedGameObject(controlsClosedBttn);
    }

    public void ReturnToMainBttn()
    {
        //AudioManager.PlaySFX("Button");
        MainPanel.gameObject.SetActive(true);
        SettingsPanel.gameObject.SetActive(false);

        //
        //Clear selected obj 1st
        EventSystem.current.SetSelectedGameObject(null);
        //set a new select
        EventSystem.current.SetSelectedGameObject(settingsClosedBttn);
    }
}