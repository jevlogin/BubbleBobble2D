using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace WORLDGAMEDEVELOPMENT
{
    public class LevelObjectView : MonoBehaviour
    {
        [SerializeField] private Transform _transform;
        [SerializeField] private SpriteRenderer _spriteRenderer;
        [SerializeField] private Rigidbody2D _ridgidBody2D;
        [SerializeField] private Collider2D collider2D1;

        public Transform Transform { get => _transform; set => _transform = value; }
        public SpriteRenderer SpriteRenderer { get => _spriteRenderer; set => _spriteRenderer = value; }
        public Rigidbody2D RidgidBody2D { get => _ridgidBody2D; set => _ridgidBody2D = value; }
        public Collider2D Collider2D { get => collider2D1; set => collider2D1 = value; }
    }
}