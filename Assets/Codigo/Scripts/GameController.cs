using System.Collections;
using System.Collections.Generic;
using Codigo.Scripts;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
	float decay = 0;
	float deltaTime = 0;

    public Button bt_Voltar;

	void Start()
	{
		deltaTime = Time.deltaTime;
        bt_Voltar.GetComponent<Button>().onClick.AddListener(closePauseScreen);
	}


	// Update is called once per frame
	void Update()
	{
        //Dá um delay para quando apertar o Esc, não ficar pausando e despausando várias vezes
		if (decay > 0)
		{
			decay -= deltaTime;
		}
		if (decay < 0)
		{
			decay = 0;
		}


		if (Input.GetKey(KeyCode.Escape) && decay == 0)
		{
			decay = 1f;
			if (Time.timeScale == 0)
			{
				PreeEsc();
			}
			else
			{
				PreeEsc(false);
			}
		}
	}

	void PreeEsc(bool resume = true)
	{
		Time.timeScale = resume ? 1 : 0;
		GameSettings.IsPaused = !resume;
		this.transform.position = new Vector3(this.transform.position.x, resume ? 1080 : 0, this.transform.position.z);
	}

    public void closePauseScreen()
    {
        Time.timeScale = 1;
        this.transform.position = new Vector3(this.transform.position.x, 1080, this.transform.position.z);
    }
}