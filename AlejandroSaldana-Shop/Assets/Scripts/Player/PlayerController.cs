using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Player
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private float speedMovement;
        
        [Header("Input actions ref")]
        [SerializeField] private InputActionReference move;
        
        private Rigidbody2D _playerRb;
        private Animator _playerAnimator;

        private Vector2 _input;
        
        
        //Animations
        private static readonly int Running = Animator.StringToHash("Running");
        private bool _facingRight = true;

        private void Awake()
        {
            _playerRb = GetComponent<Rigidbody2D>();
            _playerAnimator = GetComponent<Animator>();
        }

        private void Update()
        {
            _input = move.action.ReadValue<Vector2>();
            _playerAnimator.SetBool(Running, _input != Vector2.zero);

            if (_input.x != 0) CheckPlayerFaceDirection();
        }

        private void FixedUpdate()
        {
            _playerRb.velocity = new Vector2(_input.x, _input.y) * speedMovement;
        }

        private void CheckPlayerFaceDirection()
        {
            switch (_facingRight)
            {
                case true when _input.x > 0:
                    return;
                
                case true when _input.x < 0:
                    _facingRight = false;
                    transform.localScale = new Vector3(-1, 1, 1);
                    break;
                
                case false when _input.x < 0:
                    return;
                
                case false when _input.x > 0:
                    _facingRight = true;
                    transform.localScale = Vector3.one;
                    break;
            }
        }
    }
}
