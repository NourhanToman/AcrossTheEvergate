using Google.Protobuf.WellKnownTypes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AccrossTheEvergate
{
    public class FadeManager : MonoBehaviour
    {
        [Header("Fading Parameters")]
        [SerializeField] CanvasGroup _canvasGroup;
        [SerializeField] float _fadeDuration = 5.0f;

        [Header("Locations")]
        [SerializeField] Transform newPlayerLocation;
        [SerializeField] GameObject playerObj;
        [SerializeField] GameObject oldEnviroment;
        [SerializeField] GameObject newEnviroment;
        [SerializeField] GameObject PastBuildings;
        [SerializeField] GameObject FutureBuildings;

        public static FadeManager instance;

        private void Awake()
        {
            if (instance != null && instance != this)
            {
                // If an instance already exists and it's not this one, destroy this one
                Destroy(gameObject);
            }
            else
            {
                // If no instance exists, set this one as the instance
                instance = this;
                ServiceLocator.Instance.RegisterService(this);
                DontDestroyOnLoad(gameObject);
            }
        }

        public IEnumerator FadeOut()
        {
            float elapsedTme = 0f;
            while (elapsedTme < _fadeDuration)
            {
                elapsedTme += Time.deltaTime;
                _canvasGroup.alpha = Mathf.Lerp(_canvasGroup.alpha, 1f, elapsedTme / _fadeDuration);
                yield return null;
            }
            _canvasGroup.alpha = 1f;
        }

        public IEnumerator FadeIn()
        {
            float elapsedTme = 0f;
            while (elapsedTme < _fadeDuration)
            {
                elapsedTme += Time.deltaTime;
                _canvasGroup.alpha = Mathf.Lerp(_canvasGroup.alpha, 0f, elapsedTme / _fadeDuration);
                yield return null;
            }
            _canvasGroup.alpha = 0f;
        }

        public IEnumerator Fade()
        {
            yield return StartCoroutine(FadeOut());

            newEnviroment.gameObject.SetActive(true);
            playerObj.transform.position = newPlayerLocation.position;
            FutureBuildings.gameObject.SetActive(false);
            PastBuildings.gameObject.SetActive(true);
            oldEnviroment.gameObject.SetActive(false);


            yield return StartCoroutine(FadeIn());
        }
    }
}
