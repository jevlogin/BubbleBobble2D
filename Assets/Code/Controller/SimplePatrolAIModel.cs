using System;
using UnityEngine;


namespace WORLDGAMEDEVELOPMENT
{
    public sealed class SimplePatrolAIModel
    {
        #region Fields

        private Transform _target;
        private int _currentPointIndex;
        private Vector2 _direction = Vector2.zero;
        private Vector2 _velocity = Vector2.zero;
        private readonly EnemyModel _enemyModel;

        public EnemyModel EnemyModel => _enemyModel;
        public event Action<EnemyState> EnemeStateEvent;

        #endregion


        #region ClassLifeCycle

        public SimplePatrolAIModel(EnemyModel enemyModel)
        {
            _enemyModel = enemyModel ?? throw new System.ArgumentNullException(nameof(enemyModel));
            _target = GetNextWayPoint();
        }


        #endregion


        #region Methods

        public Vector2 CalculateVelocity(Vector2 fromPosition, float fixedDeltaTime)
        {
            var sqrDistance = Vector2.SqrMagnitude((Vector2)_target.position - fromPosition);
            if (sqrDistance <= _enemyModel.EnemyStruct.AIStruct.MinSqrDistanceToTarget)
            {
                _target = GetNextWayPoint();
                EnemeStateEvent?.Invoke(EnemyState.Iddle);
            }
            _direction = ((Vector2)_target.position - fromPosition).normalized;
            _velocity = _direction * _enemyModel.EnemyStruct.Speed * fixedDeltaTime;
            return _velocity;
        }


        private Transform GetNextWayPoint()
        {
            _currentPointIndex = (_currentPointIndex + 1) % _enemyModel.EnemyStruct.AIStruct.Waypoints.Length;
            return _enemyModel.EnemyStruct.AIStruct.Waypoints[_currentPointIndex];
        }

        #endregion
    }
}