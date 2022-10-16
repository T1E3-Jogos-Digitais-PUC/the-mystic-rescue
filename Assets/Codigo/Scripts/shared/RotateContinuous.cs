using System;
using UnityEngine;

namespace Codigo.Scripts.shared
{
    public class RotateContinuous: MonoBehaviour
    {
        public float X = 0;
        public float Y = 0;
        public float Z = 0;
        public float Speed = 1.0f;

        private void Update()
        {
            var dt = (Speed * Time.deltaTime);
            transform.Rotate(X * dt, Y * dt, Z + dt);
        }
    }
}