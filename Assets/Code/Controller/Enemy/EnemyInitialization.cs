using Pathfinding;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace WORLDGAMEDEVELOPMENT
{
    public sealed class EnemyInitialization
    {
        #region Fields

        private EnemyFactory _enemyFactory;
        public List<EnemyModel> EnemyModels = new List<EnemyModel>();

        #endregion


        #region ClassLifeCycles

        public EnemyInitialization(EnemyFactory enemyFactory)
        {
            _enemyFactory = enemyFactory;
        }

        #endregion


        private void CreareEnemyListStage(LevelSettings currentLevelSettings, SpawnModel spawnModel)
        {
            var spawnPointList = spawnModel.SpawnComponents.SpawnViewEnemy.SpawnPointList;

            EnemyModels.Clear();
            foreach (var data in currentLevelSettings.EnemyDataList)
            {
                for (int i = 0; i < data.EnemySettings.CountEnemyToLevel; i++)
                {
                    var point = spawnPointList[i % spawnPointList.Count];
                    EnemyModels.Add(_enemyFactory.CreateEnemyModel(data, point));
                }
            }
            foreach (var enemyModel in EnemyModels)
            {
                switch (enemyModel.EnemyStruct.AIStruct.EnemyType)
                {
                    case EnemyType.Patrol:
                        enemyModel.EnemyStruct.AIStruct.Waypoints =
                            spawnModel.SpawnComponents.SpawnViewPatrolLevel.SpawnPointList.ToArray();
                        break;
                    case EnemyType.Stalker:
                        //TODO - set player, to target
                        enemyModel.EnemyComponents.AIConfig.Seeker =
                            enemyModel.EnemyComponents.EnemyView.GetOrAddComponent<Seeker>();
                        break;
                    case EnemyType.Protector:
                        enemyModel.EnemyStruct.AIStruct.Waypoints =
                            spawnModel.SpawnComponents.SpawnViewPatrolLevel.SpawnPointList.ToArray();
                        enemyModel.EnemyComponents.AIConfig.ProtectorZoneTrigger =
                            spawnModel.SpawnComponents.SpawnProtectorZoneTrigger;

                        //TODO - refactoring
                        var path = enemyModel.EnemyComponents.AIConfig.AIPatrolPath 
                            = enemyModel.EnemyComponents.EnemyView.GetOrAddComponent<AIPatrolPath>();
                        path.orientation = OrientationMode.YAxisForward;
                        path.enableRotation = false;
                        path.maxSpeed = enemyModel.EnemyStruct.Speed;

                        var setter = enemyModel.EnemyComponents.AIConfig.AIDestinationSetter 
                            = enemyModel.EnemyComponents.EnemyView.GetOrAddComponent<AIDestinationSetter>();
                        setter.enabled= false;
                        setter.enabled= true;
                        break;
                    default:
                        break;
                }
            }
        }

        public void CreateEnemyModelStage(LevelSettings currentLevelSettings, SpawnModel spawnModel)
        {
            switch (currentLevelSettings.CurrentLevel)
            {
                case Level.Zero:
                    break;
                case Level.One:
                    CreareEnemyListStage(currentLevelSettings, spawnModel);
                    break;
                case Level.Two:
                    break;
                case Level.Three:
                    break;
                default:
                    break;
            }
        }
    }
}