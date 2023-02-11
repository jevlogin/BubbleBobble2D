﻿using System.Collections.Generic;


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

        public void CreateEnemyModelStage(Level level)
        {
            switch (level)
            {
                case Level.Zero:
                    break;
                case Level.One:
                    var countMonster = 6;
                    CreareEnemyListStage(countMonster);
                    break;
                case Level.Two:
                    break;
                case Level.Three:
                    break;
                default:
                    break;
            }
        }

        private void CreareEnemyListStage(int countMonster)
        {
            EnemyModels.Clear();
            for (int i = 0; i < countMonster; i++)
            {
                EnemyModels.Add(_enemyFactory.CreateEnemyModel());
            }
        }
    }
}