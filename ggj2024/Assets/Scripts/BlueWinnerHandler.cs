using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BlueWinnerHandler : MonoBehaviour
{
    public void BlueSetup()
    {
        gameObject.SetActive(true);
    }

    public void BlueRetry() 
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }

    public void BlueGoBackMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
