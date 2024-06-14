using AccrossTheEvergate;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class MainmenuUIManager : MonoBehaviour
{
    [SerializeField] private RectTransform MainPanel;
    [SerializeField] private RectTransform SettingsPanel;
    // If seperate panels
    [SerializeField] private RectTransform ControlsPanel;
    //[SerializeField] private RectTransform AudioPanel;

    [SerializeField] GameObject mainMenuFirstBttn;
    [SerializeField] GameObject settingsFirstBttn;
    [SerializeField] GameObject controlsFirstBttn;
    [SerializeField] GameObject controlsClosedBttn;
    [SerializeField] GameObject settingsClosedBttn;

    private AudioManager AudioManager;

    private void Start() 
    {
        AudioManager = ServiceLocator.Instance.GetService<AudioManager>();
        //
        //Clear selected obj 1st
        EventSystem.current.SetSelectedGameObject(null);
        //set a new select
        EventSystem.current.SetSelectedGameObject(mainMenuFirstBttn);
    }
    public void StartGameBttn()
    {
        //AudioManager.PlaySFX("Button"); //till btn sfx
        ServiceLocator.Instance.GetService<LoadManager>().LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void SettingsBttn()
    {
        //MainPanel.gameObject.SetActive(false);
        SettingsPanel.gameObject.SetActive(true);
        //AudioManager.PlaySFX("Button");

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

    public void ReturnToMainBttn()
    {
        MainPanel.gameObject.SetActive(true);
        SettingsPanel.gameObject.SetActive(false);
        //AudioManager.PlaySFX("Button");
        //AudioPanel.gameObject.SetActive(false);
        //ControlsPanel.gameObject.SetActive(false);

        //
        //Clear selected obj 1st
        EventSystem.current.SetSelectedGameObject(null);
        //set a new select
        EventSystem.current.SetSelectedGameObject(settingsClosedBttn);
    }

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
}