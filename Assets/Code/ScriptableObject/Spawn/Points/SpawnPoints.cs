using System.Collections.Generic;
using UnityEngine;


namespace WORLDGAMEDEVELOPMENT
{
    [CreateAssetMenu(fileName = "SpawnPoints", menuName = "Data/SpawnPoints", order = 51)]
    public sealed class SpawnPoints : ScriptableObject
    {
        public List<Transform> spawnPoints;
    }
}