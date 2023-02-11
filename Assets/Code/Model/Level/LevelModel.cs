using UnityEngine;


namespace WORLDGAMEDEVELOPMENT
{
    public sealed class LevelModel : MonoBehaviour
    {
        public LevelStruct LevelStruct;

        public LevelModel(LevelStruct levelStruct)
        {
            LevelStruct = levelStruct;
        }
    }
}