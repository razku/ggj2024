using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void BotonPlay()
    {
        SceneManager.LoadScene("Game");
    }

    public void BotonQuit()
    {
        Debug.Log("Cierra el Juego");
        Application.Quit();
    }

}