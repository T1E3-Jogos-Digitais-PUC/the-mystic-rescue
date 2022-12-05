using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditsMovement : MonoBehaviour
{
	public Transform credits;
	public Transform fimCreditos;
	public float velocity = 80f;

	float time;

	void Start()
	{
		if (SceneManager.GetActiveScene().name == "Vitoria")
		{
			time = 0;
		}
		else
		{
			time = 10f;
		}
		credits.position = new Vector3(credits.position.x, credits.position.y - Screen.height / 2, credits.position.z);
	}

	// Update is called once per frame
	void FixedUpdate()
	{
		time += Time.deltaTime;

		if (time > 10f)
		{
			credits.position = new Vector3(credits.position.x, credits.position.y + Time.deltaTime * velocity, credits.position.z);

			if (fimCreditos.position.y > Screen.height || Input.anyKey)
			{
				SceneManager.LoadScene("Menu");
			}
		}

	}
}
