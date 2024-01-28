using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RedWinnerHandler : MonoBehaviour
{
    public void RedSetup() 
    {
        gameObject.SetActive(true);
    }

    public void RedRetry()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }

    public void RedGoBackMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
