using System;
using Codigo.Scripts.Entity.character;
using UnityEngine;

namespace Codigo.Scripts.Entity.player
{
    public class PlayerGun: MonoBehaviour
    {
        // public KeyCode Key;
        public GameObject Prefab;
        public AudioSource FireSound;
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
                if (Input.GetButton("Fire1") && NextFire <= 0.0f && ParentCharacter)
                {
                    GameObject instantiatedBullet = Instantiate(Prefab, transform.position, transform.rotation);
                    // ReSharper disable once Unity.PerformanceCriticalCodeInvocation
                    Character bullet = instantiatedBullet.GetComponent<Character>();
                    bullet.AttackDamage *= ParentCharacter.AttackDamage;
                    NextFire = ParentCharacter.FireRate;
                    if (FireSound)
                    {
                        FireSound.Play();
                    }
                }
                NextFire -= Time.deltaTime;
            }
        }
        
    }
}