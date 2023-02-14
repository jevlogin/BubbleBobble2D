﻿using System;


namespace WORLDGAMEDEVELOPMENT
{
    [Serializable]
    public struct SpawnStruct
    {
        public SpawnPointsView PrefabCoins;
        public SpawnPointsView SpawnEnemyPoints;
        public SpawnPointsView SpawnPatrolPoints;
        public LevelObjectTrigger ProtectedZoneTrigger;
    }
}