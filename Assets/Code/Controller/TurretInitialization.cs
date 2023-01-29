namespace WORLDGAMEDEVELOPMENT
{
    internal class TurretInitialization
    {
        public TurretModel TurretModel;

        private readonly TurretFactory _turretFactory;


        public TurretInitialization(TurretFactory turretFactory)
        {
            _turretFactory = turretFactory;
            TurretModel = _turretFactory.CreateTurretModel();
        }
    }
}