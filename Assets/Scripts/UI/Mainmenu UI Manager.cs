using AccrossTheEvergate;
using UnityEngine;
using UnityEngine.SceneManagement;
//

public class MainmenuUIManager : MonoBehaviour
{
    [SerializeField] private RectTransform MainPanel;
    [SerializeField] private RectTransform SettingsPanel;
    // If seperate panels
    //[SerializeField] private RectTransform ControlsPanel;
    //[SerializeField] private RectTransform AudioPanel;

    private AudioManager AudioManager;

    private void Start() => AudioManager = ServiceLocator.Instance.GetService<AudioManager>();

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
    }
}