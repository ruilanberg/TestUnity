using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.UI
{
    public class HUD : MonoBehaviour
    {
        [SerializeField] private CharacterCreationInGameScreen characterCreationScreen;

        public void CustomizeBtnPressed()
        {
            characterCreationScreen.Show();
        }
    }
}
