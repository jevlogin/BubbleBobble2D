namespace WORLDGAMEDEVELOPMENT
{
    internal class Controller : IInitialization, IExecute, IFixedExecute, ICleanup, ILateExecute
    {
        public void Initialize()
        {
        }

        public void Execute(float deltaTime)
        {
        }
       
        public void LateExecute()
        {
        }

        public void FixedExecute(float fixedDeltaTime)
        {
        }

        public void Cleanup()
        {
        }
    }
}