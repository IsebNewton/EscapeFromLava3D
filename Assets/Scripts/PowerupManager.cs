using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupManager : MonoBehaviour
{

    private PlayerController playerController;

    // Start is called before the first frame update
    void Start()
    {

        playerController = GameObject.Find("Player").GetComponent<PlayerController>();

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
            Invoke("PowerupSpeedReturnNormal", 5);

           

        }

    }

    private void PowerupSpeedReturnNormal()
    {
        playerController.playerMovementSpeed /= 2;
    }


}
