using System.Collections.Generic;


namespace WORLDGAMEDEVELOPMENT
{
    public sealed class Controllers : IInitialization, IExecute, IFixedExecute, ICleanup, ILateExecute, IAwake
    {

        #region Fields

        private readonly List<IInitialization> _initializeControllers;
        private readonly List<IExecute> _executeControllers;
        private readonly List<ILateExecute> _lateControllers;
        private readonly List<IFixedExecute> _fixedControllers;
        private readonly List<ICleanup> _cleanupControllers;
        private readonly List<IAwake> _awakeControllers;

        #endregion


        #region ClassLifeCycles

        public Controllers()
        {
            _initializeControllers = new List<IInitialization>();
            _executeControllers = new List<IExecute>();
            _lateControllers = new List<ILateExecute>();
            _fixedControllers = new List<IFixedExecute>();
            _cleanupControllers = new List<ICleanup>();
            _awakeControllers = new List<IAwake>();
        }

        #endregion


        public Controllers Add(IController controller)
        {
            if (controller is IInitialization initialization)
            {
                _initializeControllers.Add(initialization);
            }
            if (controller is IFixedExecute fixedExecute)
            {
                _fixedControllers.Add(fixedExecute);
            }
            if (controller is IExecute execute)
            {
                _executeControllers.Add(execute);
            }
            if (controller is ICleanup cleanup)
            {
                _cleanupControllers.Add(cleanup);
            }
            if (controller is ILateExecute lateExecute)
            {
                _lateControllers.Add(lateExecute);
            }
            if (controller is IAwake awake)
            {
                _awakeControllers.Add(awake);
            }
            return this;
        }



        public void Initialize()
        {
            for (int index = 0; index < _initializeControllers.Count; index++)
            {
                _initializeControllers[index].Initialize();
            }
        }

        public void Execute(float deltaTime)
        {
            for (int index = 0; index < _executeControllers.Count; index++)
            {
                _executeControllers[index].Execute(deltaTime);
            }
        }
       
        public void LateExecute(float fixedDeltaTime)
        {
            for (int index = 0; index < _lateControllers.Count; index++)
            {
                _lateControllers[index].LateExecute(fixedDeltaTime);
            }
        }

        public void FixedExecute(float fixedDeltaTime)
        {
            for (int index = 0; index < _fixedControllers.Count; index++)
            {
                _fixedControllers[index].FixedExecute(fixedDeltaTime);
            }
        }

        public void Cleanup()
        {
            for (int index = 0; index < _cleanupControllers.Count; index++)
            {
                _cleanupControllers[index].Cleanup();
            }
        }

        public void Awake()
        {
            for (int index = 0; index < _awakeControllers.Count; index++)
            {
                _awakeControllers[index].Awake();
            }
        }
    }
}