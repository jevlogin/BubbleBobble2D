using System.IO;
using UnityEngine;
using static UnityEditor.Progress;


namespace WORLDGAMEDEVELOPMENT
{
    [CreateAssetMenu(fileName = "Data", menuName = "Data/Data", order = 51)]
    public sealed class Data : ScriptableObject
    {
        #region Fields

        [SerializeField] private string _turrretDataPath;
        [SerializeField] private string _coinsDataPath;

        private TurretData _turretData;
        private CoinsData _coinsData;

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

        public CoinsData CoinsData
        {
            get
            {
                if (_coinsData == null)
                {
                    _coinsData = Resources.Load<CoinsData>(
                        Path.Combine(ManagerPath.DATA, ManagerPath.ITEMS, 
                        ManagerPath.COINS, ManagerPath.COINSDATA));
                    if (_coinsData == null)
                        _coinsData = Resources.Load<CoinsData>(_coinsDataPath);
                }
                return _coinsData;
            }
        }


    }
}