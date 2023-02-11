using System.Linq;


namespace WORLDGAMEDEVELOPMENT
{
    public sealed class LevelController
    {
        #region Fields
        
        public LevelSettings CurrentLevelSettings;
        private readonly LevelData _levelData; 

        #endregion

        public LevelController(LevelData levelData)
        {
            _levelData = levelData;
            CurrentLevelSettings = _levelData.LevelStruct.LevelSettings.FirstOrDefault(e => e.CurrentLevel == Level.One);
        }
    }
}