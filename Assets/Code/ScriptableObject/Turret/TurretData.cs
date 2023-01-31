using UnityEngine;


namespace WORLDGAMEDEVELOPMENT
{
    [CreateAssetMenu(fileName = "TurretData", menuName = "Data/TurretData", order = 51)]
    public sealed class TurretData : ScriptableObject
    {
        #region Fields
        [Space(20), Header("������")] public TurretStruct TurretStruct;
        [Space(20), Header("����������")] public TurretComponents TurretComponents;
        [Space(20), Header("�������������� ���������")] public TurretSettingsData TurretSettingsData;

        #endregion
    }
}