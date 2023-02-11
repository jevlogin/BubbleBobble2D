using System;
using UnityEngine;

namespace WORLDGAMEDEVELOPMENT
{
    [Serializable]
    public sealed class LevelSettings
    {
        #region Fields

        [Header("Phirst Enemy Config")] public SpriteAnimatorConfig spriteAnimatorConfigOne;
        [Header("Second Enemy Config")] public SpriteAnimatorConfig spriteAnimatorConfigTwo;

        [Header("Current Level")] public Level CurrentLevel;

        [Header("Phirst Enemy Count")] public int CountMonsterOne;
        [Header("Second Enemy Count")] public int CountMonsterTwo;

        #endregion
    }
}