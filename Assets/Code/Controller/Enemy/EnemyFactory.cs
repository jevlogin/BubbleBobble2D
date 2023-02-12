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

        public EnemyModel CreateEnemyModel(EnemyData enemyData)
        {
            var enemyStruct = enemyData.EnemyStruct;
            
            var enemySpawn = Object.Instantiate(enemyStruct.Prefab, _rootEnemy);

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