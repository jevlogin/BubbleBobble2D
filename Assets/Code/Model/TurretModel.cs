namespace WORLDGAMEDEVELOPMENT
{
    public sealed class TurretModel
    {
        public TurretStruct TurretStruct;
        public TurretComponents TurretComponents;
        public TurretSettingsData TurretSettings;

        public TurretModel(TurretStruct turretStruct, TurretComponents turretComponents, TurretSettingsData turretSettings)
        {
            TurretStruct = turretStruct;
            TurretComponents = turretComponents;
            TurretSettings = turretSettings;
        }
    }
}