using UnityEngine;


namespace WORLDGAMEDEVELOPMENT
{
    [CreateAssetMenu(fileName = "CoinsData", menuName = "Data/CoinsData", order = 51)]
    public sealed class CoinsData : ScriptableObject
    {
        #region Fields

        [Space(20), Header("����������")] public CoinsComponents CoinsComponents;
        [Space(20), Header("�������������� ���������")] public CoinsSettingsData CoinsSettingsData;

        #endregion
    }
}