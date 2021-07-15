using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

namespace Game.UI
{
    public class GameOverScreen : Screen
    {
        [SerializeField] private TextMeshProUGUI _scoreTxt = null;
        [SerializeField] private Score _score = null;

        [Space]
        [SerializeField] private MenuScreen _menuScreen = null;

        public void ShowScreen()
        {
            _scoreTxt.text = _score.CurrentScore.ToString();

            SaveScore(_score.CurrentScore);
            _score.ResetScore();

            base.Show();
        }

        private void SaveScore(int score)
        {
            if (PlayerPrefs.HasKey("Leadboard"))
            {
                var board = JsonUtility.FromJson<LeadboardData>(PlayerPrefs.GetString("Leadboard"));

                for (int i = 0; i < board.Scores.Length; i++)
                {
                    if(score > board.Scores[i])
                    {
                        board.Scores[board.Scores.Length -1] = score;
                        Array.Sort(board.Scores);
                        Array.Reverse(board.Scores);
                        PlayerPrefs.SetString("Leadboard", JsonUtility.ToJson(board));

                        break;
                    }
                }
            }
            else
            {
                var board = new LeadboardData();
                board.Scores[0] = score;
                PlayerPrefs.SetString("Leadboard", JsonUtility.ToJson(board));
            }
        }

        public void LeaveBtnPressed()
        {
            TransitionTo(_menuScreen);
        }
    }
}
