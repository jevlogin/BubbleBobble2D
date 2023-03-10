using System.IO;
using UnityEngine;


namespace WORLDGAMEDEVELOPMENT
{
    [CreateAssetMenu(fileName = "Data", menuName = "Data/Data", order = 51)]
    public sealed class Data : ScriptableObject
    {
        #region Fields

        [SerializeField] private string _turrretDataPath;
        [SerializeField] private string _coinsDataPath;
        [SerializeField] private string _spawnDataPath;
        [SerializeField] private string _presentDataPath;
        [SerializeField] private string _levelDataPath;

        private TurretData _turretData;
        private CoinsData _coinsData;
        private SpawnData _spawnData;
        private PresentData _presentData;
        private LevelData _levelData;

        #endregion


        #region LevelData

        public LevelData LevelData
        {
            get
            {
                if (_levelData == null)
                {
                    _levelData = Resources.Load<LevelData>(
                        Path.Combine(ManagerPath.DATA, ManagerPath.LEVEL, ManagerPath.LEVELDATA));
                    if (_levelData == null)
                        _levelData = Resources.Load<LevelData>(_levelDataPath);
                }
                return _levelData;
            }
        }

        #endregion


        #region PresentData

        public PresentData PresentData
        {
            get
            {
                if (_presentData == null)
                {
                    _presentData = Resources.Load<PresentData>(
                        Path.Combine(ManagerPath.DATA, ManagerPath.ITEMS, ManagerPath.PRESENT));
                    if (_presentData == null)
                        _presentData = Resources.Load<PresentData>(_presentDataPath);
                }
                return _presentData;
            }
        }

        #endregion


        #region SpawnData

        public SpawnData SpawnData
        {
            get
            {
                if (_spawnData == null)
                {
                    _spawnData = Resources.Load<SpawnData>(
                        Path.Combine(ManagerPath.DATA, ManagerPath.SPAWN, ManagerPath.SPAWNDATA));
                    if (_spawnData == null)
                    {
                        _spawnData = Resources.Load<SpawnData>(_spawnDataPath);
                    }
                }
                return _spawnData;
            }
        }

        #endregion


        #region TurretData

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

        #endregion


        #region CoinsData

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

        #endregion
    }
}