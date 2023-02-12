using System.Collections.Generic;
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


        private void CreareEnemyListStage(LevelSettings currentLevelSettings, 
                                            List<Transform> spawnPointList)
        {
            EnemyModels.Clear();
            foreach (var data in currentLevelSettings.EnemyDataList)
            {
                for (int i = 0; i < data.EnemySettings.CountEnemyToLevel; i++)
                {
                    var point = spawnPointList[i % spawnPointList.Count];
                    EnemyModels.Add(_enemyFactory.CreateEnemyModel(data, point));
                }
            }
        }

        public void CreateEnemyModelStage(LevelSettings currentLevelSettings, 
                        List<Transform> spawnPointList)
        {
            switch (currentLevelSettings.CurrentLevel)
            {
                case Level.Zero:
                    break;
                case Level.One:
                    CreareEnemyListStage(currentLevelSettings, spawnPointList);
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