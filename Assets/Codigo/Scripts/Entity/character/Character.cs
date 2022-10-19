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
        public GameObject Explosion;
        public GameObject ItemDrop;
        public int ItemDropChance;
        public bool IsInvencible = false;
        protected Vector3 Direction { get; set; }

        private void Start()
        {
            IsInvencible = false;
        }

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
                character.ReceiveDamage(AttackDamage);
                Destroy(gameObject);
                if (Explosion != null)
                {
                    GameObject instantiatedExplosion = Instantiate(Explosion, transform.position, transform.rotation);
                    Destroy(instantiatedExplosion, 0.5f);
                }
            }
            // se bala do jogador, toca um obstáculo
            if (Type.Equals(CharacterType.PLAYER_BULLET) && character.Type.Equals(CharacterType.OBSTACLE))
            {
                Destroy(gameObject);
            }
            // se bala do inimigo, toca o player
            if (Type.Equals(CharacterType.ENEMY_BULLET) && character.Type.Equals(CharacterType.PLAYER))
            {
                character.ReceiveDamage(AttackDamage);
                Destroy(gameObject);
            }
        }

        private void EnemyPlayerCollisions(Character character)
        {
            if (Type.Equals(CharacterType.ENEMY) && character.Type.Equals(CharacterType.PLAYER))
            {
                character.ReceiveDamage(HitDamage);
                ReceiveDamage(character.HitDamage);
            }
        }
        
        private void DieWhenHpLowerZero()
        {
            if (CurrentHp <= 0 && !Type.Equals(CharacterType.PLAYER))
            {
                if (Type.Equals(CharacterType.ENEMY))
                {
                    if (ItemDrop != null)
                    {
                        int per = GameHelper.GetRandomInt(1, 100);
                        if (per <= ItemDropChance)
                        {
                            var y = GameSettings.SCREEN_LIMIT_Y[1];
                            Instantiate(ItemDrop, new Vector3(transform.position.x + 2.0f, y, transform.position.z), transform.rotation);
                        }
                    }
                }
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
        
        public void ReceiveDamage(float damage)
        {
            if(IsInvencible == false)
            {
                CurrentHp -= damage;
            }
        }
        
        public void Heal(float heal)
        {
            if(heal + CurrentHp > MaxHp)
            {
                CurrentHp = MaxHp;
            }
            else
            {
                CurrentHp += heal;
            }
        }
        
        public void IncreaseSpeed(float speed)
        {
            Speed += speed;
        }
        
        public void IncreaseFireRate(float fireRate)
        {
            FireRate += fireRate;
        }
        
        public void IncreaseAttackDamage(float attackDamage)
        {
            AttackDamage += attackDamage;
        }
        
        public void IncreaseHitDamage(float hitDamage)
        {
            HitDamage += hitDamage;
        }
        
        public void IncreaseMaxHp(float maxHp)
        {
            MaxHp += maxHp;
            Heal(maxHp);
        }
    }
}