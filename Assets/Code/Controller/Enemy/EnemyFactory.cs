using UnityEngine;
using Object = UnityEngine.Object;


namespace WORLDGAMEDEVELOPMENT
{
    public sealed class EnemyFactory
    {
        private readonly Transform _rootEnemy;
       
        public EnemyFactory()
        {
            _rootEnemy = new GameObject("RootEnemy").transform;
        }

        public EnemyModel CreateEnemyModel(EnemyData enemyData, Transform point)
        {
            var enemyStruct = enemyData.EnemyStruct;
            
            var enemySpawn = Object.Instantiate(enemyStruct.Prefab, point.position, Quaternion.identity);
            enemySpawn.transform.SetParent(_rootEnemy);

            var enemyCompomemts = new EnemyComponents();
            enemyCompomemts.CircleCollider2D = enemySpawn.CircleCollider2D;
            enemyCompomemts.SpriteRenderer = enemySpawn.SpriteRenderer;
            enemyCompomemts.Rigidbody2D = enemySpawn.Rigidbody2D;
            enemyCompomemts.EnemyView = enemySpawn;

            var enemySettings = new EnemySettings();
            enemySettings.SpriteAnimatorConfig = enemyData.EnemySettings.SpriteAnimatorConfig;

            var model = new EnemyModel(enemyStruct, enemyCompomemts, enemySettings);

            return model;
        }
    }
}