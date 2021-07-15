using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.CPU
{
    public class Gun : MonoBehaviour
    {
        [SerializeField] private Ammunition _ammunitionPrefab;

        public void Fire()
        {
            Debug.Log($"{name} Fired");

            var ammunition = Instantiate(_ammunitionPrefab, transform.position, Quaternion.identity);
            ammunition.transform.SetParent(transform);
        }
    }
}
