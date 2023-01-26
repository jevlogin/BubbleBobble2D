using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace WORLDGAMEDEVELOPMENT
{
    public sealed class MainController : MonoBehaviour
    {
        private Camera _camera;
        [SerializeField] private LevelObjectView _playerView;
        [SerializeField] private int _animationSpeed = 10;
        private SpriteAnimator _playerAnimator;

        private void Awake()
        {
            _camera = Camera.main;
            SpriteAnimatorConfig playerConfig = Resources.Load<SpriteAnimatorConfig>("Data/Player/PlayerSpriteAnimatorConfig");
            _playerAnimator = new SpriteAnimator(playerConfig);
            _playerAnimator.StartAnimation(_playerView.SpriteRenderer, AnimState.Iddle, true, _animationSpeed);
        }

        private void Update()
        {
            _playerAnimator.Update();
        }

        private void FixedUpdate()
        {
            
        }
    }
}