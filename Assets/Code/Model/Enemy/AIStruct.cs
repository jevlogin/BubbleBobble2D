using System;
using UnityEngine;


namespace WORLDGAMEDEVELOPMENT
{
    [Serializable]
    public struct AIStruct
    {
        public float MinSqrDistanceToTarget;
        public float MaxDistanceToTarget;
        public Transform[] Waypoints;
        public EnemyType EnemyType;
    }
}