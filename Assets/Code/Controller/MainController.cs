using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.PlayerLoop;

namespace WORLDGAMEDEVELOPMENT
{
    public sealed class MainController : MonoBehaviour, IDisposable
    {
        //TODO - refactor the fields later. I know it's not very good code. This is an incomprehensible code)) But, this is my fantastic code =)
        private Camera _camera;
        [SerializeField] private LevelObjectView _playerView;
        private SpriteAnimatorController _playerAnimator;
        private PlayerController _playerController;
        private TurretController _turretController;
        private GunBulletShooterController _gunBulletShooterController;

        private Controllers _controllers;

        private Data _data;
        [SerializeField] private string _dataPath;

        private void Awake()
        {
            _data = Resources.Load<Data>(Path.Combine(ManagerPath.DATA, ManagerPath.DATA));
            if (_data == null) _data = Resources.Load<Data>(_dataPath);

            _controllers = new Controllers();

            #region Camera

            //TODO - later updated. Navigation move to player
            _camera = Camera.main;

            #endregion


            #region Player


            SpriteAnimatorConfig playerConfig = Resources.Load<SpriteAnimatorConfig>("Data/Player/PlayerSpriteAnimatorConfig");
            _playerAnimator = new SpriteAnimatorController(playerConfig);
            _controllers.Add(_playerAnimator);

            //TODO - later added to _controllers.

            var contactPollerPlayer = new ContactPoller(_playerView.Collider2D);
            _controllers.Add(contactPollerPlayer);

            _playerController = new PlayerController(_playerView, _playerAnimator, contactPollerPlayer);
            _controllers.Add(_playerController);

            #endregion


            #region Turret

            var turretFactory = new TurretFactory(_data.TurretData);
            var turretInitialization = new TurretInitialization(turretFactory);
            _turretController = new TurretController(_playerView.Transform, turretInitialization.TurretModel);
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


            #region ContactPoler

            //var contactPoler = new ContactPoller();


            #endregion
        }

        private void Update()
        {
            _controllers.Execute(Time.deltaTime);
        }

        private void FixedUpdate()
        {
            _controllers.FixedExecute(Time.fixedDeltaTime);
        }

        public void Dispose()
        {
            _controllers.Cleanup();
        }
    }
}