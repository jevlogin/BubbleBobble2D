using UnityEngine;


namespace WORLDGAMEDEVELOPMENT
{
    public sealed class SimplePatrolAIModel
    {
        #region Fields

        private Transform _target;
        private int _currentPointIndex;

        private readonly EnemyModel _enemyModel;

        public EnemyModel EnemyModel => _enemyModel;

        #endregion


        #region ClassLifeCycle

        public SimplePatrolAIModel(EnemyModel enemyModel)
        {
            _enemyModel = enemyModel ?? throw new System.ArgumentNullException(nameof(enemyModel));
            _target = GetNextWayPoint();
        }

        #endregion


        #region Methods

        public Vector2 CalculateVelocity(Vector2 fromPosition)
        {
            var sqrDistance = Vector2.SqrMagnitude((Vector2)_target.position - fromPosition);
            if (sqrDistance <= _enemyModel.EnemyStruct.AIStruct.MinSqrDistanceToTarget)
                _target = GetNextWayPoint();

            var direction = ((Vector2)_target.position - fromPosition).normalized;
            var velocity = direction * _enemyModel.EnemyStruct.Speed;
            return velocity;
        }


        private Transform GetNextWayPoint()
        {
            _currentPointIndex = (_currentPointIndex + 1) % _enemyModel.EnemyStruct.AIStruct.Waypoints.Length;
            return _enemyModel.EnemyStruct.AIStruct.Waypoints[_currentPointIndex];
        }

        #endregion
    }
}