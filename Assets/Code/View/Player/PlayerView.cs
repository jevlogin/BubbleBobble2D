using Unity.VisualScripting;
using UnityEngine;


namespace WORLDGAMEDEVELOPMENT
{
    public sealed class PlayerView : MonoBehaviour
    {
        #region Fields
        
        [SerializeField] private CircleCollider2D _circleCollider2DPlayer;
        [SerializeField] private Rigidbody2D _rigidbody2DPlayer;
        [SerializeField] private Transform _transformPlayer;
        [SerializeField] private SpriteRenderer _spriteRendererPlayer;

        #endregion


        #region Properties

        public CircleCollider2D CircleCollider2DPlayer
        {
            get
            {
                if (_circleCollider2DPlayer == null)
                {
                    _circleCollider2DPlayer = gameObject.GetOrAddComponent<CircleCollider2D>();
                }
                return _circleCollider2DPlayer;
            }
            set => _circleCollider2DPlayer = value;
        }

        public Rigidbody2D Rigidbody2DPlayer
        {
            get
            {
                if (_rigidbody2DPlayer == null)
                {
                    _rigidbody2DPlayer = gameObject.GetOrAddComponent<Rigidbody2D>();
                }
                return _rigidbody2DPlayer;
            }
            set => _rigidbody2DPlayer = value;
        }

        public Transform TransformPlayer
        {
            get
            {
                if (_transformPlayer == null)
                {
                    _transformPlayer = transform;
                }
                return _transformPlayer;
            }
            set => _transformPlayer = value;
        }

        public SpriteRenderer SpriteRendererPlayer
        {
            get
            {
                if (_spriteRendererPlayer == null)
                {
                    _spriteRendererPlayer = gameObject.GetOrAddComponent<SpriteRenderer>();
                }
                return _spriteRendererPlayer;
            }
            set => _spriteRendererPlayer = value;
        }

        #endregion
    }
}