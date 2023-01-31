using UnityEngine;


namespace WORLDGAMEDEVELOPMENT
{
    internal class TurretFactory
    {
        private readonly TurretData _turretData;
        private TurretModel _turretModel;

        public TurretFactory(TurretData data)
        {
            _turretData = data;
        }

        public TurretModel CreateTurretModel()
        {
            if (_turretModel == null)
            {

                var turretStruct = _turretData.TurretStruct;
                var turretComponents = new TurretComponents();

                turretComponents.TurretView = Object.Instantiate(turretStruct.SpawnTurret).GetComponent<TurretView>();

                turretComponents.TransformTurret = turretComponents.TurretView.TransformTurret;
                turretComponents.TransformBurrel = turretComponents.TurretView.GunBurrel;


                var turretSettings = new TurretSettingsData();
                turretSettings.AngleMax = _turretData.TurretSettingsData.AngleMax;
                turretSettings.AngleMin = _turretData.TurretSettingsData.AngleMin;

                _turretModel = new TurretModel(turretStruct, turretComponents, turretSettings);
            }

            return _turretModel;
        }
    }
}