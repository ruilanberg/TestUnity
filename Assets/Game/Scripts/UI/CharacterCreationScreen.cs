using Game.Character;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

namespace Game.UI
{
    public class CharacterCreationScreen : Screen
    {
        [SerializeField] private GameObject _headSubMenu = null;
        [SerializeField] private GameObject _armorSubMenu = null;
        [SerializeField] private GameObject _weaponSubMenu = null;
        [SerializeField] private CustomView[] customViews = null;
        [Space]
        [SerializeField] private MenuScreen _menuScreen = null;

        [Space]
        [SerializeField] private Spawn _spawnCharacter = null;
        [SerializeField] private PlayableDirector _startGameCinemchine = null;

        public override Coroutine Show()
        {
            for (int i = 0; i < customViews.Length; i++)
                customViews[i].ResetForDefault();

            return base.Show();
        }
        public void BackBtnPressed()
        {
            TransitionTo(_menuScreen);

            _weaponSubMenu.SetActive(false);
            _armorSubMenu.SetActive(false);
            _headSubMenu.SetActive(false);
        }

        public void HeadBtnPressed()
        {
            _weaponSubMenu.SetActive(false);
            _armorSubMenu.SetActive(false);

            _headSubMenu.SetActive(true);
        }

        public void ArmorBtnPressed()
        {
            _weaponSubMenu.SetActive(false);
            _headSubMenu.SetActive(false);

            _armorSubMenu.SetActive(true);
        }

        public void WeaponBtnPressed()
        {
            _headSubMenu.SetActive(false);
            _armorSubMenu.SetActive(false);

            _weaponSubMenu.SetActive(true);
        }

        public void NextBtnPressed()
        {
            _spawnCharacter.SetDefaultPosition();
            _startGameCinemchine.Play();
            Hide();
        }
    }
}
