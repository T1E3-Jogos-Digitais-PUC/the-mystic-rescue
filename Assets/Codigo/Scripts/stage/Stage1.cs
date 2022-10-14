using System;
using UnityEngine;
using Random = System.Random;

namespace Codigo.Scripts.stage
{
    public class Stage1: MonoBehaviour
    {
        private float RandomEnemyRespawnTimer = 0.0f;
        public float RandomEnemyRespawnMaxTimer = 0.0f;
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
                float posY = random.Next(minValue: (int)Math.Round(GameSettings.SCREEN_LIMIT_Y[0]), (int)Math.Round(GameSettings.SCREEN_LIMIT_Y[1]));
                Instantiate(PFRandomEnemy1, new Vector3(posX, posY, 0.0f), transform.rotation);
                RandomEnemyRespawnTimer = RandomEnemyRespawnMaxTimer;
            }

            RandomEnemyRespawnTimer -= Time.deltaTime;
        }
    }
}