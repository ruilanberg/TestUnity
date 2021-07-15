using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Character
{
    public class Spawn : MonoBehaviour
    {
        [SerializeField] private Direction _direction = null;
        [SerializeField] private Vector3 _initPosition = Vector3.zero;

        public void SetDefaultPosition()
        {
            transform.position = _initPosition;
            _direction.SetDirection(false);
        }
    }
}