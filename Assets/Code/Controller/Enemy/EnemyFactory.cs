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
            enemyCompomemts.Rigidbody2D.freezeRotation = true;

            enemyCompomemts.EnemyView = enemySpawn;

            enemyCompomemts.AIConfig = new AIConfig();

            switch (enemyStruct.AIStruct.EnemyType)
            {
                case EnemyType.Patrol:
                    break;
                case EnemyType.Stalker:
                    enemyCompomemts.AIConfig.Seeker = enemySpawn.Seeker;
                    enemyCompomemts.AIConfig.AIPatrolPath = enemySpawn.AIPatrolPath;
                    enemyCompomemts.AIConfig.AIPatrolPath.maxSpeed = enemyStruct.Speed;
                    enemyCompomemts.AIConfig.AIPatrolPath.enableRotation = false;
                    break;
                case EnemyType.Protector:
                    enemyCompomemts.AIConfig.Seeker = enemySpawn.Seeker;
                    enemyCompomemts.AIConfig.AIDestinationSetter = enemySpawn.AIDestinationSetter;
                    enemyCompomemts.AIConfig.AIPatrolPath = enemySpawn.AIPatrolPath;
                    enemyCompomemts.AIConfig.AIPatrolPath.maxSpeed = enemyStruct.Speed;
                    enemyCompomemts.AIConfig.AIPatrolPath.enableRotation = false;
                    break;
                default:
                    break;
            }

            var enemySettings = new EnemySettings();
            enemySettings.SpriteAnimatorConfig = enemyData.EnemySettings.SpriteAnimatorConfig;

            var model = new EnemyModel(enemyStruct, enemyCompomemts, enemySettings);

            return model;
        }
    }
}