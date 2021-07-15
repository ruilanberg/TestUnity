using Game.Character;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UI;

namespace Game.UI
{
    public class MenuScreen : Screen
    {
        [SerializeField] private Button _continueButton = null;

        [Space]
        [SerializeField] private CustomView customView = null;

        [SerializeField] private CharacterCreationScreen _characterCreationScreen = null;
        [SerializeField] private LeaderboardScreen _leaderboardScreen = null;

        [Space]
        [SerializeField] private Spawn _spawnCharacter = null;
        [SerializeField] private PlayableDirector _startGameCinemchine = null;


        private void Start()
        {
            _continueButton.interactable = PlayerPrefs.HasKey("HeadView") ||
                PlayerPrefs.HasKey("BodyView") ||
                PlayerPrefs.HasKey("BodyWeapon");
        }

        public override Coroutine Show()
        {
            _continueButton.interactable = PlayerPrefs.HasKey("HeadView") ||
                PlayerPrefs.HasKey("BodyView") ||
                PlayerPrefs.HasKey("BodyWeapon");

            return base.Show();
        }

        public void ContinueBtnPressed()
        {
            if (PlayerPrefs.HasKey("HeadView"))
                customView.SetHeadIndex(PlayerPrefs.GetInt("HeadView"));

            if (PlayerPrefs.HasKey("BodyView"))
                customView.SetBodyIndex(PlayerPrefs.GetInt("BodyView"));

            if (PlayerPrefs.HasKey("BodyWeapon"))
                customView.SetWeaponIndex(PlayerPrefs.GetInt("BodyWeapon"));

            _spawnCharacter.SetDefaultPosition();
            _startGameCinemchine.Play();
            Hide();
        }

        public void NewGameBtnPressed()
        {
            TransitionTo(_characterCreationScreen);
        }

        public void LeadboardBtnPressed()
        {
            TransitionTo(_leaderboardScreen);
        }

        public void ExitBtnPressed()
        {
            Application.Quit();
        }
    }
}
