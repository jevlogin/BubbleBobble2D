using System;
using UnityEngine;


namespace WORLDGAMEDEVELOPMENT
{
    [Serializable]
    public sealed class CoinView : MonoBehaviour, ICollision
    {
        [SerializeField] private SpriteRenderer _spriteRenderer;
        [SerializeField] private Collider2D _collider2D;

        public event Action<Collider2D> ColliderDetectChange;
        public event Action<SpriteRenderer> SpriteRendererDetectChange;


        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent<PlayerView>(out var playerView))
            {
                ColliderDetectChange?.Invoke(_collider2D);
                SpriteRendererDetectChange?.Invoke(_spriteRenderer);
            }
        }

        public SpriteRenderer SpriteRenderer
        {
            get
            {
                if (_spriteRenderer == null)
                {
                    _spriteRenderer = GetComponent<SpriteRenderer>();
                }
                return _spriteRenderer;
            }

            set => _spriteRenderer = value;
        }

        public Collider2D Collider2D
        {
            get
            {
                if (_collider2D == null)
                    _collider2D = GetComponent<Collider2D>();
                return _collider2D;
            }

            set => _collider2D = value;
        }
    }
}