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
        public float HealPoints = 0;
        public GameObject Bullet;
        public AudioSource TouchItemSound;
        
        void OnCollisionEnter(Collision collision)
        {
            Character character = GetParentCharacterGameObject(collision.gameObject);
            if (character.Type.Equals(CharacterType.PLAYER))
            {
                PlaySound();
                character.IncreaseSpeed(IncSpeed);
                character.IncreaseFireRate(IncFireRate);
                character.IncreaseAttackDamage(IncAttackDamage);    
                character.IncreaseMaxHp(IncMaxHp);
                character.Heal(HealPoints);
                var o = gameObject;
                o.transform.position = new Vector3(0, 1000, 0);
                Destroy(o, 5);
            }
        }

        private void PlaySound()
        {
            if (TouchItemSound != null)
            {
                TouchItemSound.Play();
            }

        }
    }
}