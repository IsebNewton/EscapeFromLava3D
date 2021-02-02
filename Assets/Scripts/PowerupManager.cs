using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupManager : MonoBehaviour
{

    private PlayerController playerController;
    private ObstacleCollisionManager obstacleCollisionManager;
    private GameObject player;
    public Material white;
    public Material original;
    public float clampSpeedFast;
    public float clampSpeedSlow;
    public Material hitMaterial;
    public Material normalMaterial;
    public GameObject playerBodyForColorChange;
    public GameObject playerJointsForColorChange;
    public Material normaljointsMaterial;

    public ScoreDisplay scoreDisplayText;
    public ScoreDisplay scoreDisplayEnding;
    public GameObject gameOver;

    public GameObject collectBingObject;
    public AudioSource collectBingAudio;

    public ParticleSystem explosion;

    public Material redMaterialJump;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        obstacleCollisionManager = GameObject.Find("ObstacleCollisionManager").GetComponent<ObstacleCollisionManager>();
        clampSpeedFast = 20;
        clampSpeedSlow = 10;

        collectBingAudio = collectBingObject.GetComponent<AudioSource>();

        gameOver.SetActive(true);

        scoreDisplayText = GameObject.Find("ScoreText").GetComponent<ScoreDisplay>();
        scoreDisplayEnding = GameObject.Find("EndScore").GetComponent<ScoreDisplay>();

        gameOver.SetActive(false);

        normalMaterial = playerController.playerMaterial;
    }

    // Update is called once per frame
    void Update()
    {
      
        if (playerController.playerMovementSpeed > 12)
        {
            playerController.trail1.SetActive(true);
            playerController.trail2.SetActive(true);
        }
        if (playerController.playerMovementSpeed < 12)
        {
          
            playerController.trail1.SetActive(false);
            playerController.trail2.SetActive(false);
        }






        if(obstacleCollisionManager.invincibilityTimer > 5.5f)
        {
            playerBodyForColorChange.GetComponent<Renderer>().material = hitMaterial;
        }
        if (obstacleCollisionManager.invincibilityTimer > 3.0f && obstacleCollisionManager.invincibilityTimer < 3.1f)
        {
            playerBodyForColorChange.GetComponent<Renderer>().material = normalMaterial;
        }
        if (obstacleCollisionManager.invincibilityTimer > 2.5f && obstacleCollisionManager.invincibilityTimer < 2.6f)
        {
            playerBodyForColorChange.GetComponent<Renderer>().material = hitMaterial;
        }
        if (obstacleCollisionManager.invincibilityTimer > 1.7f && obstacleCollisionManager.invincibilityTimer < 1.8f)
        {
            playerBodyForColorChange.GetComponent<Renderer>().material = normalMaterial;
        }
        if (obstacleCollisionManager.invincibilityTimer > 1.3f && obstacleCollisionManager.invincibilityTimer < 1.4f)
        {
            playerBodyForColorChange.GetComponent<Renderer>().material = hitMaterial;
        }
        if (obstacleCollisionManager.invincibilityTimer > 0.7f && obstacleCollisionManager.invincibilityTimer < 0.8f)
        {
            playerBodyForColorChange.GetComponent<Renderer>().material = normalMaterial;
        }
        if (obstacleCollisionManager.invincibilityTimer > 0.5f && obstacleCollisionManager.invincibilityTimer < 0.6f)
        {
            playerBodyForColorChange.GetComponent<Renderer>().material = hitMaterial;
        }
        if (obstacleCollisionManager.invincibilityTimer > 0.45f && obstacleCollisionManager.invincibilityTimer < 0.5f)
        {
            playerBodyForColorChange.GetComponent<Renderer>().material = normalMaterial;
        }
        if (obstacleCollisionManager.invincibilityTimer > 0.35f && obstacleCollisionManager.invincibilityTimer < 0.4f)
        {
            playerBodyForColorChange.GetComponent<Renderer>().material = hitMaterial;
        }
        if (obstacleCollisionManager.invincibilityTimer > 0.25f && obstacleCollisionManager.invincibilityTimer < 0.3f)
        {
            playerBodyForColorChange.GetComponent<Renderer>().material = normalMaterial;
        }
        if (obstacleCollisionManager.invincibilityTimer > 0.2f && obstacleCollisionManager.invincibilityTimer < 0.25f)
        {
            playerBodyForColorChange.GetComponent<Renderer>().material = hitMaterial;
        }
        if (obstacleCollisionManager.invincibilityTimer > 0.0f && obstacleCollisionManager.invincibilityTimer < 0.1f)
        {
            playerBodyForColorChange.GetComponent<Renderer>().material = normalMaterial;
        }
        //if (obstacleCollisionManager.invincibilityTimer > 2.5f && obstacleCollisionManager.invincibilityTimer < f)
        //{
        //    playerBodyForColorChange.GetComponent<Renderer>().material = hitMaterial;
        //}


        //if (obstacleCollisionManager.invincibilityTimer < 0.1f)
        //{
        //    playerBodyForColorChange.GetComponent<Renderer>().material = normalMaterial;
        //}

    }


    public void ActivatePowerup(Collider other)
    {
        if(other.tag == "PowerupJump")
        {
   
            playerJointsForColorChange.GetComponent<Renderer>().material = redMaterialJump;
            other.transform.Find("Explosion").gameObject.SetActive(true);
            other.GetComponent<MeshRenderer>().enabled = false;
            StartCoroutine(DestroyObject(other));
            collectBingAudio.Play();
            playerController.jumpStrength = 15;

            Invoke("PowerupJumpReturnNormal", 10);

            scoreDisplayText.score += 10;
            scoreDisplayEnding.score += 10;


        }

        if(other.tag == "PowerupSpeed")
        {
            other.GetComponent<SphereCollider>().enabled = false;
            other.transform.Find("Explosion").gameObject.SetActive(true);
            other.GetComponent<MeshRenderer>().enabled = false;
            StartCoroutine(DestroyObject(other));
            collectBingAudio.Play();
            clampSpeedFast = playerController.playerMovementSpeed * 1.5f;
            Mathf.Clamp(clampSpeedFast, 10, 12);
            Debug.Log(clampSpeedFast);
            playerController.playerMovementSpeed = clampSpeedFast;
            playerController.playerMovementSpeed = Mathf.Clamp(playerController.playerMovementSpeed * 1.5f, 10f, 40f);

            Invoke("PowerupSpeedReturnNormal", 5);

            scoreDisplayText.score += 10;
            scoreDisplayEnding.score += 10;
        }

        if (other.tag == "PowerupWallRun")
        {
            other.transform.Find("Explosion").gameObject.SetActive(true);
            other.GetComponent<MeshRenderer>().enabled = false;
            StartCoroutine(DestroyObject(other));
            collectBingAudio.Play();
            obstacleCollisionManager.invincibilityTimer = 1;
            playerController.playerRb.useGravity = false;
            playerController.transform.position = new Vector3(8.0f, playerController.transform.position.y, playerController.transform.position.z);
            playerController.transform.Rotate(new Vector3(0, 0, 90));
            Invoke("PowerupWallRunReturnNormal", 5);

            scoreDisplayText.score += 10;
            scoreDisplayEnding.score += 10;

        }

        if (other.tag == "PowerupInvincibility")
        {
            other.transform.Find("Explosion").gameObject.SetActive(true);
            other.GetComponent<MeshRenderer>().enabled = false;
            StartCoroutine(DestroyObject(other));
            collectBingAudio.Play();

            obstacleCollisionManager.invincibilityTimer = 6;
            //player.GetComponent<Renderer>().material = white;

            //Invoke("PowerupInvincibilityReturnNormal", 10);

            //Invoke("SetInvincibiltyMaterialNormal", 6.5f);
            //Invoke("SetInvincibiltyMaterialWhite", 7.0f); 
            //Invoke("SetInvincibiltyMaterialNormal", 7.5f);
            //Invoke("SetInvincibiltyMaterialWhite", 8.0f);

            //Invoke("SetInvincibiltyMaterialNormal", 8.4f);
            //Invoke("SetInvincibiltyMaterialWhite", 8.7f);
            //Invoke("SetInvincibiltyMaterialNormal", 9.0f);
            //Invoke("SetInvincibiltyMaterialWhite", 9.3f);

            //Invoke("SetInvincibiltyMaterialNormal", 9.6f);
            //Invoke("SetInvincibiltyMaterialWhite", 9.7f);
            //Invoke("SetInvincibiltyMaterialNormal", 9.8f);
            //Invoke("SetInvincibiltyMaterialWhite", 9.9f);

            scoreDisplayText.score += 10;
            scoreDisplayEnding.score += 10;
        }

        if (other.tag == "Collectable")
        {
            other.transform.Find("Explosion").gameObject.SetActive(true);
            other.GetComponent<MeshRenderer>().enabled = false;
            StartCoroutine(DestroyObject(other));
            collectBingAudio.Play();

            scoreDisplayText.score += 100;
            scoreDisplayEnding.score += 100;
        }

        if (other.tag == "Collectable2")
        {
            other.transform.Find("Explosion").gameObject.SetActive(true);
            other.GetComponent<MeshRenderer>().enabled = false;
            StartCoroutine(DestroyObject(other));
            collectBingAudio.Play();

            scoreDisplayText.score += 50;
            scoreDisplayEnding.score += 50;
        }



    }

    private void PowerupSpeedReturnNormal()
    {

        playerController.playerMovementSpeed /= 1.5f;
        playerController.playerMovementSpeed = Mathf.Clamp(playerController.playerMovementSpeed / 2 * 1.5f, 10f, 40f);

    }

    private void PowerupWallRunReturnNormal()
    {
        playerController.playerRb.useGravity = true;
        playerController.transform.Rotate(new Vector3(0, 0, -90));
        playerController.transform.position = new Vector3(0.0f, playerController.transform.position.y, playerController.transform.position.z);
    }

    private void PowerupJumpReturnNormal()
    {
        playerJointsForColorChange.GetComponent<Renderer>().material = normaljointsMaterial;
        playerController.jumpStrength = 12;
    }

    public IEnumerator DestroyObject(Collider other)
    {
        yield return new WaitForSeconds(1);
        Destroy(other.gameObject);
        Debug.Log("Destroyed");
    }

}
