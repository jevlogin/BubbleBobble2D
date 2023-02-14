using Pathfinding;
using System;
using UnityEngine;


namespace WORLDGAMEDEVELOPMENT
{
    [Serializable]
    public sealed class EnemyComponents
    {
        [Header("Player Components. Unity.")]
        public Rigidbody2D Rigidbody2D;
        public CircleCollider2D CircleCollider2D;
        public SpriteRenderer SpriteRenderer;

        [Header("Player View"), Space(5)]
        public EnemyView EnemyView;

        [Header("AI")]
        public AIConfig AIConfig;
    }
}