using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuInicial : MonoBehaviour
{
    public void Jugar(){
        //SceneManager.LoadScene("Game"); //Se puede poner el nombre de la escena tambien "Game"
        //SceneManager.GetActiveScene().buildIndex + 1, siguiente escena
    }

    public void Salir(){
        Debug.Log("Salir...");
        Application.Quit();
    }

    public void MapaEspacio(){
        Debug.Log("Espacio...");
        SceneManager.LoadScene("Game2");
    }
    
    public void MapaMar(){
        Debug.Log("Mar...");
        SceneManager.LoadScene("Game");
    }

   
}
