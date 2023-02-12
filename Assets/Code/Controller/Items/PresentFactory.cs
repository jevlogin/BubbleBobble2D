using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace WORLDGAMEDEVELOPMENT
{
    public sealed class PresentFactory
    {
        private PresentData _presentData;


        public PresentFactory(PresentData presentData)
        {
            _presentData = presentData;
        }

        public PresentModel GetOrCreatePresentModels()
        {
            var presentStruct = _presentData.PresentStruct;

            var presentChest = Object.Instantiate(presentStruct.PrefabChest);
            var presentItemsOne = Object.Instantiate(presentStruct.PrefabItemsOne);
            //presentChest.SetActive(false);

            var presentComponents = new PresentComponents();
            presentComponents.PresentChest = presentChest;
            presentComponents.PresentOne = presentItemsOne;

            var presentModel = new PresentModel(presentStruct, presentComponents);

            return presentModel;
        }
    }
}