using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{



    private void Start()
    {
        StateManager.SetCurrentState(StateManager.State.MainMenuState);
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("EscapeFromLava");
        StateManager.SetCurrentState(StateManager.State.StoryState);
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("Menu");
        StateManager.SetCurrentState(StateManager.State.MainMenuState);
    }

    public void QuitGame()
    {
        Debug.Log("QUIT!");
        Application.Quit();
    }



}
