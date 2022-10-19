using UnityEngine;

namespace Codigo.Scripts.shared
{
    public class SelfDestructionTimer: MonoBehaviour
    {
        public float SelfDestruccionTime = 0;
        private void Start()
        {
            if (SelfDestruccionTime > 0)
            {
                Destroy(gameObject, SelfDestruccionTime);
            }
        }
    }
}