using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuInicial : MonoBehaviour
{
    public void Jugar(){
        SceneManager.LoadScene("Game"); //Se puede poner el nombre de la escena tambien "Game"
        //SceneManager.GetActiveScene().buildIndex + 1, siguiente escena
    }

    public void Salir(){
        Debug.Log("Salir...");
        Application.Quit();
    }

    public void MapaEspacio(){
        Debug.Log("Espacio...");
    }
    public void MapaDesierto(){
        Debug.Log("Desierto...");
    }
    public void MapaMar(){
        Debug.Log("Mar...");
    }

    public void Coche1(){
        Debug.Log("Coche1...");
    }
    public void Coche2(){
        Debug.Log("Coche2...");
    }
    public void Coche3(){
        Debug.Log("Coche3...");
    }
}
