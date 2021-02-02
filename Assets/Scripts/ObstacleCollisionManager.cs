using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObstacleCollisionManager : MonoBehaviour
{

    public bool invulnerability = false;
    public bool saved = false;
    public float savedSpeed;
    private GameObject player;
    private PlayerController playerController;
    public Material white;
    public Material original;
    private ProgressBar progressBar;
    public GameObject ending;
    public Animator playerAnim;
    public float invincibilityTimer;

    public DifficultyManager difficultyManager;
    public GeneralLevelsAndCoinsManager generalLevelsAndCoinsManager;
    public ScoreDisplay scoreDisplay;
    public LevelManager levelManager;

    public GameObject obstacleBump2Object; 
    public AudioSource obstacleBump2Audio;

    public GameObject endingMusicObject;
    public AudioSource endingMusicAudio;

    public GameObject levelUnlock;

    public GameObject mediumUnlock;
    public GameObject hardUnlock;
    public GameObject nightmareUnlock;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        progressBar = GameObject.Find("ProgressBar").GetComponent<ProgressBar>();
        ending.SetActive(false);
        playerAnim = GameObject.Find("Player").GetComponent<Animator>();
        invincibilityTimer = 0;

        difficultyManager = DifficultyManager.Instance;
        generalLevelsAndCoinsManager = GeneralLevelsAndCoinsManager.Instance;
        scoreDisplay = GameObject.Find("ScoreText").GetComponent<ScoreDisplay>();
        levelManager = GameObject.Find("LevelManager").GetComponent<LevelManager>();

        obstacleBump2Audio = obstacleBump2Object.GetComponent<AudioSource>();
        endingMusicAudio = endingMusicObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
       if(invincibilityTimer > 0)
        {
            invincibilityTimer -= Time.deltaTime;
        }


       if(invincibilityTimer > 0.1f)
        {
            invulnerability = true;
        }
       else if(invincibilityTimer < 0.1f)
        {
            invulnerability = false;
        }


    }


    public void ObstacleCollision(Collider Other)
    {
        if (invulnerability == false)
        {
            if (Other.tag == "Obstacle")
            {


                    obstacleBump2Audio.Play();


        

                if (saved == false)
                {
                    savedSpeed = playerController.playerMovementSpeed;
                    Debug.Log(savedSpeed);
                    saved = true;
                }

                player.transform.position = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z - 2);

                playerController.playerMovementSpeed = 0;
                playerController.playerStrafeSpeed = 0;
                playerController.jumpBlocking = true;
                player.GetComponent<Renderer>().material = white;
                playerAnim.SetBool("HitObstacle", true);
                playerController.dirtParticle.Stop();
                Invoke("ResetHitObstacle", 1);
                Invoke("Resume", 4);

            }

             if(Other.tag == "Lava")
             {
                progressBar.gameOver = true;
             
             }



        }
        if (Other.tag == "Ending")
        {

            progressBar.lavaSpeed = 0;
            playerController.playerMovementSpeed = 0;
            generalLevelsAndCoinsManager.LevelFinish(difficultyManager.difficulty, scoreDisplay.score);
            ending.SetActive(true);

            
            levelManager.musicAudio.Stop();
            endingMusicAudio.Play();

           if(difficultyManager.difficulty == 1)
            {
                if(PlayerPrefs.GetFloat("MaxLevel") == 1)
                {
                    mediumUnlock.SetActive(true);
                }
            }

            if (difficultyManager.difficulty == 2.5f)
            {
                if (PlayerPrefs.GetFloat("MaxLevel") == 2.5f)
                {
                    hardUnlock.SetActive(true);
                }
            }

            if (difficultyManager.difficulty == 4)
            {
                if (PlayerPrefs.GetFloat("MaxLevel") == 4)
                {
                    nightmareUnlock.SetActive(true);
                }
            }

        }

    }


    public void Resume()
    {

        invincibilityTimer = 6;
        playerController.playerMovementSpeed = 10;
        playerController.playerStrafeSpeed = 7;
        playerController.jumpBlocking = false;
        saved = false;
        playerController.dirtParticle.Play();


        //Invoke("SetVulnerability", 5);
    }


    //public void SetVulnerability()
    //{
    //    player.GetComponent<Renderer>().material = original;
    //    invulnerability = false;
        
    //}

    public void ResetHitObstacle()
    {
        playerAnim.SetBool("HitObstacle", false);
    }
}
