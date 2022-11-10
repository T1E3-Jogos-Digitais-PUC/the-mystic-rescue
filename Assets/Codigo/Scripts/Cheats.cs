using System.Collections;
using System.Collections.Generic;
using Codigo.Scripts.Entity.player;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Cheats : MonoBehaviour
{
    private void Start()
    {

    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.LeftAlt))
        {
            //Alt + I: Player Invencible
            if (Input.GetKeyDown(KeyCode.I)) 
            {
                Debug.Log("Alt + I");

                GameObject gameObj = GameObject.Find("PFPlayer");
                Player player = gameObj.GetComponent<Player>();
                
                if (player.IsInvencible)
                {
                    player.IsInvencible = false;
                    Debug.Log("Player Is Invencible: Turned Off!");
                }
                else
                {
                    player.IsInvencible = true;
                    Debug.Log("Player Is Invencible: Turned On!");
                }
            }

            //Alt + N: Load next Level
            if (Input.GetKeyDown(KeyCode.N)) 
            {
                int scenesCount = SceneManager.sceneCountInBuildSettings;
                Scene activeScene = SceneManager.GetActiveScene();
                int index = activeScene.buildIndex;
                Debug.Log($"Scene {index} of {scenesCount}");

                if (index < scenesCount - 1)
                {
                    SceneManager.LoadScene(index + 1);
                }
                else
                {
                    SceneManager.LoadScene(0);
                }
            }
        }
        
    }
}
