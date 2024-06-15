using Fungus;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class QuestSystem : MonoBehaviour
{

   public List<Quest> QuestList;
   public Quest activeQuest;
   private Quest endQuest;
   public int currentQuest;
   public GameObject questPanal;
   private Image _imgPanel;
   public List<Sprite> _questPanel;
   public int nextQuestId;
    //public Flowchart fungusFlowChars;
    // Start is called before the first frame update
    protected Collect_Iteams_Goal collect;

    private void Awake()
    {
        ServiceLocator.Instance.RegisterService(this);
    }

    void Start()
    {
        resetQuests();
        currentQuest = 0;
        _imgPanel = questPanal.GetComponent<Image>();
        SetNewActiveQuest();
       
    }
    public void CompleteChooiseQuest(int id, int index)
    {
        activeQuest.CheckActiveGoal();
        if (activeQuest.ActiveGoal.GetType() == typeof(TalkToNpcGoal))
        {
            TalkToNpcGoal talk = (TalkToNpcGoal)activeQuest.ActiveGoal;

            if (talk.ChooiseQues == true)
            {
                DestroyAllChildren();
                activeQuest = talk.QuestList[id];
               // _imgPanel.sprite = _questPanel[index];
                activeQuest.CheckActiveGoal();
                if (activeQuest != null && activeQuest.ActiveQuestUi != null && activeQuest.QuestDescription != null)
                {
                    InstantiateQuestState();
                }
            }
        }
        activeQuest.CheckGoals();
        CheckQuestCompleted();
    }
    public void CheckQuestCompleted()
    {
        if (activeQuest.completed == true)
        {
            //fungusFlowChars.SetBooleanVariable("Quest" + (currentQuest + 1) + "_Completed", true);
            DestroyAllChildren();
            if (currentQuest != QuestList.Count)
            {
                currentQuest++;
                SetNewActiveQuest();
            }
        }
    }

    public void SetNewActiveQuest()
    {
        activeQuest = QuestList[currentQuest];
       // _imgPanel.sprite = _questPanel[currentQuest];
        activeQuest.CheckActiveGoal();
        if(activeQuest != null && activeQuest.ActiveQuestUi != null && activeQuest.QuestDescription != null) 
        {
            InstantiateQuestState();
        }
    }

    public void increaseIteam()
    {
        if(activeQuest.ActiveGoal.GetType() == typeof(Collect_Iteams_Goal))
        {
            collect = (Collect_Iteams_Goal) activeQuest.ActiveGoal;
            if(collect.completed != true)
            {
                collect.increaseAmount();
                if(collect.name == "Collect")
                {
                    //fungusFlowChars.SetStringVariable("NumberOFChronoCrystal", "NumberOFChronoCrystal Collected: " + collect.currentAmount);
                }
                else
                {
                    //fungusFlowChars.SetStringVariable("NumberOfFragment", "Number Of Fragmets Collected: " + collect.currentAmount);
                }
            }
            else
            {
               // Debug.Log("Completed");
                InstantiateQuestState();
            }

        }
        if(activeQuest.ActiveGoal.completed == true)
        {
            //fungusFlowChars.SetBooleanVariable("Collected", true);
        }
        activeQuest.CheckActiveGoal();
        activeQuest.CheckGoals();
        CheckQuestCompleted();

    }

    public int CurrentAmount()
    {
        return collect.currentAmount;
    }

    public void CompleteInteraction()
    {
        activeQuest.CheckActiveGoal();
        if (activeQuest.ActiveGoal.GetType() == typeof(TalkToNpcGoal))
        {
            TalkToNpcGoal talk = (TalkToNpcGoal) activeQuest.ActiveGoal;
            talk.completed = true;
        }
        activeQuest.CheckGoals();
        CheckQuestCompleted();
    }

    public void resetQuests()
    {
        foreach(Quest quest in QuestList)
        {
            quest.resetGoals();
            quest.completed = false;
        }
    }

    public void InstantiateQuestState()
    {
        DestroyAllChildren();

        GameObject questUIInstance = Instantiate(activeQuest.ActiveQuestUi, questPanal.transform);
        GameObject questDescriptionInstance = Instantiate(activeQuest.QuestDescription, questPanal.transform);
        GameObject goalInstance = Instantiate(activeQuest.ActiveGoal.goal, questPanal.transform);

        TextMeshProUGUI questUIText = questUIInstance.transform.Find("Description").GetComponent<TextMeshProUGUI>();
        TextMeshProUGUI questDescriptionText = questDescriptionInstance.transform.Find("Description").GetComponent<TextMeshProUGUI>();
        TextMeshProUGUI goalDescription = goalInstance.transform.Find("Description").GetComponent<TextMeshProUGUI>();


        // Change the text of the grandchild components
        if (questUIText != null)
        {
            questUIText.text = activeQuest.questName;
        }

        if (questDescriptionText != null)
        {
            questDescriptionText.text = activeQuest.description;
        }

        if (goalDescription != null)
        {
            goalDescription.text = activeQuest.ActiveGoal.description;
        }
    }

    public void DestroyAllChildren()
    {
        foreach (Transform childTransform in questPanal.transform)
        {
            Destroy(childTransform.gameObject);
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
