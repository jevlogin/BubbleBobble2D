using Unity.VisualScripting;
using UnityEngine;


namespace WORLDGAMEDEVELOPMENT
{
    public class CoinsFactory
    {
        #region Fields

        private readonly CoinsData _coinsData;
        private CoinsModels _coinsModels;

        #endregion


        #region ClassLifeCycles

        public CoinsFactory(CoinsData coinsData)
        {
            _coinsData = coinsData;
        }

        #endregion


        #region Methods

        public CoinsModels CreateCoinsModel(Vector3 position)
        {
            var coinsComponents = new CoinsComponents();
            var coinsSettings = new CoinsSettingsData();

            coinsComponents.CoinView = CreateCoinView(position);
            coinsComponents.Transform = coinsComponents.CoinView.transform;

            coinsSettings.SpriteAnimatorConfig = _coinsData.CoinsSettingsData.SpriteAnimatorConfig;

            _coinsModels = new CoinsModels(coinsComponents, coinsSettings);

            return _coinsModels;
        }

        private CoinView CreateCoinView(Vector3 position)
        {
            var view = new GameObject("Coins").AddComponent<CoinView>();
            view.transform.position = position;

            var collider = view.AddComponent<CircleCollider2D>();
            collider.isTrigger = true;

            var sprite = view.AddComponent<SpriteRenderer>();
            sprite.sprite = _coinsData.CoinsSettingsData.Sprite;

            view.SpriteRenderer = sprite;
            view.Collider2D = collider;

            return view;
        }

        #endregion
    }
}