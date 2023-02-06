using System;
using UnityEngine;

namespace WORLDGAMEDEVELOPMENT
{
    public sealed class PlayerController : IFixedExecute
    {
        #region Fields

        private readonly PlayerView _playerView;
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

        private bool _doJump;
        private float _xAxisInput;

        private readonly ContactsPoller _contactPoller;

        #endregion


        #region ClassLifeCycle

        public PlayerController(PlayerView playerView, SpriteAnimatorController playerAnimator,
            ContactsPoller contactPoller)
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

            _playerView.Rigidbody2DPlayer.velocity = _playerView.Rigidbody2DPlayer.velocity.Change(x: newVelocity);


            if (_contactPoller.IsGrounded && _doJump && Mathf.Abs(_playerView.Rigidbody2DPlayer.velocity.y) <= _jumpTresh)
            {
                _playerView.Rigidbody2DPlayer.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
            }

            if (_contactPoller.IsGrounded)
            {
                _playerAnimator.StartAnimation(_playerView.SpriteRendererPlayer,
                        walks ? AnimState.Run : AnimState.Iddle, true, _animationSpeed);
            }
            else if (MathF.Abs(_playerView.Rigidbody2DPlayer.velocity.y) > _flyTresh)
            {
                _playerAnimator.StartAnimation(_playerView.SpriteRendererPlayer,
                       AnimState.Jump, true, _animationSpeed);
            }
        }
    }
}