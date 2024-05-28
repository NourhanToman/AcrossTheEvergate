using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlQuestPanal : MonoBehaviour
{
    [SerializeField] private GameObject QuestPanal;

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Q))
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
