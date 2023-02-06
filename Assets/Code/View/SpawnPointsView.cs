using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace WORLDGAMEDEVELOPMENT
{
    [Serializable]
    public sealed class SpawnPointsView : MonoBehaviour
    {
        public List<Transform> SpawnPointList = new();

        private void OnEnable()
        {
            foreach (Transform t in transform)
            {
                SpawnPointList.Add(t);
            }
        }
    }
}