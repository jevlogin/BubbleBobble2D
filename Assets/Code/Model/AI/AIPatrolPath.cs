using Pathfinding;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace WORLDGAMEDEVELOPMENT
{
    public sealed class AIPatrolPath : AIPath
    {
        public new event EventHandler TargetReached;

        public override void OnTargetReached()
        {
            base.OnTargetReached();
            DispathcTargetReached();
        }

        private void DispathcTargetReached()
        {
            TargetReached?.Invoke(this, EventArgs.Empty);
        }
    }
}