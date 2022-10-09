using System;
using Codigo.Scripts.Entity.character;
using UnityEngine;
using Random = System.Random;

namespace Codigo.Scripts.Entity.enemy.stage1
{
    public class EnemySnakeGreen: Character
    {
        private float Vertical = -1;
        void Update()
        {
            EnemyMovement();
            SelfDestroy(20.0f);
        }
        
        private void EnemyMovement()
        {
            
            if (transform.position.y < GameSettings.SCREEN_LIMIT_Y[0])
            {
                Vertical = 1;
            }
            if (transform.position.y > GameSettings.SCREEN_LIMIT_Y[1])
            {
                Vertical = -1;
            }
            
            Direction = new Vector3(-1, Vertical, 0);
            transform.position += Direction * (Speed * Time.deltaTime);
        }
        
        private void SelfDestroy(float time)
        {
            Destroy(gameObject, time);
        }
    }
}