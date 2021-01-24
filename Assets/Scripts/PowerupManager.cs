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

    public GameObject collectBingObject;
    public AudioSource collectBingAudio;

    public ParticleSystem explosion;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        obstacleCollisionManager = GameObject.Find("ObstacleCollisionManager").GetComponent<ObstacleCollisionManager>();
        clampSpeedFast = 20;
        clampSpeedSlow = 10;

        collectBingAudio = collectBingObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if(playerController.playerMovementSpeed > 12)
        {
            playerController.trail1.SetActive(true);
            playerController.trail2.SetActive(true);
        }
        if (playerController.playerMovementSpeed < 12)
        {
            playerController.trail1.SetActive(false);
            playerController.trail2.SetActive(false);
        }

        if(obstacleCollisionManager.invincibilityTimer > 0.1f)
        {
            playerBodyForColorChange.GetComponent<Renderer>().material = hitMaterial;
        }
        if (obstacleCollisionManager.invincibilityTimer < 0.1f)
        {
            playerBodyForColorChange.GetComponent<Renderer>().material = normalMaterial;
        }

    }


    public void ActivatePowerup(Collider other)
    {
        if(other.tag == "PowerupJump")
        {
            
            other.transform.Find("Explosion").gameObject.SetActive(true);
            other.GetComponent<MeshRenderer>().enabled = false;
            StartCoroutine(DestroyObject(other));
            collectBingAudio.Play();
            playerController.jumpStrength = 15;

            Invoke("PowerupJumpReturnNormal", 5);

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

        }

        if (other.tag == "PowerupWallRun")
        {
            other.transform.Find("Explosion").gameObject.SetActive(true);
            other.GetComponent<MeshRenderer>().enabled = false;
            StartCoroutine(DestroyObject(other));
            collectBingAudio.Play();
            obstacleCollisionManager.invincibilityTimer = 1;
            playerController.playerRb.useGravity = false;
            playerController.transform.position = new Vector3(7.0f, playerController.transform.position.y, playerController.transform.position.z);
            playerController.transform.Rotate(new Vector3(0, 0, 90));
            Invoke("PowerupWallRunReturnNormal", 5);
        }

        if (other.tag == "PowerupInvincibility")
        {
            other.transform.Find("Explosion").gameObject.SetActive(true);
            other.GetComponent<MeshRenderer>().enabled = false;
            StartCoroutine(DestroyObject(other));
            collectBingAudio.Play();

            obstacleCollisionManager.invincibilityTimer = 5;
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
        
        playerController.jumpStrength = 12;
    }

    public IEnumerator DestroyObject(Collider other)
    {
        yield return new WaitForSeconds(1);
        Destroy(other.gameObject);
        Debug.Log("Destroyed");
    }

}
