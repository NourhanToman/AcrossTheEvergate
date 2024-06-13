using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AccrossTheEvergate
{
    public class tempFade : MonoBehaviour
    {
        [Header("Fading Parameters")]
        [SerializeField] CanvasGroup _canvasGroup;
        [SerializeField] float _fadeDuration = 5.0f;

        public static tempFade instance;

        private void Awake()
        {
            if (instance != null && instance != this)
            {
                Destroy(gameObject);
            }
            else
            {
                instance = this;
                ServiceLocator.Instance.RegisterService(this);
                DontDestroyOnLoad(gameObject);
            }
        }

        public IEnumerator FadeOut()
        {
            //From 0 to 1 aka Fade to black
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
            //From 1 to 0 aka Fade to screen
            float elapsedTme = 0f;
            while (elapsedTme < _fadeDuration)
            {
                elapsedTme += Time.deltaTime;
                _canvasGroup.alpha = Mathf.Lerp(_canvasGroup.alpha, 0f, elapsedTme / _fadeDuration);
                yield return null;
            }
            _canvasGroup.alpha = 0f;
        }
    }
}
