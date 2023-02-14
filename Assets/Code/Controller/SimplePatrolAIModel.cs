using UnityEngine;


namespace WORLDGAMEDEVELOPMENT
{
    public sealed class SimplePatrolAIModel
    {
        #region Fields
        
        private readonly AIConfig _config;
        private Transform _target;
        private int _currentPointIndex;

        #endregion


        #region ClassLifeCycle
        
        public SimplePatrolAIModel(AIConfig config)
        {
            _config = config;
            //_target = GetNextWayPoint();
        }

        #endregion


        #region Methods
        
        public Vector2 CalculateVelocity(Vector2 fromPosition)
        {
            var sqrDistance = Vector2.SqrMagnitude((Vector2)_target.position - fromPosition);
            //if (sqrDistance <= _config.MinDistanceToTarget)
            //{
            //    _target = GetNextWayPoint();
            //}

            var direction = ((Vector2)_target.position - fromPosition).normalized;
            //return direction * _config.speed; //TODO - убрал скорость. переделать
            return direction * 100.0f;
        }


        //private Transform GetNextWayPoint()
        //{
        //    _currentPointIndex = (_currentPointIndex + 1) % _config.waypoints.Length;
        //    return _config.waypoints[_currentPointIndex];
        //} 

        #endregion
    }
}