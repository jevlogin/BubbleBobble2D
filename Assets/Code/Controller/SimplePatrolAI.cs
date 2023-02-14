using System;


namespace WORLDGAMEDEVELOPMENT
{
    public sealed class SimplePatrolAI : IFixedExecute
    {
        private readonly EnemyView _enemyView;
        private readonly SimplePatrolAIModel _model;

        public SimplePatrolAI(EnemyView alienView, SimplePatrolAIModel model)
        {
            _enemyView = alienView ?? throw new ArgumentNullException(nameof(alienView));
            _model = model ?? throw new ArgumentNullException(nameof(model));
        }

        public void FixedExecute(float fixedDeltaTime)
        {
            var newVelocity = _model.CalculateVelocity(_enemyView.transform.position) * fixedDeltaTime;
            _enemyView.Rigidbody2D.velocity = newVelocity;
        }
    }
}