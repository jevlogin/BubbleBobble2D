namespace WORLDGAMEDEVELOPMENT
{
    public sealed class TurretModel
    {
        public TurretComponents TurretComponents;
        public TurretSettingsData TurretSettings;

        public TurretModel(TurretComponents turretComponents, TurretSettingsData turretSettings)
        {
            TurretComponents = turretComponents;
            TurretSettings = turretSettings;
        }
    }
}