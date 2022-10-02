using System;
using UnityEngine;
using Random = System.Random;

namespace Codigo.Scripts.stage
{
    public class Stage1: MonoBehaviour
    {
        public float RandomEnemyRespawnTimer = 0.0f;
        public GameObject PFRandomEnemy1;
        private void Update()
        {
            RespawnEnemy1();
        }

        // ReSharper disable Unity.PerformanceAnalysis
        private void RespawnEnemy1()
        {
            if (RandomEnemyRespawnTimer <= 0)
            {
                Random random = new Random();
                float posX = GameSettings.SCREEN_LIMIT_X[1] + 2.0f;
                double posY = random.NextDouble() * (GameSettings.SCREEN_LIMIT_Y[1] * GameSettings.SCREEN_LIMIT_Y[0]) +
                              GameSettings.SCREEN_LIMIT_Y[0];
                Instantiate(PFRandomEnemy1, new Vector3(posX, (float) posY, 0.0f), transform.rotation);
                RandomEnemyRespawnTimer = 1.0f;
            }

            RandomEnemyRespawnTimer -= Time.deltaTime;
        }
    }
}