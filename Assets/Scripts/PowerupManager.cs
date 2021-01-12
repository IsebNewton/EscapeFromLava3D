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

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        obstacleCollisionManager = GameObject.Find("ObstacleCollisionManager").GetComponent<ObstacleCollisionManager>();
        clampSpeedFast = 20;
        clampSpeedSlow = 10;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void ActivatePowerup(Collider other)
    {

        if(other.tag == "PowerupSpeed")
        {
            Destroy(other.gameObject);
            clampSpeedFast = playerController.playerMovementSpeed * 1.5f;
            Mathf.Clamp(clampSpeedFast, 10, 12);
            Debug.Log(clampSpeedFast);
            playerController.playerMovementSpeed = clampSpeedFast;

            playerController.trail1.SetActive(true);
            playerController.trail2.SetActive(true);
            Invoke("PowerupSpeedReturnNormal", 5);

        }


        if (other.tag == "PowerupInvincibility")
        {
            Destroy(other.gameObject);

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
        playerController.trail1.SetActive(false);
        playerController.trail2.SetActive(false);
    }



    //private void PowerupInvincibilityReturnNormal()
    //{ 
    //    obstacleCollisionManager.invulnerability = false;
    //    Debug.Log("Yes");
    //    player.GetComponent<Renderer>().material = original;
    //}



    //private void SetInvincibiltyMaterialNormal()
    //{
    //    player.GetComponent<Renderer>().material = original;
    //}
    //private void SetInvincibiltyMaterialWhite()
    //{
    //    player.GetComponent<Renderer>().material = white;
    //}


}
