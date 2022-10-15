using System;
using Codigo.Scripts.Entity.character;
using UnityEngine;
using Random = System.Random;

namespace Codigo.Scripts.Entity.enemy.stage1
{
    public class EnemySnakePurple: Character
    {
        void Update()
        {
            EnemyMovement();
            SelfDestroy(30.0f);
        }
        
        private void EnemyMovement()
        {
            Direction = new Vector3(-1, 0, 0);
            transform.position += Direction * (Speed * Time.deltaTime);
        }
        
        private void SelfDestroy(float time)
        {
            Destroy(gameObject, time);
        }
    }
}