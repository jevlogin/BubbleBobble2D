using System;
using UnityEngine;


namespace WORLDGAMEDEVELOPMENT
{
    [Serializable]
    public struct AIStruct
    {
        [Header("Patrol Config")]
        public float MinDistanceToTarget;
        public float MaxDistanceToTarget;
        public Transform[] waypoints;
        public EnemyType EnemyType;
    }
}