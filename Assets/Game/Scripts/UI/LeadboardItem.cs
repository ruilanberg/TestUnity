using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Game.UI
{
    public class LeadboardItem : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI scoreTxt = null;

        public void SetData(string score)
        {
            scoreTxt.text = score;
        }
    }
}
