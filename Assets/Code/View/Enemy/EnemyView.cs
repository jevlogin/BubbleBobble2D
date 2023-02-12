using System;
using Unity.VisualScripting;
using UnityEngine;


namespace WORLDGAMEDEVELOPMENT
{
    public sealed class EnemyView : MonoBehaviour, ICollision
    {
        #region Fields

        private Rigidbody2D _rigidbody2D;
        private CircleCollider2D _circleCollider2D;
        private SpriteRenderer _spriteRenderer;

        #endregion


        #region Properties

        public Rigidbody2D Rigidbody2D
        {
            get
            {
                if (_rigidbody2D == null)
                    _rigidbody2D = gameObject.GetOrAddComponent<Rigidbody2D>();
                return _rigidbody2D;
            }
        }

        public CircleCollider2D CircleCollider2D
        {
            get
            {
                if (_circleCollider2D == null)
                    _circleCollider2D = gameObject.GetOrAddComponent<CircleCollider2D>();
                return _circleCollider2D;
            }
        }

        public SpriteRenderer SpriteRenderer
        {
            get
            {
                if (_spriteRenderer == null)
                    _spriteRenderer = gameObject.GetOrAddComponent<SpriteRenderer>();
                return _spriteRenderer;
            }
        }

        public event Action<Collider2D> ColliderDetectChange;
        public event Action<SpriteRenderer> SpriteRendererDetectChange;

        #endregion


        #region UnityMethods

        private void OnTriggerEnter2D(Collider2D collision)
        {
            Debug.Log($"Collision to {collision.name}");
            ColliderDetectChange?.Invoke(collision);
            SpriteRendererDetectChange?.Invoke(SpriteRenderer);
        }

        #endregion
    }
}