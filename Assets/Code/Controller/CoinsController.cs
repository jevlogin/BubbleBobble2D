using System.Collections.Generic;
using UnityEngine;


namespace WORLDGAMEDEVELOPMENT
{
    internal class CoinsController : ICleanup
    {
        #region Fields

        private SpriteAnimatorController _coinsSpriteAnimatorController;
        private List<CoinsModels> _coinsModels;

        #endregion


        #region ClassLifeCycles

        public CoinsController(SpriteAnimatorController coinsSpriteAnimatorController, 
                                List<CoinsModels> coinsModels)
        {
            _coinsSpriteAnimatorController = coinsSpriteAnimatorController;
            _coinsModels = coinsModels;
            StartAnimationAllCoins();
            SubscrubeAllCoins();
        }

        #endregion


        #region Methods
        
        private void SubscrubeAllCoins()
        {
            foreach (var coins in _coinsModels)
            {
                coins.CoinsComponents.CoinView.ColliderDetectChange += CoinView_ColliderDetectChange;
                coins.CoinsComponents.CoinView.SpriteRendererDetectChange += CoinView_SpriteRendererDetectChange;
            }
        }

        private void StartAnimationAllCoins()
        {
            foreach (var coins in _coinsModels)
            {
                _coinsSpriteAnimatorController.StartAnimation(
                            coins.CoinsComponents.CoinView.SpriteRenderer,
                                        AnimState.Run, true, 10.0f);
            }
        } 

        #endregion



        #region Methods

        private void CoinView_SpriteRendererDetectChange(SpriteRenderer spriteRenderer)
        {
            _coinsSpriteAnimatorController.StopAnimation(spriteRenderer);
        }

        private void CoinView_ColliderDetectChange(Collider2D value)
        {
            value.gameObject.SetActive(false);
        }

        #endregion


        #region ICleanup

        public void Cleanup()
        {
            foreach (var coins in _coinsModels)
            {
                coins.CoinsComponents.CoinView.ColliderDetectChange -= CoinView_ColliderDetectChange;
                coins.CoinsComponents.CoinView.SpriteRendererDetectChange -= CoinView_SpriteRendererDetectChange;
            }
        }

        #endregion
    }
}