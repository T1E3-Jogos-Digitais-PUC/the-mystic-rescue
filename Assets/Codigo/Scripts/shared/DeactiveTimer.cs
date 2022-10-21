using UnityEngine;

namespace Codigo.Scripts.shared
{
    public class DeactiveTimer: MonoBehaviour
    {
        
        public float time = 1f;
        public float rotateResetX = 0f;
        public float rotateResetY = 0f;
        public float rotateResetZ = 0f;
        private float timer = 0f;
        private bool isTimer = false;
        private void Update()
        {
            if (!isTimer)
            {
                StartTimer();
            }
            if (isTimer)
            {
                timer += Time.deltaTime;
                if (timer >= time)
                {
                    timer = 0f;
                    isTimer = false;
                    gameObject.transform.Rotate(rotateResetX, rotateResetY, rotateResetZ);
                    gameObject.SetActive(false);
                }
            }
        }
        private void StartTimer()
        {
            timer = 0f;
            gameObject.SetActive(true);
            isTimer = true;
        }
        
    }
}