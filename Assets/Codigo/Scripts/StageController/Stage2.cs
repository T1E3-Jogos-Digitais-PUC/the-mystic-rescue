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
        }

        private void SpawnFirstWave()
        {
            if (CurrentTimeInSeconds >= 2.5f && CurrentWave == 1)
            {
                CurrentTimeInSeconds = 0.0f;
                CurrentWave++;
                GenerateEnemy1(1f, 0f);
            }
        }
        
        private void SpawnSecondWave()
        {
            if (CurrentTimeInSeconds >= 3.5f && CurrentWave == 2)
            {
                CurrentTimeInSeconds = 0.0f;
                CurrentWave++;
                GenerateEnemy1(1f, -4.9f);
                GenerateEnemy1(1f, 3.2f);
                GenerateEnemy2(10f, 3.2f);
                GenerateEnemy2(12f, GameHelper.GetRandomFloat(-5f, 5f));
                
                GenerateEnemy1(GameHelper.GetRandomFloat(GameSettings.SCREEN_LIMIT_X[1] + 4f, 200f), GameHelper.GetRandomFloat(-5f, 5f));
                GenerateEnemy2(GameHelper.GetRandomFloat(GameSettings.SCREEN_LIMIT_X[1] + 4f, 200f), GameHelper.GetRandomFloat(-5f, 5f));
                GenerateEnemy3(GameHelper.GetRandomFloat(GameSettings.SCREEN_LIMIT_X[1] + 4f, 200f), GameHelper.GetRandomFloat(-5.5f, -5f));
                GenerateEnemy3(GameHelper.GetRandomFloat(GameSettings.SCREEN_LIMIT_X[1] + 4f, 200f), GameHelper.GetRandomFloat(5.5f, 5f));
                GenerateEnemy3(GameHelper.GetRandomFloat(GameSettings.SCREEN_LIMIT_X[1] + 4f, 200f), GameHelper.GetRandomFloat(-5.5f, -5f));
                GenerateEnemy3(GameHelper.GetRandomFloat(GameSettings.SCREEN_LIMIT_X[1] + 4f, 200f), GameHelper.GetRandomFloat(5.5f, 5f));
                GenerateEnemy3(GameHelper.GetRandomFloat(GameSettings.SCREEN_LIMIT_X[1] + 4f, 200f), GameHelper.GetRandomFloat(-5.5f, -5f));
                GenerateEnemy3(GameHelper.GetRandomFloat(GameSettings.SCREEN_LIMIT_X[1] + 4f, 200f), GameHelper.GetRandomFloat(5.5f, 5f));                
                GenerateEnemy1(GameHelper.GetRandomFloat(GameSettings.SCREEN_LIMIT_X[1] + 4f, 200f), GameHelper.GetRandomFloat(-5f, 5f));
                GenerateEnemy2(GameHelper.GetRandomFloat(GameSettings.SCREEN_LIMIT_X[1] + 4f, 200f), GameHelper.GetRandomFloat(-5f, 5f));
                GenerateEnemy3(GameHelper.GetRandomFloat(GameSettings.SCREEN_LIMIT_X[1] + 4f, 200f), GameHelper.GetRandomFloat(-5.5f, -5f));
                GenerateEnemy3(GameHelper.GetRandomFloat(GameSettings.SCREEN_LIMIT_X[1] + 4f, 200f), GameHelper.GetRandomFloat(5.5f, 5f));
                GenerateEnemy3(GameHelper.GetRandomFloat(GameSettings.SCREEN_LIMIT_X[1] + 4f, 200f), GameHelper.GetRandomFloat(-5.5f, -5f));
                GenerateEnemy3(GameHelper.GetRandomFloat(GameSettings.SCREEN_LIMIT_X[1] + 4f, 200f), GameHelper.GetRandomFloat(5.5f, 5f));
                GenerateEnemy3(GameHelper.GetRandomFloat(GameSettings.SCREEN_LIMIT_X[1] + 4f, 200f), GameHelper.GetRandomFloat(-5.5f, -5f));
                GenerateEnemy3(GameHelper.GetRandomFloat(GameSettings.SCREEN_LIMIT_X[1] + 4f, 200f), GameHelper.GetRandomFloat(5.5f, 5f));                
                GenerateEnemy1(GameHelper.GetRandomFloat(GameSettings.SCREEN_LIMIT_X[1] + 4f, 200f), GameHelper.GetRandomFloat(-5f, 5f));
                GenerateEnemy2(GameHelper.GetRandomFloat(GameSettings.SCREEN_LIMIT_X[1] + 4f, 200f), GameHelper.GetRandomFloat(-5f, 5f));
                GenerateEnemy3(GameHelper.GetRandomFloat(GameSettings.SCREEN_LIMIT_X[1] + 4f, 200f), GameHelper.GetRandomFloat(-5.5f, -5f));
                GenerateEnemy3(GameHelper.GetRandomFloat(GameSettings.SCREEN_LIMIT_X[1] + 4f, 200f), GameHelper.GetRandomFloat(5.5f, 5f));
                GenerateEnemy3(GameHelper.GetRandomFloat(GameSettings.SCREEN_LIMIT_X[1] + 4f, 200f), GameHelper.GetRandomFloat(-5.5f, -5f));
                GenerateEnemy3(GameHelper.GetRandomFloat(GameSettings.SCREEN_LIMIT_X[1] + 4f, 200f), GameHelper.GetRandomFloat(5.5f, 5f));
                GenerateEnemy3(GameHelper.GetRandomFloat(GameSettings.SCREEN_LIMIT_X[1] + 4f, 200f), GameHelper.GetRandomFloat(-5.5f, -5f));
                GenerateEnemy3(GameHelper.GetRandomFloat(GameSettings.SCREEN_LIMIT_X[1] + 4f, 200f), GameHelper.GetRandomFloat(5.5f, 5f));                
                GenerateEnemy1(GameHelper.GetRandomFloat(GameSettings.SCREEN_LIMIT_X[1] + 4f, 200f), GameHelper.GetRandomFloat(-5f, 5f));
                GenerateEnemy2(GameHelper.GetRandomFloat(GameSettings.SCREEN_LIMIT_X[1] + 4f, 200f), GameHelper.GetRandomFloat(-5f, 5f));
                GenerateEnemy3(GameHelper.GetRandomFloat(GameSettings.SCREEN_LIMIT_X[1] + 4f, 200f), GameHelper.GetRandomFloat(-5.5f, -5f));
                GenerateEnemy3(GameHelper.GetRandomFloat(GameSettings.SCREEN_LIMIT_X[1] + 4f, 200f), GameHelper.GetRandomFloat(5.5f, 5f));
                GenerateEnemy3(GameHelper.GetRandomFloat(GameSettings.SCREEN_LIMIT_X[1] + 4f, 200f), GameHelper.GetRandomFloat(-5.5f, -5f));
                GenerateEnemy3(GameHelper.GetRandomFloat(GameSettings.SCREEN_LIMIT_X[1] + 4f, 200f), GameHelper.GetRandomFloat(5.5f, 5f));
                GenerateEnemy3(GameHelper.GetRandomFloat(GameSettings.SCREEN_LIMIT_X[1] + 4f, 200f), GameHelper.GetRandomFloat(-5.5f, -5f));
                GenerateEnemy3(GameHelper.GetRandomFloat(GameSettings.SCREEN_LIMIT_X[1] + 4f, 200f), GameHelper.GetRandomFloat(5.5f, 5f));
            }
        }

        private void StartBoss()
        {
            if (CurrentTimeInSeconds >= 10f && CurrentWave == 11)
            {
                CurrentTimeInSeconds = 0.0f;
                CurrentWave++;
                var bossGameObject = GameObject.FindWithTag("Boss");
                var boss = bossGameObject.GetComponent<EnemyBoss1>();
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
    }
}