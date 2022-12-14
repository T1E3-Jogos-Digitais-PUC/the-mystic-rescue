using System.Collections;
using Codigo.Scripts.Entity.character;
using UnityEngine;
using UnityEngine.UI;

namespace Codigo.Scripts.Entity.enemy.stage1
{
    public class EnemyBoss1: Character
    {
        public Image LifeBarRed;
        public Image LifeBarGreen;
        public GameObject Weapon;
        private float Vertical = -1;
        private bool InInitialCutScene = true;
        private bool StartCutScene = false;
        private GameObject BossUI;
        private void Start()
        {
            IsInvencible = true;
            BossUI = GameObject.FindWithTag("BossUI");
            BossUI.SetActive(false);
            Weapon.SetActive(false);
        }

        void Update()
        {
            if (StartCutScene)
            {
                if (InInitialCutScene)
                {
                    InitialCutScene();
                }
                else
                {
                    EnemyMovement();
                }
                UpdateLifeBar();
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
                BossUI.SetActive(true);
                Weapon.SetActive(true);
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

        private IEnumerator DecreasingRedBar(Vector3 newScale)
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
        
        public void PlayCutScene()
        {
            StartCutScene = true;
        }
    }
}