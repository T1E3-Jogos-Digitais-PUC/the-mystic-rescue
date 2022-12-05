using Codigo.Scripts.Entity.enemy.stage1;
using UnityEngine;

namespace Codigo.Scripts.StageController
{
    public class Stage2: MonoBehaviour
    {
        private float CurrentTimeInSeconds = 0.0f;
        private int CurrentWave = 1;
        public GameObject PFEnemy1;
        public GameObject PFEnemy2;
        public GameObject PFEnemy3;
        public GameObject PFObstacle;
        public AudioSource BGSong;
        public AudioSource BGBossSong;

        private void Start()
        {
            Time.timeScale = 1f;
            if (BGSong)
            {
                BGSong.Play();
            }
        }
        
        private void Update()
        {
            CurrentTimeInSeconds += Time.deltaTime;
            SpawnFirstWave(); //2.5seg
            SpawnSecondWave(); //6seg
            SpawnThirdWave(); //11seg
            SpawnFourthWave(); //15seg
            SpawnFifthWave(); //20seg
            SpawnSixthWave(); //26seg
            SpawnSeventhWave(); //30seg
            SpawnEighthWave(); //37seg
            SpawnNinethWave(); //43seg
            SpawnTenthWave(); //50seg
            StartBoss(); //60seg
        }


        private void CreateObstacles()
        {
            GenerateObstacle(4f, -5f);
            GenerateObstacle(GameHelper.GetRandomFloat(GameSettings.SCREEN_LIMIT_X[1] + 4f, 200f), GameHelper.GetRandomFloat(-5.5f, -5f));

        }

        private void SpawnFirstWave()
        {
            if (CurrentTimeInSeconds >= 2.5f && CurrentWave == 1)
            {
                CurrentTimeInSeconds = 0.0f;
                CurrentWave++;
                GenerateEnemy1(3f, -4.9f);
                GenerateEnemy1(1f, 3.2f);
            }
        }
        
        private void SpawnSecondWave()
        {
            if (CurrentTimeInSeconds >= 3.5f && CurrentWave == 2)
            {
                CurrentTimeInSeconds = 0.0f;
                CurrentWave++;
                GenerateEnemy2(1f, 1f);
                GenerateEnemy2(3f, -2f);
            }
        }
        
        private void SpawnThirdWave()
        {
            if (CurrentTimeInSeconds >= 5f && CurrentWave == 3)
            {
                CurrentTimeInSeconds = 0.0f;
                CurrentWave++;
                GenerateEnemy1(1f, -2f);
                GenerateEnemy1(1f, 2f);
                GenerateEnemy2(3f, 0f);
            }
        }
        
        private void SpawnFourthWave()
        {
            if (CurrentTimeInSeconds >= 4f && CurrentWave == 4)
            {
                CurrentTimeInSeconds = 0.0f;
                CurrentWave++;
                GenerateEnemy1(3f, 4.2f);
                GenerateEnemy3(6f, -5.2f);
                GenerateEnemy3(8f, -5.2f);
            }
        }
        
        private void SpawnFifthWave()
        {
            if (CurrentTimeInSeconds >= 5f && CurrentWave == 5)
            {
                CurrentTimeInSeconds = 0.0f;
                CurrentWave++;
                GenerateEnemy2(1f, 0f);
                GenerateEnemy3(5f, 5.2f);
                GenerateEnemy3(7f, 5.2f);
            }
        }
        
        private void SpawnSixthWave()
        {
            if (CurrentTimeInSeconds >= 6f && CurrentWave == 6)
            {
                CurrentTimeInSeconds = 0.0f;
                CurrentWave++;
                GenerateEnemy1(1f, 0f);
                GenerateEnemy1(3f, 0.5f);
                GenerateEnemy1(5f, 1f);
                GenerateEnemy1(7f, 1.5f);
            }
        }

        private void SpawnSeventhWave()
        {
            if (CurrentTimeInSeconds >= 4f && CurrentWave == 7)
            {
                CurrentTimeInSeconds = 0.0f;
                CurrentWave++;
                GenerateEnemy2(4f, -1f);
                GenerateEnemy2(4f, 2f); 
                GenerateEnemy3(6f, -5.7f);
                GenerateEnemy3(8f, -5.7f);  
                GenerateEnemy3(6f, 5.7f);
                GenerateEnemy3(8f, 5.7f); 
            }
        }
        
        private void SpawnEighthWave()
        {
            if (CurrentTimeInSeconds >= 5f && CurrentWave == 8)
            {
                CurrentTimeInSeconds = 0.0f;
                CurrentWave++;
                GenerateEnemy1(3f, 0f);
            }
        }
        
        private void SpawnNinethWave()
        {
            if (CurrentTimeInSeconds >= 6f && CurrentWave == 9)
            {
                CurrentTimeInSeconds = 0.0f;
                CurrentWave++;
                GenerateEnemy3(1f, 5.2f);
                GenerateEnemy3(3f, -5.2f);
                GenerateEnemy3(5f, 5.2f);
                GenerateEnemy3(7f, -5.2f);
                GenerateEnemy3(9f, 5.2f);
                GenerateEnemy3(11f, -5.2f);
                
            }
        }
        
        private void SpawnTenthWave()
        {
            if (CurrentTimeInSeconds >= 5f && CurrentWave == 10)
            {
                CurrentTimeInSeconds = 0.0f;
                CurrentWave++;
                GenerateEnemy1(4f, 3f);
                GenerateEnemy2(4f, 1.5f);
                GenerateEnemy2(4f, 0f);
                GenerateEnemy2(4f, -1.5f);
                GenerateEnemy1(4f, -3f);
            }
        }

        private void StartBoss()
        {
            if (CurrentTimeInSeconds >= 10f && CurrentWave == 11)
            {
                CurrentTimeInSeconds = 0.0f;
                CurrentWave++;
                var bossGameObject = GameObject.FindWithTag("Boss");
                var boss = bossGameObject.GetComponent<EnemyBoss2>();
                boss.PlayCutScene();
                if (BGBossSong)
                {
                    BGBossSong.Play();
                }
            }
            if (CurrentTimeInSeconds >= 2.5f && CurrentWave == 12)
            {
                CurrentTimeInSeconds = 0.0f;
                CurrentWave++;
                if (BGSong)
                {
                    BGSong.Stop();
                }
            }
        }

        private void GenerateEnemy1(float pushX, float pushY)
        {
            Instantiate(PFEnemy1, new Vector3(GameSettings.SCREEN_LIMIT_X[1] + pushX, pushY, 0.0f), transform.rotation);
        }
        
        private void GenerateEnemy2(float pushX, float pushY)
        {
            Instantiate(PFEnemy2, new Vector3(GameSettings.SCREEN_LIMIT_X[1] + pushX, pushY, 0.0f), transform.rotation);
        }
        
        private void GenerateEnemy3(float pushX, float pushY)
        {
            Instantiate(PFEnemy3, new Vector3(GameSettings.SCREEN_LIMIT_X[1] + pushX, pushY, 0.0f), transform.rotation);
        }

        private void GenerateObstacle(float pushX, float pushY)
        {
            Instantiate(PFObstacle, new Vector3(GameSettings.SCREEN_LIMIT_X[1] + pushX, pushY, 0.0f), transform.rotation);
        }
    }
}