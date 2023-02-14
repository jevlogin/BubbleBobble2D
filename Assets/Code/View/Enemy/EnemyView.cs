using Pathfinding;
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
        private Seeker _seeker;
        private AIDestinationSetter _aIDestinationSetter;
        private AIPatrolPath _aIPatrolPath;

        #endregion


        #region Properties

        public AIPatrolPath AIPatrolPath
        {
            get
            {
                if (_aIPatrolPath == null)
                {
                    _aIPatrolPath = gameObject.GetOrAddComponent<AIPatrolPath>();
                    _aIPatrolPath.orientation = OrientationMode.YAxisForward;
                    _aIPatrolPath.radius = 0.4f;
                }
                return _aIPatrolPath;
            }
        }


        public AIDestinationSetter AIDestinationSetter
        {
            get
            {
                if (_aIDestinationSetter == null)
                    _aIDestinationSetter = gameObject.GetOrAddComponent<AIDestinationSetter>();
                return _aIDestinationSetter;
            }
        }

        public Seeker Seeker
        {
            get
            {
                if (_seeker == null) _seeker = gameObject.GetOrAddComponent<Seeker>();
                return _seeker;
            }
        }


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