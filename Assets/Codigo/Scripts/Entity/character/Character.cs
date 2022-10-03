using System;
using Codigo.Scripts.Entity.enemy.stage1;
using Codigo.Scripts.Entity.player;
using UnityEngine;

namespace Codigo.Scripts.Entity.character
{
    public class Character: MonoBehaviour
    {
        public string Name;
        public float Speed;
        public int MaxHp;
        public int CurrentHp;
        public int HitDamage;
        public int AttackDamage;
        public CharacterType Type;

        public Transform Target;
        
        protected Vector3 Direction { get; set; }

        public Character(string name, float speed, int maxHp, int currentHp, int hitDamage, int attackDamage, CharacterType type)
        {
            Name = name;
            Speed = speed;
            MaxHp = maxHp;
            CurrentHp = currentHp;
            HitDamage = hitDamage;
            AttackDamage = attackDamage;
            Type = type;
        }
        
        void OnCollisionEnter(Collision collision)
        {
            if (Type.Equals(CharacterType.BULLET) && collision.gameObject.CompareTag("Enemy"))
            {
                // Character collidedCharacter = collision.gameObject.GetComponent<Character>();
                Destroy(collision.gameObject);
                Destroy(gameObject);
            } else if (Type.Equals(CharacterType.ENEMY) && collision.gameObject.CompareTag("Player"))
            {
                Destroy(gameObject);
            }
        }
        
    }
}