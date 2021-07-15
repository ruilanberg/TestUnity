using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Game.UI
{
    public class Score : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI scoreTxt = null;

        public int CurrentScore { get; private set; }
        private Coroutine _scoringCoroutine;
        public void InitScoring()
        {
            ResetScore();

            _scoringCoroutine = StartCoroutine(ScoringAsyc());
        }

        public void StopScoring()
        {
            StopCoroutine(_scoringCoroutine);
        }

        public void ResetScore()
        {
            CurrentScore = 0;
            scoreTxt.text = CurrentScore.ToString();
        }

        private WaitForSeconds waitForAddPoint = new WaitForSeconds(1f);
        private IEnumerator ScoringAsyc()
        {
            while (true)
            {
                yield return waitForAddPoint;
                ++CurrentScore;
                scoreTxt.text = CurrentScore.ToString();
            }
        }
    }
}
