using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.UI
{
    [RequireComponent(typeof(CanvasGroup))]
    public class Screen : MonoBehaviour
    {
        [SerializeField] private float _speedTransition = 0.015f;

        private CanvasGroup _canvasGroup;

        public bool IsShow { get; private set; }

        private void Awake()
        {
            _canvasGroup = GetComponent<CanvasGroup>();
        }

        public virtual Coroutine Show()
        {
            return StartCoroutine(ShowAsync());
        }

        protected virtual Coroutine Hide()
        {
            return StartCoroutine(HideAsync());
        }

        private Screen _lastScreen = null;
        protected void GoBack()
        {
            TransitionTo(_lastScreen);
        }

        public void TransitionTo(Screen showScreen)
        {
            showScreen.SetLastScreen(this);
            StartCoroutine(TransitionToAsync(this, showScreen));
        }

        private void SetLastScreen(Screen lastScreen)
        {
            _lastScreen = lastScreen;
        }

        private IEnumerator ShowAsync()
        {
            var _transitionWait = new WaitForSeconds(_speedTransition);

            while (_canvasGroup.alpha != 1)
            {
                _canvasGroup.alpha += 0.1f;
                yield return _transitionWait;
            }

            _canvasGroup.interactable = true;
            _canvasGroup.blocksRaycasts = true;

            IsShow = true;
        }

        private IEnumerator HideAsync()
        {
            var _transitionWait = new WaitForSeconds(_speedTransition);

            while (_canvasGroup.alpha != 0)
            {
                _canvasGroup.alpha -= 0.1f;
                yield return _transitionWait;
            }

            _canvasGroup.interactable = false;
            _canvasGroup.blocksRaycasts = false;

            IsShow = false;
        }

        private IEnumerator TransitionToAsync(Screen hideScreen, Screen showScreen)
        {
            var _transitionWait = new WaitForSeconds(_speedTransition);

            yield return showScreen.Show();

            hideScreen.Hide();
        }
    }
}
