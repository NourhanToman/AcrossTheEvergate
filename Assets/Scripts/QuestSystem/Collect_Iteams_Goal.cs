using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewGoal", menuName = "ScriptableObjects/Collect_Iteams_Goal")]
public class Collect_Iteams_Goal : Goal
{
    public int currentAmount;
    public int requirdAmount;

    public virtual void UpdateProgress()
    {
        if (currentAmount >= requirdAmount)
        {
            completed = true;
        }
    }

    public void increaseAmount()
    {
        currentAmount++;
        UpdateProgress();
    }

    public void ResetValue()
    {
        currentAmount = 0;
        completed = false;
    }

    public void SetDescription(string description)
    {
        this.description = description;
    }

    public void SetRequiredAmount(int amount)
    {
        requirdAmount = amount;
    }
}
