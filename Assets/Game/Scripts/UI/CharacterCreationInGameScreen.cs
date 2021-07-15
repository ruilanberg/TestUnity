using Game.Character;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.UI
{
    public class CharacterCreationInGameScreen : Screen
    {
        [SerializeField] private GameObject _headSubMenu = null;
        [SerializeField] private GameObject _armorSubMenu = null;
        [SerializeField] private GameObject _weaponSubMenu = null;

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

        public void SaveBtnPressed()
        {
            Hide();
        }
    }
}
