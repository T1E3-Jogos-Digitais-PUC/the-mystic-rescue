using Codigo.Scripts.Entity.character;
using UnityEngine;

namespace Codigo.Scripts.Entity.player
{
    public class PowerUp : Character
    {
        public float IncSpeed = 0;
        public float IncFireRate = 0;
        public float IncAttackDamage = 0;
        public float IncMaxHp = 0;
        public float Heal = 0;
        public GameObject Bullet;
        
        void OnCollisionEnter(Collision collision)
        {
            Character character = GetParentCharacterGameObject(collision.gameObject);
            if (character.Type.Equals(CharacterType.PLAYER))
            {
                character.IncreaseSpeed(IncSpeed);
                character.IncreaseFireRate(IncFireRate);
                character.IncreaseAttackDamage(IncAttackDamage);    
                character.IncreaseMaxHp(IncMaxHp);
                character.Heal(Heal);
                Destroy(gameObject);
            }
        }
        
    }
}