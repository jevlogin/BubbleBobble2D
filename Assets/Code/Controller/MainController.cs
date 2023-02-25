using System;
using System.IO;
using System.Linq;
using UnityEngine;


namespace WORLDGAMEDEVELOPMENT
{
    public sealed class MainController : MonoBehaviour, IDisposable
    {
        #region Fields
        
        [SerializeField] private Camera _camera;
        [SerializeField] private PlayerView _playerView;
        [SerializeField] private GenerateLevelView _generateLevelView;
        [SerializeField] private string _dataPath; 

        private GeneratorLevelController _generatorLevelController;
        private SpriteAnimatorController _playerAnimator;
        private PlayerController _playerController;
        private TurretController _turretController;
        private GunBulletShooterController _gunBulletShooterController;
        private Controllers _controllers;
        private Data _data;

        #endregion


        private void Awake()
        {
            _data = Resources.Load<Data>(Path.Combine(ManagerPath.DATA, ManagerPath.DATA));
            if (_data == null) _data = Resources.Load<Data>(_dataPath);

            _controllers = new Controllers();

            #region Camera

            if (_camera == null)
                _camera = Camera.main; 
            var cameraController = new CameraController(_camera, _playerView.TransformPlayer);
            _controllers.Add(cameraController);

            #endregion

            _generatorLevelController = new GeneratorLevelController(_generateLevelView);
            _controllers.Add(_generatorLevelController);



            #region Player

            SpriteAnimatorConfig playerConfig = Resources.Load<SpriteAnimatorConfig>("Data/Player/PlayerSpriteAnimatorConfig");
            _playerAnimator = new SpriteAnimatorController(playerConfig);
            _controllers.Add(_playerAnimator);

            //TODO - later added to _controllers.

            var contactPollerPlayer = new ContactsPoller(_playerView.CircleCollider2DPlayer);
            _controllers.Add(contactPollerPlayer);

            _playerController = new PlayerController(_playerView, _playerAnimator, contactPollerPlayer);
            _controllers.Add(_playerController);

            #endregion


            #region Turret

            var turretFactory = new TurretFactory(_data.TurretData);
            var turretInitialization = new TurretInitialization(turretFactory);
            _turretController = new TurretController(_playerView.TransformPlayer, turretInitialization.TurretModel);
            _controllers.Add(_turretController);

            //TODO - later refactoring
            var poolBullet = new Pool<BulletView>(10, Path.Combine(ManagerPath.PREFABS, ManagerPath.BULLET, ManagerPath.BULLET));
            var bulletPool = new BulletPool(poolBullet,
                turretInitialization.TurretModel.TurretComponents.TransformBurrel);
            var bulletInitialization = new BulletInitialization(bulletPool);

            _gunBulletShooterController = new GunBulletShooterController(bulletInitialization,
                turretInitialization.TurretModel.TurretComponents.TransformBurrel);
            _controllers.Add(_gunBulletShooterController);

            #endregion


            #region SpawnData

            var spawnFactory = new SpawnFactory(_data.SpawnData);
            var spawnInitialization = new SpawnInitialization(spawnFactory);

            #endregion


            #region LevelManager

            var levelController = new LevelController(_data.LevelData);

            #endregion


            #region Enemy

            var enemyFactory = new EnemyFactory();
            var enemyInitialization = new EnemyInitialization(enemyFactory);

            enemyInitialization.CreateEnemyModelStage(levelController.CurrentLevelSettings, 
                spawnInitialization.SpawnModel);

            #endregion


            #region AI


            var AIController = new AIController(enemyInitialization.EnemyModels, 
                            spawnInitialization.SpawnModel.SpawnComponents, _controllers);

            #endregion


            #region Coins

            var coinsFactory = new CoinsFactory(_data.CoinsData);
            var coinsInitialization = new CoinsInitialization(coinsFactory);
            coinsInitialization.CreateCoins(spawnInitialization.SpawnModel.SpawnComponents.SpawnViewCoins.SpawnPointList);

            var coinsSpriteAnimatorController =
                    new SpriteAnimatorController(coinsInitialization.CoinsModels.FirstOrDefault().CoinsSettings.SpriteAnimatorConfig);
            _controllers.Add(coinsSpriteAnimatorController);

            var coinsManager = new CoinsController(coinsSpriteAnimatorController, coinsInitialization.CoinsModels);
            _controllers.Add(coinsManager);

            #endregion


            #region Chest

            var presentFactory = new PresentFactory(_data.PresentData);
            var presentInitialization = new PresentInitialization(presentFactory);

            #endregion


            _controllers.Awake();
        }


        #region UnityMethods

        private void Start()
        {
            _controllers.Initialize();
        }

        private void Update()
        {
            _controllers.Execute(Time.deltaTime);
        }

        private void FixedUpdate()
        {
            _controllers.FixedExecute(Time.fixedDeltaTime);
        }

        private void LateUpdate()
        {
            _controllers.LateExecute(Time.fixedDeltaTime);
        }

        #endregion


        #region IDispose

        public void Dispose()
        {
            _controllers.Cleanup();
        }

        #endregion
    }
}