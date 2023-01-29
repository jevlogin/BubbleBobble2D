using System;
using UnityEngine;

namespace WORLDGAMEDEVELOPMENT
{
    public sealed class PlayerController
    {
        #region Fields

        private readonly LevelObjectView _playerView;
        private readonly SpriteAnimator _playerAnimator;

        private readonly Vector3 _leftScale = new(-1.0f, 1.0f, 1.0f);
        private readonly Vector3 _rightScale = new(1.0f, 1.0f, 1.0f);

        private const float _walkSpeed = 3.0f;
        private const float _animationSpeed = 10.0f;
        private const float _jumpStartSpeed = 8.0f;
        private const float _movingTresh = 0.15f;
        private const float _flyingTresh = 1.0f;
        private const float _groundLevel = 0.5f;
        private const float _g = -9.8f;

        private float _yVelocity = 0.0f;
        private bool _doJump;
        private float _xAxisInput;


        #endregion


        #region ClassLifeCycle

        public PlayerController(LevelObjectView playerView, SpriteAnimator playerAnimator)
        {
            _playerView = playerView;
            _playerAnimator = playerAnimator;
        }

        #endregion


        private void GoSideAway()
        {
            _playerView.transform.position += Vector3.right * (Time.deltaTime * _walkSpeed * (_xAxisInput < 0 ? -1 : 1));
            _playerView.transform.localScale = (_xAxisInput > 0 ? _leftScale : _rightScale);
        }

        private bool IsGrounded()
        {
            return _playerView.transform.position.y <= _groundLevel + float.Epsilon && _yVelocity <= 0.0f;
        }

        public void Update()
        {
            _doJump = Input.GetAxis(ManagerTag.VERTICAL) > 0;
            _xAxisInput = Input.GetAxis(ManagerTag.HORIZONTAL);
            var goSideAway = Mathf.Abs(_xAxisInput) > _movingTresh;

            if (IsGrounded())
            {
                if (goSideAway)
                {
                    GoSideAway();
                }
                _playerAnimator.StartAnimation(_playerView.SpriteRenderer,
                        goSideAway ? AnimState.Run : AnimState.Iddle, true, _animationSpeed);

                if (_doJump && _yVelocity == 0)
                {
                    _yVelocity = _jumpStartSpeed;
                }
                else if (_yVelocity < 0)
                {
                    _yVelocity = 0;
                    _playerView.transform.position = _playerView.transform.position.Change(y: _groundLevel);
                }
            }
            else
            {
                if (goSideAway)
                {
                    GoSideAway();
                }
                if (Mathf.Abs(_yVelocity) > _flyingTresh)
                {
                    _playerAnimator.StartAnimation(_playerView.SpriteRenderer, 
                        AnimState.Jump, true, _animationSpeed);
                }
                _yVelocity += _g * Time.deltaTime;
                _playerView.transform.position += Vector3.up * (Time.deltaTime * _yVelocity);
            }
        }
    }
}