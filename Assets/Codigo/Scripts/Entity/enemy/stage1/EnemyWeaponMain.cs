using System;
using System.Collections.Generic;
using Codigo.Scripts.Entity.character;
using UnityEngine;

namespace Codigo.Scripts.Entity.enemy.stage1
{
    public class EnemyWeaponMain: MonoBehaviour
    {
        public bool Loop = false;
        public float DelayToFirstShot = 0.0f;
        public GameObject Prefab;
        private Character ParentCharacter;
        private float NextFire;
        private bool CanShot;

        private void Start()
        {
            ParentCharacter = Character.GetParentCharacterGameObject(gameObject);
            NextFire = DelayToFirstShot;
            CanShot = true;
        }

        void Update()
        {
            if (ParentCharacter && CanShot)
            {
                if (NextFire <= 0.0f)
                {
                    GameObject instantiatedBullet = Instantiate(Prefab, transform.position, transform.rotation);
                    List<Character> childrenBullets = Character.GetChildrenCharacterGameObject(instantiatedBullet);
                    foreach (var childrenBullet in childrenBullets)
                    {
                        childrenBullet.AttackDamage *= ParentCharacter.AttackDamage;
                    }
                    NextFire = ParentCharacter.FireRate;
                    if (!Loop)
                    {
                        CanShot = false;
                    }
                }
                NextFire -= Time.deltaTime;
            }
        }
        
    }
}