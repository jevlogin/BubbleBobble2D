using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


namespace WORLDGAMEDEVELOPMENT
{
    public sealed class AIController
    {
        private readonly Controllers _controllers;
        private List<EnemyModel> _enemyModels;
        private readonly SpawnComponents _spawnComponents;

        public AIController(List<EnemyModel> enemyModels, 
            SpawnComponents spawnComponents, Controllers controllers)
        {
            _controllers = controllers;
            _enemyModels = enemyModels;
            _spawnComponents = spawnComponents;

            StatePositionModels(_enemyModels, _spawnComponents.SpawnViewPatrolLevel.SpawnPointList,
                _spawnComponents.SpawnProtectorZoneTrigger);

            var enemyModelPatrol = _enemyModels.FirstOrDefault(m => m.EnemyStruct.AIStruct.EnemyType == EnemyType.Patrol);
            var enemyModelProtector= _enemyModels.FirstOrDefault(m => m.EnemyStruct.AIStruct.EnemyType == EnemyType.Protector);

            var _simplePatrolAI = new SimplePatrolAI(new SimplePatrolAIModel(enemyModelPatrol));
            _controllers.Add(_simplePatrolAI);

            var protectorAI = new ProtectorAI(enemyModelProtector, 
                new PatrolAIModel(_spawnComponents.SpawnViewPatrolLevel.SpawnPointList.ToArray()));
            _controllers.Add(protectorAI);

            var protectedZone = new ProtectedZone(new List<IProtector> { protectorAI }, spawnComponents.SpawnProtectorZoneTrigger);
            _controllers.Add(protectedZone);
        }


        #region Methods

        private void StatePositionModels(List<EnemyModel> enemyModels,
            List<Transform> spawnPointList, LevelObjectTrigger spawnProtectorZoneTrigger)
        {
            foreach (var model in enemyModels)
            {
                switch (model.EnemyStruct.AIStruct.EnemyType)
                {
                    case EnemyType.Patrol:
                        model.EnemyComponents.EnemyView.transform.position =
                            spawnPointList[UnityEngine.Random.Range(0, spawnPointList.Count)].position;
                        model.EnemyStruct.AIStruct.Waypoints = spawnPointList.ToArray();
                        break;
                    case EnemyType.Stalker:
                        break;
                    case EnemyType.Protector:
                        model.EnemyComponents.EnemyView.transform.position =
                            spawnProtectorZoneTrigger.transform.position;
                        break;
                    default:
                        break;
                }
            }
        } 

        #endregion


    }
}