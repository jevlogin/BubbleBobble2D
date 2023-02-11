using UnityEngine;


namespace WORLDGAMEDEVELOPMENT
{
    [CreateAssetMenu(fileName = "LevelData", menuName = "Data/LevelData", order = 51)]
    public sealed class LevelData : ScriptableObject
    {
        [Header("��������� �������")] public LevelStruct LevelStruct;
    }
}