using System;
using Codigo.Scripts.Entity.character;
using Codigo.Scripts.Entity.player;
using UnityEngine;
using Random = System.Random;

namespace Codigo.Scripts.StageController
{
    public class Stage1: MonoBehaviour
    {
        private float RandomEnemyRespawnTimer = 0.0f;
        public float RandomEnemyRespawnMaxTimer = 0.0f;
        public GameObject Player;
        public GameObject PFRandomEnemy1;
        public GameObject PFRandomEnemy2;

        private void Start()
        {
            CreatePlayer();
        }

        private void CreatePlayer()
        {
            Vector3 playerPos = new Vector3(GameSettings.SCREEN_LIMIT_X[0] - 1.0f, 0.0f, 0.0f);
            Instantiate(Player, playerPos, transform.rotation);
        }

        private void Update()
        {
            RespawnEnemy1();
        }

        // ReSharper disable Unity.PerformanceAnalysis
        private void RespawnEnemy1()
        {
            if (RandomEnemyRespawnTimer <= 0)
            {
                GameObject enemy;
                int randomEnemy = GameHelper.GetRandomInt(1, 100);
                if (randomEnemy >= 35)
                {
                    enemy = PFRandomEnemy1;
                }
                else
                {
                    enemy = PFRandomEnemy2;
                }
                float posX = GameSettings.SCREEN_LIMIT_X[1] + 2.0f;
                float posY = GameHelper.GetRandomInt((int) Math.Round(GameSettings.SCREEN_LIMIT_Y[0]), (int) Math.Round(GameSettings.SCREEN_LIMIT_Y[1]));
                Instantiate(enemy, new Vector3(posX, posY, 0.0f), transform.rotation);
                RandomEnemyRespawnTimer = RandomEnemyRespawnMaxTimer;
            }
            RandomEnemyRespawnTimer -= Time.deltaTime;
        }
    }
}