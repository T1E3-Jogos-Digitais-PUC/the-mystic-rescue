using System;
using Codigo.Scripts.Entity.character;
using UnityEngine;

namespace Codigo.Scripts.Entity.bullet.enemy
{
    public class EnemyBulletMissile: Character
    {
        public float Acceleration = 0.01f;
        private void Start()
        {
            Direction = new Vector3(-1, 0, 0);
        }
        void Update()
        {
            BulletMovement();
        }

        private void BulletMovement()
        {
            transform.position += Direction * (Speed * Time.deltaTime);
            Speed += Acceleration;
        }
    }
}