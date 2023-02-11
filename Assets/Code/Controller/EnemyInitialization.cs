using System.Collections.Generic;


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

        private void CreareEnemyListStage(int countMonster)
        {
            for (int i = 0; i < countMonster; i++)
            {
                EnemyModels.Add(_enemyFactory.CreateEnemyModel());
            }
        }

        public void CreateEnemyModelStage(LevelSettings currentLevelSettings)
        {
            switch (currentLevelSettings.CurrentLevel)
            {
                case Level.Zero:
                    break;
                case Level.One:
                    EnemyModels.Clear();
                    if (currentLevelSettings.spriteAnimatorConfigOne != null)
                        CreareEnemyListStage(currentLevelSettings.CountMonsterOne);
                    if (currentLevelSettings.spriteAnimatorConfigTwo != null)
                        CreareEnemyListStage(currentLevelSettings.CountMonsterTwo);
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