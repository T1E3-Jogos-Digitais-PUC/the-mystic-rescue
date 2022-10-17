using System;
using System.Collections.Generic;
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
            Character character = GetParentCharacterGameObject(collision.gameObject);
            if (character)
            {
                BulletCollisions(character);
                EnemyPlayerCollisions(character);
                DieWhenHpLowerZero();
                SelfDestroyBulletWhenLeftTheScreen();
            }
        }

        private void BulletCollisions(Character character)
        {
            // se bala do jogador, toca o inimigo
            if (Type.Equals(CharacterType.PLAYER_BULLET) && character.Type.Equals(CharacterType.ENEMY))
            {
                character.CurrentHp -= AttackDamage;
                Destroy(gameObject);
            }
            // se bala do jogador, toca um obstáculo
            if (Type.Equals(CharacterType.PLAYER_BULLET) && character.Type.Equals(CharacterType.OBSTACLE))
            {
                Destroy(gameObject);
            }
            // se bala do inimigo, toca o player
            if (Type.Equals(CharacterType.ENEMY_BULLET) && character.Type.Equals(CharacterType.PLAYER))
            {
                character.CurrentHp -= AttackDamage;
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
        
        private void SelfDestroyBulletWhenLeftTheScreen()
        {
            if (Type.Equals(CharacterType.PLAYER_BULLET) || Type.Equals(CharacterType.ENEMY_BULLET))
            {
                if (transform.position.x < GameSettings.SCREEN_LIMIT_X[0] - 1.0f
                    || transform.position.x > GameSettings.SCREEN_LIMIT_X[1] + 1.0f
                    || transform.position.y < GameSettings.SCREEN_LIMIT_Y[0] - 1.0f
                    || transform.position.y > GameSettings.SCREEN_LIMIT_X[1] + 1.0f)
                {
                    Destroy(gameObject);
                }
            }
        }

        public static Character GetParentCharacterGameObject(GameObject cGameObject)
        {
            if (cGameObject)
            {
                if (cGameObject.GetComponent<Character>())
                {
                    return cGameObject.GetComponent<Character>();
                }
                try
                {
                    return GetParentCharacterGameObject(cGameObject.transform.parent.gameObject);
                }
                catch (Exception e)
                {
                    Debug.Log(e.ToString());
                    return null;
                }
            }
            return null;
        }
        
        public static List<Character> GetChildrenCharacterGameObject(GameObject cGameObject)
        {
            List<Character> characters = new List<Character>();
            if (cGameObject)
            {
                foreach (Transform child in cGameObject.transform)
                {
                    if (child.GetComponent<Character>())
                    {
                        characters.Add(child.GetComponent<Character>());
                    }
                    else
                    {
                        characters.AddRange(GetChildrenCharacterGameObject(child.gameObject));
                    }
                }
            }
            return characters;
        }
    }
}