using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using TMPro;

[CreateAssetMenu(fileName = "NewGoal", menuName = "ScriptableObjects/Quest")]
public class Quest : ScriptableObject
{
    public List<Goal> Goals;
    public int ID;
    public Goal ActiveGoal;
    public Collect_Iteams_Goal collect;
    public TalkToNpcGoal talk;
    public string questName;
    public string description;
    public bool completed;
    public GameObject ActiveQuestUi , QuestDescription;

    public void resetGoals()
    {
        foreach (Goal goal in Goals)
        {
            if(goal.GetType() == typeof(Collect_Iteams_Goal))
            {
                Collect_Iteams_Goal collectGoal = (Collect_Iteams_Goal)goal;
                collectGoal.ResetValue();
            }
            else if (goal.GetType() == typeof(TalkToNpcGoal))
            {
                TalkToNpcGoal talkToNpcGoal = (TalkToNpcGoal)goal;
                talkToNpcGoal.ResetValue();
            }
            CheckActiveGoal();
        }
    }

    public void CheckActiveGoal()
    {
        foreach (Goal goal in Goals)
        {
            if (!goal.completed)
            {
                ActiveGoal = goal;
                return;
            }
        }
        ActiveGoal = null;
    }

    public void CheckGoals()
    {
        completed = Goals.All(g => g.completed);
    }
}
