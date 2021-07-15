using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.CPU
{
    public class Ammunition : MonoBehaviour
    {

        private void OnCollisionEnter(Collision collision)
        {
            Debug.Log("Hit Player");
            GameManager.Instance.EndGame();
        }
    }
}
