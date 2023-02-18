using System;


namespace WORLDGAMEDEVELOPMENT
{
    public sealed class SimplePatrolAI : IFixedExecute
    {
        #region Fields

        private readonly EnemyView _enemyView;
        private readonly SimplePatrolAIModel _model;

        #endregion


        #region ClassLifeCycle

        public SimplePatrolAI(SimplePatrolAIModel simplePatrolAIModel)
        {
            _model = simplePatrolAIModel;
            _enemyView = _model.EnemyModel.EnemyComponents.EnemyView;
        }

        #endregion


        #region IFixedExecute

        public void FixedExecute(float fixedDeltaTime)
        {
            var newVelocity = _model.CalculateVelocity(_enemyView.transform.position) * fixedDeltaTime;
            _enemyView.Rigidbody2D.velocity = newVelocity;
        }

        #endregion
    }
}