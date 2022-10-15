using System;
using Codigo.Scripts.Entity.character;
using UnityEngine;

namespace Codigo.Scripts.Entity.enemy.stage1
{
    public class EnemyWeaponMain: MonoBehaviour
    {
        // public KeyCode Key;
        public GameObject Prefab;
        private Character ParentCharacter;
        private float NextFire;

        private void Start()
        {
            ParentCharacter = Character.GetCharacterGameObject(gameObject);
            NextFire = 0.0f;
        }

        void Update()
        {
            if (ParentCharacter)
            {
                if (NextFire <= 0.0f && ParentCharacter)
                {
                    GameObject instantiatedBullet = Instantiate(Prefab, transform.position, transform.rotation);
                    // ReSharper disable once Unity.PerformanceCriticalCodeInvocation
                    Character bullet = instantiatedBullet.GetComponent<Character>();
                    bullet.AttackDamage *= ParentCharacter.AttackDamage;
                    NextFire = ParentCharacter.FireRate;
                }
                NextFire -= Time.deltaTime;
            }
        }
        
    }
}