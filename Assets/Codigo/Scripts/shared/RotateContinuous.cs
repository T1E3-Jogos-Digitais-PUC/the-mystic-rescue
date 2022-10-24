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
            var x = X * Speed * Time.deltaTime;
            var y = Y * Speed * Time.deltaTime;
            var z = Z * Speed * Time.deltaTime;
            transform.Rotate(x, y, z);
        }
    }
}