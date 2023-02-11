using Object = UnityEngine.Object;


namespace WORLDGAMEDEVELOPMENT
{
    public sealed class EnemyFactory
    {
        private readonly EnemyData _enemyData;

        public EnemyFactory(EnemyData enemyData)
        {
            _enemyData = enemyData;
        }

        public EnemyModel CreateEnemyModel()
        {
            var enemyStruct = _enemyData.EnemyStruct;
            
            var enemySpawn = Object.Instantiate(enemyStruct.Prefab);
            enemySpawn.gameObject.SetActive(false);

            var enemyCompomemts = new EnemyComponents();
            enemyCompomemts.CircleCollider2D = enemySpawn.CircleCollider2D;
            enemyCompomemts.SpriteRenderer = enemySpawn.SpriteRenderer;
            enemyCompomemts.Rigidbody2D = enemySpawn.Rigidbody2D;
            enemyCompomemts.EnemyView = enemySpawn;

            var enemySettings = new EnemySettings();
            enemySettings.SpriteAnimatorConfig = _enemyData.EnemySettings.SpriteAnimatorConfig;

            var model = new EnemyModel(enemyStruct, enemyCompomemts, enemySettings);

            return model;
        }
    }
}