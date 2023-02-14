using Pathfinding;
using System;
using UnityEngine;


namespace WORLDGAMEDEVELOPMENT
{
    [Serializable]
    public sealed class AIConfig
    {
        [Header("Protector Config")]
        public AIDestinationSetter AIDestinationSetter;
        public AIPatrolPath AIPatrolPath;
        public LevelObjectTrigger ProtectorZoneTrigger;

        [Header("Stalker")]
        public Seeker Seeker;
    }
}