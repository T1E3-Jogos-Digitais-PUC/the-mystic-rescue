using System;
using UnityEngine;

namespace Codigo.Scripts.shared
{
    public class SelfDestroy: MonoBehaviour
    {
        public bool OutOfScreen = false;
        public bool OutOfScreenAxisX = false;
        public float BySeconds = 0;

        private void Start()
        {
            if (BySeconds > 0)
            {
                Destroy(gameObject, BySeconds);
            }
        }

        private void Update()
        {
            if (OutOfScreen)
            {
                if (transform.position.x < GameSettings.SCREEN_LIMIT_X[0] - 1.0f
                    || transform.position.x > GameSettings.SCREEN_LIMIT_X[1] + 1.0f
                    || transform.position.y < GameSettings.SCREEN_LIMIT_Y[0] - 1.0f
                    || transform.position.y > GameSettings.SCREEN_LIMIT_X[1] + 1.0f)
                {
                    Destroy(gameObject);
                }
            } else if (OutOfScreenAxisX)
            {
                if (transform.position.x < GameSettings.SCREEN_LIMIT_X[0] - 1.0f)
                {
                    Destroy(gameObject);
                }   
            }
        }
    }
}