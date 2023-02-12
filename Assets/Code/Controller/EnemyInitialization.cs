using System.Collections.Generic;
using System.Linq;

namespace WORLDGAMEDEVELOPMENT
{
    public sealed class EnemyInitialization
    {
        private EnemyFactory _enemyFactory;
        public List<EnemyModel> EnemyModels = new List<EnemyModel>();


        public EnemyInitialization(EnemyFactory enemyFactory)
        {
            _enemyFactory = enemyFactory;
        }

        private void CreareEnemyListStage(LevelSettings currentLevelSettings)
        {
            EnemyModels.Clear();
            foreach (var data in currentLevelSettings.EnemyDataList)
            {
                for (int i = 0; i < data.EnemySettings.CountEnemyToLevel; i++)
                {
                    EnemyModels.Add(_enemyFactory.CreateEnemyModel(data));
                }
            }
        }

        public void CreateEnemyModelStage(LevelSettings currentLevelSettings)
        {
            switch (currentLevelSettings.CurrentLevel)
            {
                case Level.Zero:
                    break;
                case Level.One:
                    CreareEnemyListStage(currentLevelSettings);
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