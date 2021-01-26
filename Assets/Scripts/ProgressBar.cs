using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode()]
public class ProgressBar : MonoBehaviour
{

    public int maximum = 100;
    public float playerCurrent;
    public float lavaCurrent;
    public Image playerMask;
    public Image lavaMask;

    public bool gameOver;
    public GameObject gameOverObject;

    private GameObject player;
    public PlayerController playerController;

    public GeneralLevelsAndCoinsManager generalLevelsAndCoinsManager;
    public ScoreDisplay scoreDisplay;

    public float lavaSpeed;// = 0.45f;

    // Start is called before the first frame update
    void Start()
    {
        gameOver = false;
        player = GameObject.Find("Player");
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        lavaCurrent = -2;
        generalLevelsAndCoinsManager = GeneralLevelsAndCoinsManager.Instance;
        scoreDisplay = GameObject.Find("ScoreText").GetComponent<ScoreDisplay>();


        gameOverObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(gameOver == false)
        {
            playerCurrent = player.transform.position.z/20;
            GetCurrentFillPlayer();
            lavaCurrent += lavaSpeed * Time.deltaTime;
            GetCurrentFillLava();
        }
        if (playerCurrent < lavaCurrent)
        {
            gameOver = true;
        }
        if (gameOver == true)
        {
            playerController.playerMovementSpeed = 0;
            generalLevelsAndCoinsManager.LevelDied(scoreDisplay.score);
            gameOverObject.SetActive(true);
        }
    }

    void GetCurrentFillPlayer()
    {
        float fillAmount = (float)playerCurrent / (float)maximum;
        playerMask.fillAmount = fillAmount;
    }

    void GetCurrentFillLava()
    {
        float fillAmount = (float)lavaCurrent / (float)maximum;
        lavaMask.fillAmount = fillAmount;
    }
}
