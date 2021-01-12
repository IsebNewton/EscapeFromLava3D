using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    public GameObject obstacleBump1Object;
    public GameObject obstacleBump2Object;
    public AudioSource obstacleBump1Audio;
    public AudioSource obstacleBump2Audio;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        progressBar = GameObject.Find("ProgressBar").GetComponent<ProgressBar>();
        ending.SetActive(false);
        playerAnim = GameObject.Find("Player").GetComponent<Animator>();
        invincibilityTimer = 0;

        obstacleBump1Audio = obstacleBump1Object.GetComponent<AudioSource>();
        obstacleBump2Audio = obstacleBump2Object.GetComponent<AudioSource>();
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

                float rand = Random.Range(1, 10);
                if(rand <= 5)
                {
                    obstacleBump1Audio.Play();
                }
                else if(rand > 5)
                {
                    obstacleBump2Audio.Play();
                }



                if (saved == false)
                {
                    savedSpeed = playerController.playerMovementSpeed;
                    saved = true;
                }

                player.transform.position = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z - 2);

                playerController.playerMovementSpeed = 0;
                playerController.playerStrafeSpeed = 0;
                playerController.jump = true;
                player.GetComponent<Renderer>().material = white;
                playerAnim.SetBool("HitObstacle", true);

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
            ending.SetActive(true);
            Debug.Log("ending");
        }

    }


    public void Resume()
    {

        invincibilityTimer = 5;
        playerController.playerMovementSpeed = 10;
        playerController.playerStrafeSpeed = 7;
        playerController.jump = false;
        saved = false;
        

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
