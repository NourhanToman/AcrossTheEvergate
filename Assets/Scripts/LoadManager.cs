using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace AccrossTheEvergate
{
    public class LoadManager : MonoBehaviour
    {
        private void Awake() => ServiceLocator.Instance.RegisterService(this);

        public void LoadWorldScene()
        {
            SceneManager.LoadSceneAsync(1);
        }

        public void LoadDungeonScene()
        {
            SceneManager.LoadSceneAsync(2);
        }
    }
}