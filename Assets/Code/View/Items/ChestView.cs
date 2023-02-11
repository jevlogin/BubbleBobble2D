using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class ChestView : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private Rigidbody2D _rigidbody2D;
    [SerializeField] private BoxCollider2D _boxCollider2D;
    [SerializeField] private SpringJoint2D _springJoint2D;

    public SpriteRenderer SpriteRenderer
    {
        get
        {
            if (_spriteRenderer == null)
            {
                _spriteRenderer = gameObject.GetOrAddComponent<SpriteRenderer>();
            }
            return _spriteRenderer;
        }
    }
    public Rigidbody2D Rigidbody2D
    {
        get
        {
            if (_rigidbody2D == null)
            {
                _rigidbody2D = gameObject.GetOrAddComponent<Rigidbody2D>();
            }
            return _rigidbody2D;
        }
    }
    public BoxCollider2D BoxCollider2D
    {
        get
        {
            if (_boxCollider2D == null)
            {
                _boxCollider2D = gameObject.GetOrAddComponent<BoxCollider2D>();
            }
            return _boxCollider2D;
        }
    }
    public SpringJoint2D SpringJoint2D
    {
        get
        {
            if (_springJoint2D == null)
            {
                _springJoint2D = gameObject.GetOrAddComponent<SpringJoint2D>();
            }
            return _springJoint2D;
        }
    }
}
