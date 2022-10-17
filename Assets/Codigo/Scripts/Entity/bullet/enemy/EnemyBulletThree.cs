using System;
using Codigo.Scripts.Entity.character;
using UnityEngine;
using Random = System.Random;

namespace Codigo.Scripts.Entity.bullet.enemy
{
    public class EnemyBulletThree: Character
    {
        public float BulletDir = 1.0f;
        void Update()
        {
            BulletMovement();
        }
        private void BulletMovement()
        {
            Direction = new Vector3(-1, BulletDir, 0);
            transform.position += Direction * (Speed * Time.deltaTime);
        }
    }
}