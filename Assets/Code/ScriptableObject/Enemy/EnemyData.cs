using UnityEngine;


namespace WORLDGAMEDEVELOPMENT
{
    [CreateAssetMenu(fileName = "EnemyData", menuName = "Data/EnemyData", order = 51)]
    public sealed class EnemyData : ScriptableObject
    {
        [Header("Структура, префаб")] public EnemyStruct EnemyStruct;
        [Header("Компоненты")] public EnemyComponents EnemyComponents;
        [Header("Дополнительные настройки")] public EnemySettings EnemySettings;
    }
}