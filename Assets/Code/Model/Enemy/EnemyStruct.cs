using System;


namespace WORLDGAMEDEVELOPMENT
{
    [Serializable]
    public struct EnemyStruct
    {
        public EnemyView Prefab;
        public int Speed;
        public int MaxHp;
        public int CurrentHp;
    }
}