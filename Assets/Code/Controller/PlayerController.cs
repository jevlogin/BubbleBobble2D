using System;
using UnityEngine;

namespace WORLDGAMEDEVELOPMENT
{
    public sealed class PlayerController : IFixedExecute
    {
        #region Fields

        private readonly LevelObjectView _playerView;
        private readonly SpriteAnimatorController _playerAnimator;

        private readonly Vector3 _leftScale = new(-1.0f, 1.0f, 1.0f);
        private readonly Vector3 _rightScale = new(1.0f, 1.0f, 1.0f);

        private const float _walkSpeed = 150.0f;
        private const float _animationSpeed = 10.0f;
        private const float _jumpForce = 8.0f;
        private const float _jumpTresh = 0.1f;
        private const float _movingTresh = 0.1f;
        private const float _flyTresh = 1.0f;
        private const float _groundLevel = 0.5f;
        private const float _g = -9.8f;

        private float _yVelocity = 0.0f;
        private bool _doJump;
        private float _xAxisInput;

        private readonly ContactPoller _contactPoller;

        #endregion


        #region ClassLifeCycle

        public PlayerController(LevelObjectView playerView, SpriteAnimatorController playerAnimator,
            ContactPoller contactPoller)
        {
            _playerView = playerView;
            _playerAnimator = playerAnimator;
            _contactPoller = contactPoller;
        }

        #endregion

        public void FixedExecute(float fixedDeltatime)
        {
            _doJump = Input.GetButton(ManagerTag.JUMP);
            _xAxisInput = Input.GetAxis(ManagerTag.HORIZONTAL);
            var walks = Mathf.Abs(_xAxisInput) > _movingTresh;

            var newVelocity = 0.0f;

            if (walks && (_xAxisInput > 0 || !_contactPoller.HasLeftContact) &&
                                            (_xAxisInput < 0 || !_contactPoller.HasRightContact))
            {
                newVelocity = fixedDeltatime * _walkSpeed * (_xAxisInput < 0 ? -1 : 1);
                _playerView.transform.localScale = (newVelocity > 0 ? _leftScale : _rightScale);
            }

            _playerView.RidgidBody2D.velocity = _playerView.RidgidBody2D.velocity.Change(x: newVelocity);


            if (_contactPoller.IsGrounded && _doJump && Mathf.Abs(_playerView.RidgidBody2D.velocity.y) <= _jumpTresh)
            {
                _playerView.RidgidBody2D.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
            }

            if (_contactPoller.IsGrounded)
            {
                _playerAnimator.StartAnimation(_playerView.SpriteRenderer,
                        walks ? AnimState.Run : AnimState.Iddle, true, _animationSpeed);
            }
            else if (MathF.Abs(_playerView.RidgidBody2D.velocity.y) > _flyTresh)
            {
                _playerAnimator.StartAnimation(_playerView.SpriteRenderer,
                       AnimState.Jump, true, _animationSpeed);
            }
        }
    }
}