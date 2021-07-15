using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.UI
{
    public class LeaderboardScreen : Screen
    {
        [SerializeField] private LeadboardItem[] items = null;
        public override Coroutine Show()
        {
            if (PlayerPrefs.HasKey("Leadboard"))
            {
                var board = JsonUtility.FromJson<LeadboardData>(PlayerPrefs.GetString("Leadboard"));
                
                for (int i = 0; i < board.Scores.Length; i++)
                    items[i].SetData(board.Scores[i].ToString());
            }

            return base.Show();
        }

        public void BackBtnPressed()
        {
            GoBack();
        }
    }
}
