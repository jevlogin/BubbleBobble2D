using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace WORLDGAMEDEVELOPMENT
{
    public sealed class ContactsPoller : IExecute
    {
        private ContactPoint2D[] _contactPoint = new ContactPoint2D[10];

        private const float _collisionTresh = 0.6f;
        private int _contactCount = 0;
        private readonly Collider2D _collider2D;

        public bool IsGrounded { get; private set; }
        public bool HasLeftContact { get; private set; }
        public bool HasRightContact { get; private set; }

        public ContactsPoller(Collider2D collider)
        {
            _collider2D = collider;
        }


        #region IExecute

        public void Execute(float deltaTime)
        {
            ResetBool();
            _contactCount = _collider2D.GetContacts(_contactPoint);

            for (int i = 0; i < _contactCount; i++)
            {
                var normal = _contactPoint[i].normal;
                var rigidBody = _contactPoint[i].rigidbody;

                if (normal.y > _collisionTresh) IsGrounded = true;

                if (normal.x > _collisionTresh) HasLeftContact = true;

                if (normal.x < -_collisionTresh) HasRightContact = true;
                
            }
        }

        #endregion


        #region Methods

        private void ResetBool()
        {
            IsGrounded = false;
            HasLeftContact = false;
            HasRightContact = false;
        }

        #endregion
    }
}