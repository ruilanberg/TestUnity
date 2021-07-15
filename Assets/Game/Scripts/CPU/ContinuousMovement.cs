using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.CPU
{
    public class ContinuousMovement : MonoBehaviour
    {
        [SerializeField] private float _speed = 5f;
        [SerializeField] private Vector3 _direction = Vector3.back;

        private Vector3 _nextPosition;

        private void Update()
        {
            transform.Translate(_direction * _speed);
        }
    }
}
