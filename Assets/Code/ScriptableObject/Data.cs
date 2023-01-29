using System.IO;
using UnityEngine;


namespace WORLDGAMEDEVELOPMENT
{
    [CreateAssetMenu(fileName = "Data", menuName = "Data/Data", order = 51)]
    public sealed class Data : ScriptableObject
    {
        #region Fields

        [SerializeField] private string _turrretDataPath;

        private TurretData _turretData;

        #endregion


        public TurretData TurretData
        {
            get
            {
                if (_turretData == null)
                {
                    _turretData = Resources.Load<TurretData>(Path.Combine(ManagerPath.DATA, ManagerPath.TURRET));
                    if (_turretData == null)
                    {
                        _turretData = Resources.Load<TurretData>(_turrretDataPath);
                    }
                }
                return _turretData;
            }
        }
    }
}