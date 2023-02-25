using UnityEngine;


namespace WORLDGAMEDEVELOPMENT
{
    public sealed class ControlNode : Node
    {
        public bool IsActive;

        public ControlNode(Vector3 position, bool active) : base(position)
        {
            IsActive = active;
        }
    }
}