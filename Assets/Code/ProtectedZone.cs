using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace WORLDGAMEDEVELOPMENT
{
    public sealed class ProtectedZone
    {
        private readonly List<IProtector> _protectors;
        private readonly LevelObjectTrigger _view;

        public ProtectedZone(List<IProtector> protectors, LevelObjectTrigger levelObjectTrigger)
        {
            _protectors = protectors ?? throw new ArgumentNullException(nameof(protectors));
            _view = levelObjectTrigger ?? throw new ArgumentNullException(nameof(levelObjectTrigger));
        }

        public void Init()
        {
            _view.TriggerEnter += _view_TriggerEnter;
            _view.TriggerExit += _view_TriggerExit;
        }

        public void DeInit()
        {
            _view.TriggerEnter -= _view_TriggerEnter;
            _view.TriggerExit -= _view_TriggerExit;
        }

        private void _view_TriggerExit(object sender, GameObject gameObject)
        {
            foreach (var protector in _protectors)
            {
                protector.FinishProtection(gameObject);
            }
        }

        private void _view_TriggerEnter(object sender, GameObject gameObject)
        {
            foreach (var protector in _protectors)
            {
                protector.StartProtection(gameObject);
            }
        }
    }
}