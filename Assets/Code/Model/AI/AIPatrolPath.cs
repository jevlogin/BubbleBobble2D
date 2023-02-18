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
            //Debug.Log($"�������� OnTargetReached in {name}");
            //��� ������ �������� ����� OnTargetReached,
            //����� �������� ���������� �����, ����� ����������� ��������� ����� ����.
        }

        private void DispathcTargetReached()
        {
            TargetReached?.Invoke(this, EventArgs.Empty);
        }
    }
}