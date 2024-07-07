using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlQuestPanal : MonoBehaviour
{
    [SerializeField] private GameObject QuestPanal;
    private InputManager _inputManager;

    private void Start() => _inputManager = ServiceLocator.Instance.GetService<InputManager>();
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            OnPanalClick();
        }
    }

    public void OnPanalClick()
    {
        if (QuestPanal.activeInHierarchy == true)
        {
            QuestPanal.SetActive(false);
        }
        else
        {
            QuestPanal.SetActive(true);
        }
    }
}
