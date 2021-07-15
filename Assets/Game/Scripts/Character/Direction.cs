using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Character
{
    public class Direction : MonoBehaviour
    {
        private bool _currentIsRight = false;

        public void SetDirection(bool isRight)
        {
            if (_currentIsRight == isRight)
                return;

            var x = isRight ? -1f : 1f;
            transform.localScale = new Vector3(x, transform.localScale.y, transform.localScale.z);


            _currentIsRight = isRight;
        }
    }
}
