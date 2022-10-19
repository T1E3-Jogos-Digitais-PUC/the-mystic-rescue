using System.Globalization;
using Codigo.Scripts.Entity.character;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Codigo.Scripts.Entity.player
{
    public class Player: Character
    {
        public Image LifeBarRed;
        public Image LifeBarGreen;
        
        public TMPro.TextMeshProUGUI Text;
        private bool InInitialCutScene = true;
        void Update()
        {
            if (InInitialCutScene)
            {
                InitialCutScene();
            }
            else
            {
                PlayerMovement();
            }

            UpdateLifeBar();
            GameOver();
        }
        
        private void InitialCutScene()
        {
            Direction = new Vector3(1, 0, 0);
            transform.position += Direction * (3.5f * Time.deltaTime);
            if (transform.position.x >= GameSettings.SCREEN_LIMIT_X[0] + (GameSettings.SCREEN_LIMIT_X[1] / 4))
            {
                InInitialCutScene = false;
            }
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
            }
        }
        
        private void GameOver()
        {
            if (CurrentHp <= 0)
            {
                SceneManager.LoadScene("Fase01");
            }
        }
    }
}