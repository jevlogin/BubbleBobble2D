namespace WORLDGAMEDEVELOPMENT
{
    public sealed class SpawnInitialization
    {
        private readonly SpawnFactory _spawnFactory;
        public SpawnModel SpawnModel;

        public SpawnInitialization(SpawnFactory spawnFactory)
        {
            _spawnFactory = spawnFactory;
            SpawnModel = _spawnFactory.CreateSpawnModel();
        }
    }
}