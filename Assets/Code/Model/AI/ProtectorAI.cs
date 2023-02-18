using Pathfinding;
using System;
using UnityEngine;


namespace WORLDGAMEDEVELOPMENT
{
    public sealed class ProtectorAI : IProtector, IInitialization, ICleanup
    {
        #region Fields

        private readonly EnemyView _view;
        private readonly PatrolAIModel _model;
        private readonly AIDestinationSetter _destinationSetter;
        private readonly AIPatrolPath _patrolPath;
        private bool _isPatrolling;
        private EnemyModel _enemyModel;

        #endregion

        public ProtectorAI(EnemyModel enemyModel, PatrolAIModel patrolAIModel)
        {
            _enemyModel = enemyModel ?? throw new ArgumentNullException(nameof(enemyModel));
            _model = patrolAIModel ?? throw new ArgumentNullException(nameof(patrolAIModel));

            _view = _enemyModel.EnemyComponents.EnemyView;
            _destinationSetter = _enemyModel.EnemyComponents.AIConfig.AIDestinationSetter;
            _patrolPath = _enemyModel.EnemyComponents.AIConfig.AIPatrolPath;
        }

        private void OnTargetReached(object sender, EventArgs e)
        {

            //В настоящий момент, этого не происходит. Потому что, нет движения у Enemy
            //А вот почему нет движения, не понимаю
            Debug.Log($"Проерка OnTargetReached {sender}");
            Debug.Log($"Проерка Initialize {this}");

            _destinationSetter.target = _isPatrolling 
                                    ? _model.GetNextTarget() 
                                    : _model.GetClosestTarget(_view.transform.position);
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

        public void Initialize()
        {
            _destinationSetter.target = _model.GetNextTarget();
            _isPatrolling = true;
            _patrolPath.TargetReached += OnTargetReached;
        }

        public void Cleanup()
        {
            _patrolPath.TargetReached -= OnTargetReached;
        }
    }
}