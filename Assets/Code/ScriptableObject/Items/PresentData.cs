using UnityEngine;


namespace WORLDGAMEDEVELOPMENT
{
    [CreateAssetMenu(fileName = "PresentData", menuName = "Data/PresentData", order = 51)]
    public sealed class PresentData : ScriptableObject
    {
        public PresentStruct PresentStruct;
        public PresentComponents PresentComponents;
        //public PresentSettings PresentSettings;
    }
}