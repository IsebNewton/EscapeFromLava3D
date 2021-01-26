using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{



    private void Start()
    {


    }

    public void PlayGame()
    {
        SceneManager.LoadScene("EscapeFromLava");
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("Menu");

    }

    public void QuitGame()
    {
        Debug.Log("QUIT!");
        Application.Quit();
    }



}
