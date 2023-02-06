using UnityEngine;


namespace WORLDGAMEDEVELOPMENT
{
    [CreateAssetMenu(fileName = "SpawnData", menuName = "Data/SpawnData", order = 51)]
    public sealed class SpawnData : ScriptableObject
    {
        [Header("Prefabs Spawn objects and Components")] public SpawnStruct SpawnStruct;
        [Header("Components for Spawn Objects")] public SpawnComponents SpawnComponents;

    }
}