using Codigo.Scripts.Entity.character;
using UnityEngine;

namespace Codigo.Scripts.Entity.enemy.stage1
{
    public class EnemySnakeGreen: Character
    {
        private float Vertical = -1;
        void Update()
        {
            EnemyMovement();
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
    }
}