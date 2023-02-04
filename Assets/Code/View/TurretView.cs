using System;
using UnityEngine;


namespace WORLDGAMEDEVELOPMENT
{
    [Serializable]
    public sealed class TurretView : MonoBehaviour
    {
        #region Fields

        [SerializeField] private Transform _transformTurret;
        [SerializeField] private Transform _gunBurrel;

        #endregion


        #region Properties

        public Transform TransformTurret { get => _transformTurret; }
        public Transform GunBurrel { get => _gunBurrel; }

        #endregion


        #region UnityMethods

        private void Awake()
        {
            if (_transformTurret == null)
                _transformTurret = transform;

            if (_gunBurrel == null)
                _gunBurrel = transform.GetChild(1);
        }

        #endregion
    }
}