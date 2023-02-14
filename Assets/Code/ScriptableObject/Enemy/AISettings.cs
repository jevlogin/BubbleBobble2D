using Pathfinding;
using System;
using UnityEngine;

namespace WORLDGAMEDEVELOPMENT
{
    [Serializable]
    public sealed class AISettings
    {
        [Header("Patrol Config")]
        public float MinDistanceToTarget;
        public float MaxDistanceToTarget;
        public EnemyType EnemyType;
    }
}