using System.Globalization;
using Codigo.Scripts.Entity.character;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; // Don't forget this line

namespace Codigo.Scripts.Entity.player
{
    public class Player: Character
    {
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
            float vertical = Input.GetAxis("Vertical");
            float horizontal = Input.GetAxis("Horizontal");

            if ((transform.position.y < GameSettings.SCREEN_LIMIT_Y[0] && vertical < 0) 
                || (transform.position.y > GameSettings.SCREEN_LIMIT_Y[1] && vertical > 0))
            {
                vertical = 0;
            }
            
            if ((transform.position.x < GameSettings.SCREEN_LIMIT_X[0] && horizontal < 0) 
                || (transform.position.x > GameSettings.SCREEN_LIMIT_X[1] && horizontal > 0))
            {
                horizontal = 0;
            }

            Direction = new Vector3(horizontal, vertical, 0);
            transform.position += Direction * (Speed * Time.deltaTime);
        }
        
        private void UpdateLifeBar()
        {
            Text.text = "Life: " + CurrentHp.ToString(CultureInfo.InvariantCulture) + "/" + MaxHp.ToString(CultureInfo.InvariantCulture);
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