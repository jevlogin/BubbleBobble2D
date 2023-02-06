using UnityEngine;


namespace WORLDGAMEDEVELOPMENT
{
    public sealed class SpawnModel
    {
        public SpawnStruct SpawnStruct;
        public SpawnComponents SpawnComponents;

        public SpawnModel(SpawnStruct spawnStruct, SpawnComponents spawnComponents)
        {
            SpawnStruct = spawnStruct;
            SpawnComponents = spawnComponents;
        }
    }
}