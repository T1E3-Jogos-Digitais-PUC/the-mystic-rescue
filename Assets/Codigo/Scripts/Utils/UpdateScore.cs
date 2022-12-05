using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using Codigo.Scripts;
using TMPro;
using UnityEngine;

public class UpdateScore : MonoBehaviour
{

	TextMeshProUGUI txtMesh;
	// Start is called before the first frame update
	void Start()
	{
		txtMesh = this.GetComponent<TextMeshProUGUI>();
		txtMesh.text = GameSettings.Score.ToString(CultureInfo.InvariantCulture);
	}

	// Update is called once per frame
	void Update()
	{
		if (txtMesh)
		{
			if (GameSettings.Score != Int32.Parse(txtMesh.text))
			{
				txtMesh.text = GameSettings.Score.ToString(CultureInfo.InvariantCulture);
			}
		}
	}
}
