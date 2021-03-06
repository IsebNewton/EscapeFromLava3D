﻿using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartingStoryManager : MonoBehaviour
{
    // Start is called before the first frame update
    public bool started = false;
    public bool once = false;

    public GameObject startingStoryScreen;
    public PlayerController playerController;
    public ProgressBar progressBar;
    public LevelManager levelManager;
   

    public Text beginningStoryDescription;
    public Text beginningStoryButton;
    public Text scoreText;
    public Text progressbarPlayerText;
    public Text progressbarLavaText;
    public Text endingScore;
    public Text backToMenuButton;
    public Text escapedheading;
    public Text escapedBackToMenuButton;
    public Text awesomeText;

    public Text mediumUnlock;
    public Text hardUnlock;
    public Text nightmareUnlock;

    public DifficultyManager difficultyManager;

    void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        progressBar = GameObject.Find("ProgressBar").GetComponent<ProgressBar>();
        levelManager = GameObject.Find("LevelManager").GetComponent<LevelManager>();

        playerController.playerMovementSpeed = 0;
        progressBar.lavaSpeed = 0;

        difficultyManager = DifficultyManager.Instance;

        if (PlayerPrefs.GetString("Language") == "German")
        {
            beginningStoryDescription.text = "Als Praktikant bei Team Magma hast du Informationen gesehen, die nicht für dein Auge bestimmt waren. Trotz deiner Versprechen, die Informationen nicht weiterzugeben, wirst du betäubt und wachst im inneren eines Vulkans auf. Du befindest dich in einem der untersten Nebenschlote des Vulkans. Versuche aus dem Vulkan zu entkommen bevor dich die Lava einholt. Weiche dabei Hindernissen und der sofort tödlichen Lava aus! Während du schon dabei bist, warum sammelst du nicht die Bücher vollen geheimer Informationen auf welche Team Magma hinterlassen hat?";
            beginningStoryButton.text = "Start";
            scoreText.text = "Punkte :";
            progressbarPlayerText.text = "Spieler";
            progressbarLavaText.text = "Lava";
            endingScore.text = "Deine Punkte :";
            backToMenuButton.text = "Zurück zum Menu";
            escapedheading.text = "DU BIST ENTKOMMEN";
            escapedBackToMenuButton.text = "Zurück zum Menu";
            awesomeText.text = "Du geile Sau";
            mediumUnlock.text = "Du hast die Schwierigkeit 'Mittel' freigeschaltet!";
            hardUnlock.text = "Du hast die Schwierigkeit 'Schwer' freigeschaltet!";
            nightmareUnlock.text = "Du hast die Schwierigkeit 'Albtraum' freigeschaltet!";

        }
        else if(PlayerPrefs.GetString("Language") == "English")
        {
            beginningStoryDescription.text = "As a apprentice in team Magma you saw information not meant for your eyes. Even though you promised not to tell a living soul, you get paralized and wake up in a volcano. Youre in one of the deepest chambers of the volcano. Try to escape the volcano before the lava catches up to you. Dodge the incoming obstacles and instant killing lava! While youre at it, why not collect the books full of secret information team Magma left behind?";
            beginningStoryButton.text = "Start";
            scoreText.text = "Score :";
            progressbarPlayerText.text = "Player";
            progressbarLavaText.text = "Lava";
            endingScore.text = "Your Score :";
            backToMenuButton.text = "Back to menu";
            escapedheading.text = "YOU ESCAPED";
            escapedBackToMenuButton.text = "Back to menu";
            awesomeText.text = "You awesome person";
            mediumUnlock.text = "You unlocked medium difficulty!";
            hardUnlock.text = "You unlocked hard difficulty!";
            nightmareUnlock.text = "You unlocked nightmare difficulty!";
        }
    }

    // Update is called once per frame
    void Update()
    {
        
        if (started == true && once == false)
        {
            playerController.playerMovementSpeed = 10;

            if(difficultyManager.difficulty == 1)
            {
                progressBar.lavaSpeed = 0.45f;
            }
            if (difficultyManager.difficulty == 2.5)
            {
                progressBar.lavaSpeed = 0.47f;
            }
            if (difficultyManager.difficulty == 4)
            {
                progressBar.lavaSpeed = 0.485f;
            }
            if (difficultyManager.difficulty == 6)
            {
                progressBar.lavaSpeed = 0.5f;
            }

            once = true;
            levelManager.musicAudio.Play();
        }
    }

    public void StartGame()
    {
        started = true;
        startingStoryScreen.SetActive(false);
        StateManager.SetCurrentState(StateManager.State.PlayState);
    }
}
