using System;
using UnityEngine;


namespace WORLDGAMEDEVELOPMENT
{
    [Serializable]
    public sealed class EnemyComponents
    {
        public Rigidbody2D Rigidbody2D;
        public CircleCollider2D CircleCollider2D;
        public SpriteRenderer SpriteRenderer;
        public EnemyView EnemyView;
    }
}