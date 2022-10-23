using System;
using Codigo.Scripts.Entity.character;
using Unity.VisualScripting;
using UnityEngine;
using Random = System.Random;

namespace Codigo.Scripts.Entity.enemy.stage1
{
    public class EnemySnakeYellow: Character
    {
        private void Start()
        {
            if (transform.position.y > 0)
            {
                transform.Rotate(transform.rotation.x, transform.rotation.y, 45);
            }
            else
            {
                transform.Rotate(transform.rotation.x, transform.rotation.y, -45);
            }
            Direction = new Vector3(-1, 0, 0);
        }
        
        private void Update()
        {
            EnemyMovement();
            SelfDestroy(30.0f);
        }
        
        private void EnemyMovement()
        {
            transform.position += Direction * (Speed * Time.deltaTime);
        }
        
        private void SelfDestroy(float time)
        {
            Destroy(gameObject, time);
        }
    }
}