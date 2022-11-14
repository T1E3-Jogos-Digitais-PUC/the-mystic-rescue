using System.Collections;
using System.Collections.Generic;
using Codigo.Scripts;
using Codigo.Scripts.Entity.player;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Cheats : MonoBehaviour
{
	private string message = "";

	private void Update()
	{
		if (Input.GetKey(KeyCode.Escape))
		{
			if (GameSettings.IsPaused)
			{
				Time.timeScale = 1;
				GameSettings.IsPaused = false;
			}
			else
			{
				Time.timeScale = 0;
				GameSettings.IsPaused = true;
			}
			
		}

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
					message = "Player Is Invencible: Turned Off!";
				}
				else
				{
					player.IsInvencible = true;
					message = "Player Is Invencible: Turned On!";
				}
			}

			//Alt + N: Load next Level
			if (Input.GetKeyDown(KeyCode.N))
			{
				int scenesCount = SceneManager.sceneCountInBuildSettings;
				Scene activeScene = SceneManager.GetActiveScene();
				int index = activeScene.buildIndex;

				if (index < scenesCount - 1)
				{
					message = $"From scene {index} of {scenesCount} to scene {index + 1} of {scenesCount}";
					SceneManager.LoadScene(index + 1);
				}
				else
				{
					message = $"From scene {index} of {scenesCount} to scene 0 of {scenesCount}";
					SceneManager.LoadScene(0);
				}
			}



            if (message != "") Debug.Log(message);
		}

	}



}
