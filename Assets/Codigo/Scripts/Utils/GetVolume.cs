using System.Collections;
using System.Collections.Generic;
using Codigo.Scripts;
using UnityEngine;

public class GetVolume : MonoBehaviour
{
    public bool IsFX = false;
    public AudioSource audio;
    // Update is called once per frame
    void Update()
    {
        if (IsFX)
        {
            if (audio.volume != GameSettings.FXVolume)
                audio.volume = GameSettings.FXVolume;
        }
        else
        {
            if (audio.volume != GameSettings.MusicVolume)
                audio.volume = GameSettings.MusicVolume;
        }
    }
}
