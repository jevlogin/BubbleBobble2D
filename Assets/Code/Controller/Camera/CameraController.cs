using UnityEngine;


namespace WORLDGAMEDEVELOPMENT
{
    internal class CameraController : ILateExecute
    {
        #region Fields
        
        private Camera _camera;
        private Transform _transformPlayer;
        private Vector3 _offset;
        private Vector3 _desiredPosition;
        private Vector3 _smooth;

        #endregion


        #region ClassLifeCycles
        
        public CameraController(Camera camera, Transform transformPlayer)
        {
            _camera = camera;
            _transformPlayer = transformPlayer;
            _offset = _camera.transform.position - _transformPlayer.position;
        }

        #endregion



        #region ILateExecute

        public void LateExecute(float fixedDeltaTime)
        {
            _desiredPosition = _transformPlayer.position + _offset;
            _smooth = Vector3.Lerp(_camera.transform.position, _desiredPosition, fixedDeltaTime);
            _camera.transform.position = _smooth;
        } 

        #endregion
    }
}