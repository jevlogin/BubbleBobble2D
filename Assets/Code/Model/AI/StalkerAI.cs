using Pathfinding;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace WORLDGAMEDEVELOPMENT
{
    public sealed class StalkerAI : IFixedExecute
    {
        private readonly EnemyView _enemyView;
        private readonly StalkerAIModel _stalkerAIModel;
        private readonly Seeker _seeker;
        private readonly Transform _target;

        public StalkerAI(EnemyView enemyView, StalkerAIModel stalkerAIModel, Seeker seeker, Transform target)
        {
            _enemyView = enemyView ?? throw new ArgumentNullException(nameof(enemyView));
            _stalkerAIModel = stalkerAIModel ?? throw new ArgumentNullException(nameof(stalkerAIModel));
            _seeker = seeker ?? throw new ArgumentNullException(nameof(seeker));
            _target = target ?? throw new ArgumentNullException(nameof(target));
        }

        public void FixedExecute(float fixedDeltaTime)
        {
            var newVelocity = _stalkerAIModel.CalculateVelocity(_enemyView.transform.position) * fixedDeltaTime;

            _enemyView.Rigidbody2D.velocity = newVelocity;
        }

        public void RecalculatePath()
        {
            if (_seeker.IsDone())
            {
                _seeker.StartPath(_enemyView.Rigidbody2D.position, _target.position, OnPathCompleted);
            }
        }

        private void OnPathCompleted(Path path)
        {
            if (path.error)
                return;
            _stalkerAIModel.UpdatePath(path);
        }
    }
}