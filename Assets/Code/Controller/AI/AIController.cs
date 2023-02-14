using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace WORLDGAMEDEVELOPMENT
{
    public sealed class AIController
    {
        private List<EnemyModel> _enemyModels;

        public AIController(List<EnemyModel> enemyModels, SpawnComponents spawnComponents)
        {
            _enemyModels = enemyModels;
        }
    }
}