using UnityEngine;


namespace WORLDGAMEDEVELOPMENT
{
    internal class TurretFactory
    {
        private TurretData _turretData;
        private TurretModel _turretModel;

        public TurretFactory(TurretData turretData)
        {
           _turretData = turretData;
        }

        public TurretModel CreateTurretModel()
        {
            if (_turretModel == null)
            {
                var turretComponents = _turretData.TurretComponents;
                var turretSettings = _turretData.TurretSettingsData;

                var spawnTurret = Object.Instantiate(_turretData.TurretComponents.TurretView);

              

                //components
                turretComponents.TurretView = spawnTurret;
                turretComponents.TransformTurret = spawnTurret.TransformTurret;
                turretComponents.TransformBurrel = spawnTurret.GunBurrel;

                //settings

                _turretModel = new TurretModel(turretComponents, turretSettings);
            }

            return _turretModel;
        }
    }
}