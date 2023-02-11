using System.Collections.Generic;


namespace WORLDGAMEDEVELOPMENT
{
    public class LevelManager
    {
        public Level LevelCurrent;
        public Dictionary<Level, int> CountEnemyInLevel;

        public LevelManager(Level one)
        {
            LevelCurrent = one;
            CountEnemyInLevel= new Dictionary<Level, int>();
        }
    }
}