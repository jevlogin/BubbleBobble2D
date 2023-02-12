using System;
using System.Collections.Generic;
using UnityEngine;


namespace WORLDGAMEDEVELOPMENT
{
    [Serializable]
    public sealed class LevelSettings
    {
        #region Fields

        [Header("Enemy Data List")] public List<EnemyData> EnemyDataList = new List<EnemyData>();
        [Header("Current Level")] public Level CurrentLevel;

        #endregion
    }
}