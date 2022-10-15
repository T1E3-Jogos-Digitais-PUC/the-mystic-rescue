using System;
using Codigo.Scripts.Entity.character;
using UnityEngine;

namespace Codigo.Scripts.Entity.bullet.player
{
    public class PlayerBulletMain: Character
    {
        public float LifeTime = 1.0f;
        
        void Update()
        {
            BulletMovement();
            SelfDestroy();
        }

        private void BulletMovement()
        {
            Direction = new Vector3(1, 0, 0);
            transform.position += Direction * (Speed * Time.deltaTime);
        }
        
        private void SelfDestroy()
        {
            Destroy(gameObject, LifeTime);
        }
    }
}