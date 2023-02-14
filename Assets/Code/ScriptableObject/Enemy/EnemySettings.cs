using System;
using UnityEngine;


namespace WORLDGAMEDEVELOPMENT
{
    [Serializable]
    public sealed class EnemySettings
    {
        [Header("Настройки игрока")]
        public SpriteAnimatorConfig SpriteAnimatorConfig;
        public int CountEnemyToLevel;
    }
}