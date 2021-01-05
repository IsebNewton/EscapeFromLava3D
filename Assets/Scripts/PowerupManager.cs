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

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        obstacleCollisionManager = GameObject.Find("ObstacleCollisionManager").GetComponent<ObstacleCollisionManager>();

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
            playerController.playerMovementSpeed *= 2;
            playerController.trail1.SetActive(true);
            playerController.trail2.SetActive(true);
            Invoke("PowerupSpeedReturnNormal", 5);

        }


        if (other.tag == "PowerupInvincibility")
        {
            Destroy(other.gameObject);

            obstacleCollisionManager.invulnerability = true;
            player.GetComponent<Renderer>().material = white;

            Invoke("PowerupInvincibilityReturnNormal", 10);

            Invoke("SetInvincibiltyMaterialNormal", 6.5f);
            Invoke("SetInvincibiltyMaterialWhite", 7.0f); 
            Invoke("SetInvincibiltyMaterialNormal", 7.5f);
            Invoke("SetInvincibiltyMaterialWhite", 8.0f);

            Invoke("SetInvincibiltyMaterialNormal", 8.4f);
            Invoke("SetInvincibiltyMaterialWhite", 8.7f);
            Invoke("SetInvincibiltyMaterialNormal", 9.0f);
            Invoke("SetInvincibiltyMaterialWhite", 9.3f);

            Invoke("SetInvincibiltyMaterialNormal", 9.6f);
            Invoke("SetInvincibiltyMaterialWhite", 9.7f);
            Invoke("SetInvincibiltyMaterialNormal", 9.8f);
            Invoke("SetInvincibiltyMaterialWhite", 9.9f);
        }


    }

    private void PowerupSpeedReturnNormal()
    {
        playerController.playerMovementSpeed /= 2;
        playerController.trail1.SetActive(false);
        playerController.trail2.SetActive(false);
    }



    private void PowerupInvincibilityReturnNormal()
    { 
        obstacleCollisionManager.invulnerability = false;
        Debug.Log("Yes");
        player.GetComponent<Renderer>().material = original;
    }
    private void SetInvincibiltyMaterialNormal()
    {
        player.GetComponent<Renderer>().material = original;
    }
    private void SetInvincibiltyMaterialWhite()
    {
        player.GetComponent<Renderer>().material = white;
    }


}
