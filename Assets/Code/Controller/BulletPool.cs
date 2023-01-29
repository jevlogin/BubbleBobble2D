using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace WORLDGAMEDEVELOPMENT
{
    public sealed class BulletPool : GenericObjectPool<BulletView>
    {
        public BulletPool(Pool<BulletView> pool, Transform transformParent) : base(pool, transformParent)
        {
        }
    }
}