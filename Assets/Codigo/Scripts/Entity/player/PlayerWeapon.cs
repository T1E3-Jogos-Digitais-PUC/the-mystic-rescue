using System;
using Codigo.Scripts.Entity.character;
using UnityEngine;

namespace Codigo.Scripts.Entity.player
{
    public class PlayerWeapon: MonoBehaviour
    {
        // public KeyCode Key;
        public GameObject Prefab;
        public GameObject Particles;
        public AudioSource FireSound;
        private Player ParentCharacter;
        private float NextFire;

        private void Start()
        {
            var character = Character.GetParentCharacterGameObject(gameObject);
            ParentCharacter = character.GetComponent<Player>();
            NextFire = 0.0f;
        }

        void Update()
        {
            if (ParentCharacter && ParentCharacter.CanInput)
            {
                if (Input.GetButton("Fire1") && NextFire <= 0.0f)
                {
                    if (Particles)
                    {
                        Instantiate(Particles, transform.position, transform.rotation);
                    }
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