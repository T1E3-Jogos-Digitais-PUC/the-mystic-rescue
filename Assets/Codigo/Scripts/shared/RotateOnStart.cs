using UnityEngine;

namespace Codigo.Scripts.shared
{
    public class RotateOnStart: MonoBehaviour
    {
        public float MinX = 0f;
        public float MaxX = 0f;
        public float MinY = 0f;
        public float MaxY = 0f;
        public float MinZ = 0f;
        public float MaxZ = 0f;

        private void Start()
        {
            transform.Rotate(GameHelper.GetRandomFloat(MinX, MaxX),GameHelper.GetRandomFloat(MinY, MaxY),GameHelper.GetRandomFloat(MinZ, MaxZ));
        }
    }
}