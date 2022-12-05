using System.Collections;
using System.Collections.Generic;
using Codigo.Scripts;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

// [System.Serializable]
// public class FloatEvent : UnityEvent<float> { }

public class SetVolume : MonoBehaviour
{
	public bool IsFX = false;
	void Start()
	{
		if (IsFX)
		{
			slider.value = GameSettings.MusicVolume;
		}
		else
		{
			slider.value = GameSettings.FXVolume;
		}
	}

	public Slider slider;
	public void SetMusicVolume()
	{
		GameSettings.MusicVolume = slider.value;
	}

	public void SetFXVolume()
	{
		GameSettings.FXVolume = slider.value;
	}
}
