using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewGoal", menuName = "ScriptableObjects/TalkToNpcGoal")]
public class TalkToNpcGoal : Goal
{
    public GameObject Npc;

    private void OnEnable()
    {
        ResetValue();
    }

    public void ResetValue()
    {
        completed = false;
    }

    public void ResetText(string text)
    {
        this.description = text;
    }
}
