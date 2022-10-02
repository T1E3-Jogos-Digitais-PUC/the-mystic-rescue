using System;
using Codigo.Scripts.Entity.character;
using UnityEngine;

namespace Codigo.Scripts.Entity.bullet.player
{
    public class PlayerBulletNormal: Character
    {
        public float LifeTime = 1.0f;
        public PlayerBulletNormal() : base("BulletNormal", 75.0f, 1, 1, 0, 20, CharacterType.BULLET)
        {
            
        }

        private void Start()
        {
            AttackDamage = 20;
        }

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