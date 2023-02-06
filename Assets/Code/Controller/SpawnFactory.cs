using UnityEngine;


namespace WORLDGAMEDEVELOPMENT
{
    internal class SpawnFactory
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

            var spawnPrefab = Object.Instantiate(spawnStruct.Prefab);

            for (int i = 0; i < spawnPrefab.SpawnPointList.Count; i++)
            {
                spawnComponents.SpawnPoints.Add(spawnPrefab.SpawnPointList[i].position);
                spawnPrefab.SpawnPointList[i].gameObject.SetActive(false);
            }

            _spawnModel = new SpawnModel(spawnStruct, spawnComponents);
            
            return _spawnModel;
        }
    }
}