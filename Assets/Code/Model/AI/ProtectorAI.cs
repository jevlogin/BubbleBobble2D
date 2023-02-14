using Pathfinding;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace WORLDGAMEDEVELOPMENT
{
    public sealed class ProtectorAI : IProtector
    {
        private readonly EnemyView _view;
        private readonly PatrolAIModel _model;
        private readonly AIDestinationSetter _destinationSetter;
        private readonly AIPatrolPath _patrolPath;
        private bool _isPatrolling;

        public ProtectorAI(EnemyView enemyView, PatrolAIModel model, AIDestinationSetter setter, AIPatrolPath path)
        {
            _view = enemyView ?? throw new System.ArgumentNullException(nameof(enemyView));
            _model = model ?? throw new System.ArgumentNullException(nameof(model));
            _destinationSetter = setter ?? throw new System.ArgumentNullException(nameof(_destinationSetter));
            _patrolPath = path ?? throw new System.ArgumentNullException(nameof(path));
        }

        public void Init()
        {
            _destinationSetter.target = _model.GetNextTarget();
            _isPatrolling = true;
            _patrolPath.TargetReached += OnTargetReached;
        }

        public void DeInit()
        {
            _patrolPath.TargetReached -= OnTargetReached;
        }

        private void OnTargetReached(object sender, EventArgs e)
        {
            _destinationSetter.target = _isPatrolling ? _model.GetNextTarget() :
                                        _model.GetClosestTarget(_view.transform.position);  // вероятно тут игрок
        }



        public void FinishProtection(GameObject gameObject)
        {
            _isPatrolling = true;
            _destinationSetter.target = _model.GetClosestTarget(_view.transform.position);
        }

        public void StartProtection(GameObject gameObject)
        {
            _isPatrolling = false;
            _destinationSetter.target = gameObject.transform;
        }
    }
}