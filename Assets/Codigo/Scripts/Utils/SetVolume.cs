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
