using UnityEngine;


namespace WORLDGAMEDEVELOPMENT
{
    public sealed class PatrolAIModel
    {
        private readonly Transform[] _waypoints;
        private int _currentPointIndex;

        public PatrolAIModel(Transform[] waypoints)
        {
            _waypoints = waypoints;
            _currentPointIndex = 0;
        }

        public Transform GetNextTarget()
        {
            if (_waypoints == null)
            {
                return null;
            }
            _currentPointIndex = (_currentPointIndex + 1) % _waypoints.Length;
            return _waypoints[_currentPointIndex];
        }

        public Transform GetClosestTarget(Vector2 fromPosition)
        {
            if (_waypoints == null) return null;
            var closestIndex = 0;
            var closestDistance = 0.0f;
            for (int i = 0; i < _waypoints.Length; i++)
            {
                var distance = Vector2.Distance(fromPosition, _waypoints[i].position);
                if (distance < closestDistance)
                {
                    closestDistance = distance;
                    closestIndex = i;
                }
            }
            _currentPointIndex = closestIndex;

            return _waypoints[_currentPointIndex];
        }
    }
}