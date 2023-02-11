using UnityEngine;


namespace WORLDGAMEDEVELOPMENT
{
    [CreateAssetMenu(fileName = "EnemyData", menuName = "Data/EnemyData", order = 51)]
    public sealed class EnemyData : ScriptableObject
    {
        [Header("���������, ������")] public EnemyStruct EnemyStruct;
        [Header("����������")] public EnemyComponents EnemyComponents;
        [Header("�������������� ���������")] public EnemySettings EnemySettings;
    }
}