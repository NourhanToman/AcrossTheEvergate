using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AccrossTheEvergate
{
    public class ChooiseQuest : Goal
    {
        public bool ChooiseQues;
        public List<Quest> QuestList;

        private void OnEnable()
        {
            ResetValue();
        }

        public void ResetValue()
        {
            completed = false;
        }
    }
}
