using Codigo.Scripts.Entity.character;
using UnityEngine;

namespace Codigo.Scripts.Entity.bullet.enemy
{
    public class EnemyBulletDiagonal: Character
    {
        private void Start()
        {
            if (transform.position.y >= 0)
            {
                Direction = new Vector3(-1, -1, 0);
            }
            else
            {
                Direction = new Vector3(-1, 1, 0);
            }
        }
        
        void Update()
        {
            BulletMovement();
        }
        
        private void BulletMovement()
        {
            transform.position += Direction * (Speed * Time.deltaTime);
        }
    }
}