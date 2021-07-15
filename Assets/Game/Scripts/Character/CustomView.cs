using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Character
{
    public class CustomView : MonoBehaviour
    {
        [Header("Body")]
        [SerializeField] private SpriteRenderer headRenderer = null;

        [Space]
        [SerializeField] private SpriteRenderer bodyRenderer = null;
        
        [SerializeField] private SpriteRenderer leftArmUpperRenderer = null;
        [SerializeField] private SpriteRenderer leftArmBottomRenderer = null;

        [SerializeField] private SpriteRenderer rightArmUpperRenderer = null;
        [SerializeField] private SpriteRenderer rightArmBottomRenderer = null;

        [SerializeField] private SpriteRenderer leftLegRenderer = null;
        [SerializeField] private SpriteRenderer rightLegRenderer = null;

        [Space]
        [SerializeField] private SpriteRenderer weaponRenderer = null;

        [Header("Parts")]
        [SerializeField] private Sprite[] headParts = null;

        [Space]
        [SerializeField] private Sprite[] bodyParts = null;

        [SerializeField] private Sprite[] leftArmUpperParts = null;
        [SerializeField] private Sprite[] leftArmBottomParts = null;

        [SerializeField] private Sprite[] rightArmUpperParts = null;
        [SerializeField] private Sprite[] rightArmBottomParts = null;

        [SerializeField] private Sprite[] leftLegParts = null;
        [SerializeField] private Sprite[] rightLegParts = null;


        [Space]
        [SerializeField] private Sprite[] weaponParts = null;

        public void SetHeadIndex(int indexHead)
        {
            PlayerPrefs.SetInt("HeadView", indexHead);
            headRenderer.sprite = headParts[indexHead];
        }

        public void SetBodyIndex(int indexBody)
        {
            PlayerPrefs.SetInt("BodyView", indexBody);

            bodyRenderer.sprite = bodyParts[indexBody];

            leftArmUpperRenderer.sprite = leftArmUpperParts[indexBody];
            leftArmBottomRenderer.sprite = leftArmBottomParts[indexBody];

            rightArmUpperRenderer.sprite = rightArmUpperParts[indexBody];
            rightArmBottomRenderer.sprite = rightArmBottomParts[indexBody];

            leftLegRenderer.sprite = leftLegParts[indexBody];
            rightLegRenderer.sprite = rightLegParts[indexBody];
        }

        public void SetWeaponIndex(int indexWeapon)
        {
            PlayerPrefs.SetInt("BodyWeapon", indexWeapon);

            weaponRenderer.sprite = weaponParts[indexWeapon];
        }

        public void ResetForDefault()
        {
            SetHeadIndex(0);
            SetBodyIndex(0);
            SetWeaponIndex(0);
        }
    }
}
