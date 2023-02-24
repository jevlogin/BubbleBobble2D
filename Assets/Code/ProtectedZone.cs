using System;
using System.Collections.Generic;
using UnityEngine;


namespace WORLDGAMEDEVELOPMENT
{
    public sealed class ProtectedZone : IInitialization, ICleanup
    {
        private readonly List<IProtector> _protectors;
        private readonly LevelObjectTrigger _view;

        public ProtectedZone(List<IProtector> protectors, LevelObjectTrigger levelObjectTrigger)
        {
            _protectors = protectors ?? throw new ArgumentNullException(nameof(protectors));
            _view = levelObjectTrigger ?? throw new ArgumentNullException(nameof(levelObjectTrigger));
        }

        private void CollisionTriggerExit(object sender, GameObject gameObject)
        {
            foreach (var protector in _protectors)
                protector.FinishProtection(gameObject);
        }

        private void CollisionTriggerEnter(object sender, GameObject gameObject)
        {
            foreach (var protector in _protectors)
                protector.StartProtection(gameObject);
        }

        public void Initialize()
        {
            _view.TriggerEnter += CollisionTriggerEnter;
            _view.TriggerExit += CollisionTriggerExit;
        }

        public void Cleanup()
        {
            _view.TriggerEnter -= CollisionTriggerEnter;
            _view.TriggerExit -= CollisionTriggerExit;
        }
    }
}