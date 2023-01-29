using UnityEngine;


namespace WORLDGAMEDEVELOPMENT
{
    public sealed class TurretController
    {
        #region Fields

        private TurretView _turretView;
        private Transform _transformPlayer;
        private TurretModel _turretModel;

        #endregion


        #region ClassLifeCycle

        public TurretController(Transform transformPlayer, TurretModel turretModel)
        {
            _transformPlayer = transformPlayer;
            _turretModel = turretModel;
            _turretView = _turretModel.TurretComponents.TurretView;
        }

        #endregion


        #region IFixedExecute

        public void FixedExecute(float deltaTime)
        {
            var direction = _transformPlayer.position - _turretView.GunBurrel.position;
            var angle = Vector3.Angle(Vector3.left, direction);
            var axis = Vector3.Cross(Vector3.left, direction);
            _turretView.GunBurrel.rotation = Quaternion.AngleAxis(angle, axis);
        }

        #endregion
    }
}