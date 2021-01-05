using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float playerZPosition;

    public float playerMovementSpeed = 10;
    public float jumpVelocity = 150f;

    public float playerStrafeSpeed = 7;
    private float horizontalInput;

    public bool jump = false;

    private Rigidbody playerRb;

    private SplitManager splitManager;
    private PowerupManager powerupManager;
    private ObstacleCollisionManager obstacleCollisionManager;

    public GameObject trail1;
    public GameObject trail2;

    public Animator animator;


    // Start is called before the first frame update
    void Start()
    {
        trail1.SetActive(false);
        trail2.SetActive(false);


        playerRb = GetComponent<Rigidbody>();
        splitManager = GameObject.Find("SplitManager").GetComponent<SplitManager>();
        powerupManager = GameObject.Find("PowerupManager").GetComponent<PowerupManager>();
        obstacleCollisionManager = GameObject.Find("ObstacleCollisionManager").GetComponent<ObstacleCollisionManager>();
    }

    // Update is called once per frame
    void Update()
    {



        playerZPosition = transform.position.z;

        Vector3 forward = Vector3.forward * Time.deltaTime * playerMovementSpeed;

        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * playerStrafeSpeed + forward); 

        Vector3 newPos = new Vector3(Mathf.Clamp(transform.position.x, -4.5f, 4.5f),transform.position.y,transform.position.z);
        transform.position = newPos;

        if (jump == false)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                playerRb.AddForce(new Vector3(0, 12, 0), ForceMode.Impulse);

            }
        }
    
        animator.SetFloat("JumpVelocity", playerRb.velocity.y);
    }


    public void OnTriggerEnter(Collider other)
    {

        splitManager.SetNextLevel(other);

        powerupManager.ActivatePowerup(other);

        obstacleCollisionManager.ObstacleCollision(other);

    }




}




    
