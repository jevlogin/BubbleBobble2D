using System;
using UnityEngine;


namespace WORLDGAMEDEVELOPMENT
{
    public interface ICollision
    {
        event Action<Collider2D> ColliderDetectChange;
        event Action<SpriteRenderer> SpriteRendererDetectChange;
    }
}