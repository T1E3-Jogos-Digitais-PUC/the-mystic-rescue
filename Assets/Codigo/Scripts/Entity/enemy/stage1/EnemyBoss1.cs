using System;
using Codigo.Scripts.Entity.character;
using UnityEngine;
using Random = System.Random;

namespace Codigo.Scripts.Entity.enemy.stage1
{
    public class EnemyBoss1: Character
    {
        private float Vertical = -1;
        private bool InInitialCutScene = true;

        private void Start()
        {
            IsInvencible = true;
        }

        void Update()
        {
            if (InInitialCutScene)
            {
                InitialCutScene();
            }
            else
            {
                EnemyMovement();
            }
        }
        private void InitialCutScene()
        {
            Direction = new Vector3(-1, 0, 0);
            transform.position += Direction * (3.5f * Time.deltaTime);
            if (transform.position.x <= GameSettings.SCREEN_LIMIT_X[1] - (GameSettings.SCREEN_LIMIT_X[1] / 3))
            {
                InInitialCutScene = false;
                IsInvencible = false;
            }
        }
        private void EnemyMovement()
        {
            if (transform.position.y < GameSettings.SCREEN_LIMIT_Y[0])
            {
                Vertical = 1;
            }
            if (transform.position.y > GameSettings.SCREEN_LIMIT_Y[1])
            {
                Vertical = -1;
            }
            Direction = new Vector3(-0, Vertical, 0);
            transform.position += Direction * (Speed * Time.deltaTime);
        }
    }
}