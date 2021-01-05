using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsTouchingGround : MonoBehaviour
{
    public PlayerController playerController;
    // Start is called before the first frame update
    void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Ground")
        {
            playerController.jump = false;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.tag == "Ground")
        {
            playerController.jump = true;
        }
    }

}
