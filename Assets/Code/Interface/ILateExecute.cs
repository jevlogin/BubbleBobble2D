namespace WORLDGAMEDEVELOPMENT
{
    public interface ILateExecute : IController
    {
        void LateExecute(float fixedDeltaTime);
    }
}