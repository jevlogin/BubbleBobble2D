using System.Collections.Generic;
using UnityEngine;


namespace WORLDGAMEDEVELOPMENT
{
    public class CoinsInitialization
    {
        #region Fields

        private CoinsFactory _coinsFactory;
        public List<CoinsModels> CoinsModels = new List<CoinsModels>();

        #endregion


        #region ClassLifeCycles

        public CoinsInitialization(CoinsFactory coinsFactory)
        {
            _coinsFactory = coinsFactory;
        }

        #endregion


        #region Methods

        public void CreateCoins(List<Vector3> spawnPoints)
        {
            for (int i = 0; i < spawnPoints.Count; i++)
            {
                CoinsModels.Add(_coinsFactory.CreateCoinsModel(spawnPoints[i]));
            }
        }

        #endregion
    }
}