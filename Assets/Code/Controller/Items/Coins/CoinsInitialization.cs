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

        public void CreateCoins(List<Transform> spawnPointList)
        {
            for (int i = 0; i < spawnPointList.Count; i++)
            {
                CoinsModels.Add(_coinsFactory.CreateCoinsModel(spawnPointList[i].position));
            }
        }

        #endregion
    }
}