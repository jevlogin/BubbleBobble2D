using Pathfinding;
using System;


namespace WORLDGAMEDEVELOPMENT
{
    public sealed class AIPatrolPath : AIPath
    {
        public new event EventHandler TargetReached;

        public override void OnTargetReached()
        {
            base.OnTargetReached();
            DispathcTargetReached();
            //Debug.Log($"ѕроверка OnTargetReached in {name}");
            //≈му станет доступен метод OnTargetReached,
            //вызов которого происходит тогда, когда достигаетс€ очередна€ точка пути.
        }

        private void DispathcTargetReached()
        {
            TargetReached?.Invoke(this, EventArgs.Empty);
        }
    }
}