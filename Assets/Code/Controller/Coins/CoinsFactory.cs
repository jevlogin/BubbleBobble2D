using System;
using Unity.VisualScripting;
using UnityEngine;

namespace WORLDGAMEDEVELOPMENT
{
    internal class CoinsFactory
    {
        private CoinsData _coinsData;
        private CoinsModels _coinsModels;

        public CoinsFactory(CoinsData coinsData)
        {
            _coinsData = coinsData;
        }

        public CoinsModels CreateCoinsModel()
        {
            if (_coinsModels == null)
            {
                var coinsComponents = new CoinsComponents();
                var coinsSettings = new CoinsSettingsData();

                coinsComponents.CoinView = CreateCoinView();
                coinsComponents.Transform = coinsComponents.CoinView.transform;

                coinsSettings.SpriteAnimatorConfig = _coinsData.CoinsSettingsData.SpriteAnimatorConfig;

                _coinsModels = new CoinsModels(coinsComponents, coinsSettings);
            }

            return _coinsModels;
        }

        private CoinView CreateCoinView()
        {
            var view = new GameObject("Coins").AddComponent<CoinView>();
            var sprite = view.AddComponent<SpriteRenderer>();
            sprite.sprite = _coinsData.CoinsSettingsData.Sprite;
            return view;
        }
    }
}