using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Character
{
    [RequireComponent(typeof(Rigidbody), typeof(Animator))]
    public class MovementBehaviour : MonoBehaviour
    {
        [SerializeField] private float _speed = 5f;

        [Space]
        [SerializeField] private Direction _direction = null;


        private Rigidbody _rb;
        private Animator _animator;

        private void Awake()
        {
            _rb = GetComponent<Rigidbody>();
            _animator = GetComponent<Animator>();
        }

        private void FixedUpdate()
        {
            Move();
        }

        private void OnDisable()
        {
            _animator.SetBool("walk", false);
        }

        private void Move()
        {
            var input = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

            _rb.MovePosition(transform.position + input * Time.fixedDeltaTime * _speed);

            var inMovement = Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0;
            _animator.SetBool("walk", inMovement);

            if (inMovement)
            {
                var isRightDirection = Input.GetAxis("Horizontal") > 0;
                _direction.SetDirection(isRightDirection);
            }
        }
    }
}
