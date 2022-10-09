using System;
using Codigo.Scripts.Entity.enemy.stage1;
using Codigo.Scripts.Entity.player;
using UnityEngine;

namespace Codigo.Scripts.Entity.character
{
    public class Character: MonoBehaviour
    {
        public float Speed;
        public float MaxHp;
        public float CurrentHp;
        public float HitDamage;
        public float AttackDamage;
        public float FireRate;
        public CharacterType Type;

        protected Vector3 Direction { get; set; }

        void OnCollisionEnter(Collision collision)
        {
            Character character = GetCharacterGameObject(collision.gameObject);
            if (character)
            {
                BulletCollisions(character);
                EnemyPlayerCollisions(character);
                DieWhenHpLowerZero();
            }
        }

        private void BulletCollisions(Character character)
        {
            // se bala do jogador, toca o inimigo ou a bala do inimigo toca o jogador
            if (Type.Equals(CharacterType.PLAYER_BULLET) && character.Type.Equals(CharacterType.ENEMY))
            {
                Debug.Log(AttackDamage);
                character.CurrentHp -= AttackDamage;
                Destroy(gameObject);
            }
            // se bala do jogador, toca um obstáculo
            if (Type.Equals(CharacterType.PLAYER_BULLET) && character.Type.Equals(CharacterType.OBSTACLE))
            {
                Destroy(gameObject);
            }
        }

        private void EnemyPlayerCollisions(Character character)
        {
            if (Type.Equals(CharacterType.ENEMY) && character.Type.Equals(CharacterType.PLAYER))
            {
                character.CurrentHp -= HitDamage;
                CurrentHp -= character.HitDamage;
            }
        }
        
        private void DieWhenHpLowerZero()
        {
            if (CurrentHp <= 0 && !Type.Equals(CharacterType.PLAYER))
            {
                Destroy(gameObject);
            }
        }

        public static Character GetCharacterGameObject(GameObject cGameObject)
        {
            if (cGameObject)
            {
                if (cGameObject.GetComponent<Character>())
                {
                    return cGameObject.GetComponent<Character>();
                }
                try
                {
                    return GetCharacterGameObject(cGameObject.transform.parent.gameObject);
                }
                catch (Exception e)
                {
                    Debug.Log(e.ToString());
                    return null;
                }
            }

            return null;
        }
    }
}