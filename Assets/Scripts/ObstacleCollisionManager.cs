﻿using System.Collections;
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

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        progressBar = GameObject.Find("ProgressBar").GetComponent<ProgressBar>();
        ending.SetActive(false);
        playerAnim = GameObject.Find("Player").GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
       
    }


    public void ObstacleCollision(Collider Other)
    {
        if (invulnerability == false)
        {
            if (Other.tag == "Obstacle")
            {
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
        
        invulnerability = true;
        playerController.playerMovementSpeed = 10;
        playerController.playerStrafeSpeed = 7;
        playerController.jump = false;
        saved = false;
        

        Invoke("SetVulnerability", 5);
    }


    public void SetVulnerability()
    {
        player.GetComponent<Renderer>().material = original;
        invulnerability = false;
        
    }

    public void ResetHitObstacle()
    {
        playerAnim.SetBool("HitObstacle", false);
    }
}
