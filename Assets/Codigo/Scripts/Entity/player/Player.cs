using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using Codigo.Scripts.Entity.character;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Codigo.Scripts.Entity.player
{
    public class Player: Character
    {
        public Image LifeBarRed;
        public Image LifeBarGreen;
        public Image ShieldBarBlue;
        public GameObject GameOverImage;
        public TMPro.TextMeshProUGUI ScoreText;
        private bool InInitialCutScene = true;
        private bool InFinalCutScene = false;
        public GameObject ShieldGameObject;
        private float NextFire = 0.0f;
        public bool CanInput = true;
        
        private void Start()
        {
            Direction = new Vector3(1, 0, 0);
            if (ShieldGameObject != null)
            {
                ShieldGameObject.SetActive(false);
            }
            if (GameOverImage != null)
            {
                GameOverImage.SetActive(false);
            }
        }
        
        void Update()
        {
            ActiveShield();
            if (!InFinalCutScene)
            {
                if (InInitialCutScene)
                {
                    InitialCutScene();
                }
                else if (CanInput)
                {
                    PlayerMovement();
                }

                UpdateLifeBar();
                UpdateScore();
                GameOver();
            }
            else
            {
                FinalCutScene();
            }
        }

        private void ActiveShield()
        {
            UpdateShieldBar();
            if (NextFire <= 0.0f && ShieldGameObject && ShieldGameObject.activeSelf == false)
            {
                if (Input.GetMouseButtonDown(1))
                {
                    ShieldGameObject.SetActive(true);
                    NextFire = 5f;
                }
            }
            NextFire -= Time.deltaTime;
        }

        private void InitialCutScene()
        {
            transform.position += Direction * (3.5f * Time.deltaTime);
            if (transform.position.x >= GameSettings.SCREEN_LIMIT_X[0] + (GameSettings.SCREEN_LIMIT_X[1] / 5))
            {
                InInitialCutScene = false;
            }
        }
        
        private void FinalCutScene()
        {
            if (transform.position.y > 0)
            {
                transform.position += new Vector3(0, -1, 0) * (6f * Time.deltaTime);
            }
            else if (transform.position.y < 0)
            {
                transform.position += new Vector3(0, 1, 0) * (6f * Time.deltaTime);
            }
            transform.position += Direction * (4f * Time.deltaTime);
        }

        // ReSharper disable Unity.PerformanceAnalysis
        private void PlayerMovement()
        {
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");
            
            if ((transform.position.x < GameSettings.SCREEN_LIMIT_X[0] && horizontal < 0) 
                || (transform.position.x > GameSettings.SCREEN_LIMIT_X[1] && horizontal > 0))
            {
                horizontal = 0;
            }
            if ((transform.position.y < GameSettings.SCREEN_LIMIT_Y[0] && vertical < 0) 
                || (transform.position.y > GameSettings.SCREEN_LIMIT_Y[1] && vertical > 0))
            {
                vertical = 0;
            }
            
            // float v = Input.GetAxis("Vertical");
            float dx = horizontal * Speed * Time.deltaTime;
            float dy = vertical * Speed * Time.deltaTime;
            transform.position = new Vector3(transform.position.x+dx, transform.position.y+dy, 0);

        }
        
        private void UpdateLifeBar()
        {
            if (LifeBarRed && LifeBarGreen)
            {
                var transform1 = LifeBarGreen.transform;
                Vector3 lifeBarScale = transform1.localScale;
                lifeBarScale.x = CurrentHp / MaxHp;
                transform1.localScale = lifeBarScale;
                StartCoroutine(DecreasingRedBar(lifeBarScale));
            }
        }

        IEnumerator DecreasingRedBar(Vector3 newScale)
        {
            yield return new WaitForSeconds(0.5f);
            Vector3 redBarScale = LifeBarRed.transform.localScale;
            while (LifeBarRed.transform.localScale.x > newScale.x)
            {
                redBarScale.x -= Time.deltaTime * 0.10f;
                LifeBarRed.transform.localScale = redBarScale;
                yield return null;
            }
            LifeBarRed.transform.localScale = newScale;
        }
        
        //make a method to update the shield bar
        private void UpdateShieldBar()
        {
            if (ShieldBarBlue)
            {
                var transform1 = ShieldBarBlue.transform;
                Vector3 shieldBarScale = transform1.localScale;
                var cooldown = NextFire / 5f;
                if (cooldown <= 0)
                {
                    cooldown = 1;
                }
                shieldBarScale.x = cooldown;
                transform1.localScale = shieldBarScale;
            }
        }

        private void UpdateScore()
        {
            if (ScoreText)
            {
                ScoreText.text = Score.ToString(CultureInfo.InvariantCulture);
            }
        }

        // ReSharper disable Unity.PerformanceAnalysis
        private void GameOver()
        {
            if (CurrentHp <= 0)
            {
                CanInput = false;
                if(GameOverImage) {
                    GameOverImage.SetActive(true);
                }
                Time.timeScale = 0.2f;
                StartCoroutine(LoadMenuSceneAfterSeconds(0.5f));
            }
        }
        
        IEnumerator LoadMenuSceneAfterSeconds(float seconds)
        {
            yield return new WaitForSeconds(seconds);
            SceneManager.LoadScene("Menu");
        }
        
        public void PlayVictoryCutscene()
        {
            IsInvencible = true;
            InFinalCutScene = true;
            Direction = new Vector3(1, 0, 0);
        }
        
        
    }
}