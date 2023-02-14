using System;
using UnityEngine;


namespace WORLDGAMEDEVELOPMENT
{
    public sealed class LevelObjectTrigger : MonoBehaviour
    {
        public event EventHandler<GameObject> TriggerEnter;
        public event EventHandler<GameObject> TriggerExit;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            TriggerEnter?.Invoke(this, collision.gameObject);
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            TriggerExit?.Invoke(this, collision.gameObject);
        }
    }
}