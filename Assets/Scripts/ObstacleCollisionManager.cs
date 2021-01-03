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

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        progressBar = GameObject.Find("ProgressBar").GetComponent<ProgressBar>();
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

                Invoke("Resume", 2);

            }

            if(Other.tag == "Lava")
            {
                progressBar.gameOver = true;
            }



        }


    }


    public void Resume()
    {
        invulnerability = true;
        playerController.playerMovementSpeed = savedSpeed;
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
}
