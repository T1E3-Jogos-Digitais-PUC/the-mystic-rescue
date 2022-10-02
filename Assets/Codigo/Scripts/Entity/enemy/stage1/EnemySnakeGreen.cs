using System;
using Codigo.Scripts.Entity.character;
using UnityEngine;
using Random = System.Random;

namespace Codigo.Scripts.Entity.enemy.stage1
{
    public class EnemySnakeGreen: Character
    {
        public float FireRate = 2.5f;
        public EnemySnakeGreen() : base("Green-Snake", 1.0f, 10, 10, 5, 2, CharacterType.ENEMY)
        {
            
        }
        
        void Update()
        {
            EnemyMovement();
            SelfDestroy(4.0f);
        }
        
        private void EnemyMovement()
        {
            float vertical = -1;
            if (transform.position.y < GameSettings.SCREEN_LIMIT_Y[1])
            {
                vertical = 1;
            }
            
            Direction = new Vector3(-1, vertical, 0);
            transform.position += Direction * (Speed * Time.deltaTime);
        }
        
        private void SelfDestroy(float time)
        {
            Destroy(gameObject, time);
        }
    }
}