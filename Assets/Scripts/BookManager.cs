using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace AccrossTheEvergate
{

    
    public class BookManager : MonoBehaviour
    {
        [SerializeField] GameObject Firstpage;
        public void select1stBttn()
        {
            EventSystem.current.SetSelectedGameObject(null);
            EventSystem.current.SetSelectedGameObject(Firstpage);
        }

    }
}
