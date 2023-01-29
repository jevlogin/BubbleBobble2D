using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace WORLDGAMEDEVELOPMENT
{
    public sealed class Pool<T> where T : Component
    {
        #region Fields

        public T Prefab;
        public int Size;

        #endregion


        #region ClassLifeCycles

        public Pool(int count, string path)
        {
            Size = count;
            Prefab = Resources.Load<T>(path);
        }

        #endregion
    }
}