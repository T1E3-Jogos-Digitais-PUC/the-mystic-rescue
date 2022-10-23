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
        }
        
        private void EnemyMovement()
        {
            Direction = new Vector3(-1, 0, 0);
            transform.position += Direction * (Speed * Time.deltaTime);
        }
    }
}