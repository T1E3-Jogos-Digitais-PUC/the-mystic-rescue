using System;
using Codigo.Scripts.Entity.character;
using UnityEngine;

namespace Codigo.Scripts.shared
{
    public class MovementContinuous: MonoBehaviour
    {
        public float X = 0;
        public float Y = 0;
        public float Z = 0;
        public float Speed = 1;
        private Vector3 Direction;
        private void Start()
        {
            Direction = new Vector3(X, Y, Z);
        }

        private void Update()
        {
            transform.position += Direction * (Speed * Time.deltaTime);
        }
    }
}