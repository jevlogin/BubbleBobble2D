using System;
using UnityEngine;


namespace WORLDGAMEDEVELOPMENT
{
    public sealed class SimplePatrolAI : IFixedExecute, ICleanup
    {
        #region Fields

        private readonly EnemyView _enemyView;
        private readonly ContactsPoller _contactPoler;
        private readonly SimplePatrolAIModel _model;
        private float _minVelocityX = 0.2f;
        private float _jumpForce = 8.0f;

        private EnemyState _enemyState = EnemyState.Iddle;
        private float _timeMoveBack = 0.0f;
        private float _isMovingBackTimeLast = 3.0f;
        private float _timeIdle = 0.0f;
        private float _lasTimeIdle = 2.0f;

        private Vector3 ScaleLeft = new Vector3(-1.0f, 1.0f, 1.0f);
        private Vector3 ScaleRight = Vector3.one;
        private Vector3 ScaleEnemy = Vector3.zero;

        #endregion


        #region ClassLifeCycle

        public SimplePatrolAI(SimplePatrolAIModel simplePatrolAIModel, ContactsPoller contactPolerSimplePatrolAI)
        {
            _model = simplePatrolAIModel;
            _enemyView = _model.EnemyModel.EnemyComponents.EnemyView;
            _contactPoler = contactPolerSimplePatrolAI;
            _model.EnemeStateEvent += _model_EnemeStateEvent;
        }

        private void _model_EnemeStateEvent(EnemyState state)
        {
            _enemyState = state;
        }

        #endregion


        #region IFixedExecute

        public void FixedExecute(float fixedDeltaTime)
        {
            var newVelocity = _model.CalculateVelocity(_enemyView.transform.position, fixedDeltaTime);
            ;
            if (newVelocity.x < 0 && _enemyState != EnemyState.MoveBackward)
                ScaleEnemy = ScaleLeft;
            else if (newVelocity.x > 0 && _enemyState != EnemyState.MoveBackward)
                ScaleEnemy = ScaleRight;

            switch (_enemyState)
            {
                case EnemyState.Iddle:
                    if (_timeIdle <= _lasTimeIdle)
                        _timeIdle += fixedDeltaTime;
                    else
                    {
                        ResetState(ref _timeIdle, EnemyState.MoveForward);
                    }
                    break;
                case EnemyState.MoveForward:
                    _enemyView.transform.localScale = ScaleEnemy;
                    _enemyView.Rigidbody2D.velocity = _enemyView.Rigidbody2D.velocity.Change(x: newVelocity.x);

                    if (MathF.Abs(_enemyView.Rigidbody2D.velocity.magnitude) <= _minVelocityX)
                    {
                        if (newVelocity.y > 1 && _contactPoler.IsGrounded)
                            _enemyState = EnemyState.Jump;
                        else if (newVelocity.y < 1)
                            _enemyState = EnemyState.MoveBackward;
                    }
                    break;
                case EnemyState.MoveBackward:
                    _timeMoveBack += fixedDeltaTime;
                    _enemyView.transform.localScale = ScaleEnemy;

                    if (_timeMoveBack <= _isMovingBackTimeLast && _contactPoler.IsGrounded)
                    {
                        var velocityX = 5.0f * ScaleEnemy.x;
                        _enemyView.Rigidbody2D.velocity = _enemyView.Rigidbody2D.velocity.Change(x: velocityX);
                        if (_contactPoler.HasLeftContact || _contactPoler.HasRightContact)
                            ResetState(ref _timeMoveBack, EnemyState.Iddle);
                    }
                    else
                        ResetState(ref _timeMoveBack, EnemyState.Iddle);
                    break;
                case EnemyState.Jump:
                    _enemyView.Rigidbody2D.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
                    _enemyState = EnemyState.Iddle;
                    break;
                default:
                    break;
            }
        }

        private void ResetState(ref float timeMoveBack, EnemyState currentState)
        {
            timeMoveBack = 0.0f;
            _enemyState = currentState;
        }

        public void Cleanup()
        {
            _model.EnemeStateEvent -= _model_EnemeStateEvent;
        }

        #endregion
    }
}