using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuUI : MonoBehaviour
{
    public void startBttn()
    {
        SceneManager.LoadSceneAsync(0);
       // SceneManager.LoadSceneAsync("Scene1", LoadSceneMode.Additive);
    }
}
