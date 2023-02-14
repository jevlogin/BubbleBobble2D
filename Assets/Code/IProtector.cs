using UnityEngine;


namespace WORLDGAMEDEVELOPMENT
{
    public interface IProtector
    {
        void StartProtection(GameObject gameObject);
        void FinishProtection(GameObject gameObject);
    }
}