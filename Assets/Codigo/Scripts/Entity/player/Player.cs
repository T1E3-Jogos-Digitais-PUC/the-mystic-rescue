using Codigo.Scripts.Entity.character;
using Unity.VisualScripting;
using UnityEngine;

namespace Codigo.Scripts.Entity.player
{
    public class Player: Character
    {
        public Player() : base("Cryani", 14.0f, 10, 10, 100, 20, CharacterType.PLAYER)
        {
            
        }

        void Start()
        {
 
        }
        
        void Update()
        {
            PlayerMovement();
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
    }
}