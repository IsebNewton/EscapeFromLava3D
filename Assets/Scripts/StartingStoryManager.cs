using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartingStoryManager : MonoBehaviour
{
    // Start is called before the first frame update
    public bool started = false;

    public GameObject startingStoryScreen;
    public PlayerController playerController;
    public ProgressBar progressBar;


    void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        progressBar = GameObject.Find("ProgressBar").GetComponent<ProgressBar>();

        playerController.playerMovementSpeed = 0;
        progressBar.lavaSpeed = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(started == true)
        {
            playerController.playerMovementSpeed = 10;
            progressBar.lavaSpeed = 0.45f;
        }
    }

    public void StartGame()
    {
        started = true;
        startingStoryScreen.SetActive(false);
    }
}
