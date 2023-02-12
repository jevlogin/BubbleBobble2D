using System.Collections.Generic;
using UnityEngine;


namespace WORLDGAMEDEVELOPMENT
{
    public sealed class SpawnFactory
    {
        private readonly SpawnData _spawnData;
        private SpawnModel _spawnModel;

        public SpawnFactory(SpawnData spawnData)
        {
            _spawnData = spawnData;
        }

        public SpawnModel CreateSpawnModel()
        {
            var spawnStruct = _spawnData.SpawnStruct;

            var spawnComponents = new SpawnComponents();

            var spawnPrefabCoins = Object.Instantiate(spawnStruct.PrefabCoins);
            spawnComponents.SpawnViewCoins = spawnPrefabCoins;

            var spawnPrefabEnemy = Object.Instantiate(spawnStruct.SpawnEnemyPoints);
            spawnComponents.SpawnViewEnemy = spawnPrefabEnemy;

            SetActiveFalseThisComponent(spawnPrefabCoins.SpawnPointList);
            SetActiveFalseThisComponent(spawnPrefabEnemy.SpawnPointList);

            _spawnModel = new SpawnModel(spawnStruct, spawnComponents);

            return _spawnModel;
        }

        private void SetActiveFalseThisComponent(List<Transform> spawnPointList)
        {
            foreach (var spawnPoint in spawnPointList) { spawnPoint.gameObject.SetActive(false); }
        }
    }
}