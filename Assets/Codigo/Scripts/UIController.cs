using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    public void CarregaCena(string nomeCena)
    {
        SceneManager.LoadScene(nomeCena);
    }

    public void Sair()
    {
        Application.Quit();
    }
}
