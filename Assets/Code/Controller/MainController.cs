using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;


namespace WORLDGAMEDEVELOPMENT
{
    public sealed class MainController : MonoBehaviour
    {
        private Camera _camera;
        [SerializeField] private LevelObjectView _playerView;
        private SpriteAnimator _playerAnimator;
        private PlayerController _playerController;
        private TurretController _turretController;
        private GunBulletShooterController _gunBulletShooterController;

        private Controller _controller;

        private Data _data;
        [SerializeField] private string _dataPath;

        private void Awake()
        {
            _data = Resources.Load<Data>(Path.Combine(ManagerPath.DATA, ManagerPath.DATA));
            if (_data == null) _data = Resources.Load<Data>(_dataPath);

            _controller = new Controller();

            #region Camera

            _camera = Camera.main;

            #endregion


            #region Player

            SpriteAnimatorConfig playerConfig = Resources.Load<SpriteAnimatorConfig>("Data/Player/PlayerSpriteAnimatorConfig");
            _playerAnimator = new SpriteAnimator(playerConfig);
            _playerController = new PlayerController(_playerView, _playerAnimator);

            #endregion


            #region Turret

            var turretFactory = new TurretFactory(_data.TurretData);
            var turretInitialization = new TurretInitialization(turretFactory);
            _turretController = new TurretController(_playerView.Transform, turretInitialization.TurretModel);

            //TODO - отрефакторить
            var poolBullet = new Pool<BulletView>(10, ManagerPath.BULLET);
            var bulletPool = new BulletPool(poolBullet,
                turretInitialization.TurretModel.TurretComponents.TransformBurrel);
            var bulletInitialization = new BulletInitialization(bulletPool);

            _gunBulletShooterController = new GunBulletShooterController(bulletInitialization,
                turretInitialization.TurretModel.TurretComponents.TransformBurrel);


            #endregion
        }

        private void Update()
        {
            _playerAnimator.Update();
            _playerController.Update();
            _gunBulletShooterController.Execute(Time.deltaTime);
        }

        private void FixedUpdate()
        {
            _turretController.FixedExecute(Time.fixedDeltaTime);
        }
    }
}