using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float playerZPosition;

    public float playerMovementSpeed = 10;
    public float jumpVelocity = 150f;

    public Vector3 forward;

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

    public bool onAndroid;

    public GameObject jump1Object;
    public GameObject jump2Object;

    public AudioSource jump1Audio;
    public AudioSource jump2Audio;


    // Start is called before the first frame update
    void Start()
    {
        trail1.SetActive(false);
        trail2.SetActive(false);

        onAndroid = false;

#if UNITY_ANDROID
        onAndroid = true;
#endif

        playerRb = GetComponent<Rigidbody>();
        splitManager = GameObject.Find("SplitManager").GetComponent<SplitManager>();
        powerupManager = GameObject.Find("PowerupManager").GetComponent<PowerupManager>();
        obstacleCollisionManager = GameObject.Find("ObstacleCollisionManager").GetComponent<ObstacleCollisionManager>();

        jump1Audio = jump1Object.GetComponent<AudioSource>();
        jump2Audio = jump2Object.GetComponent<AudioSource>();

    }

    // Update is called once per frame
    public void Update()
    {

        playerMovementSpeed = Mathf.Clamp(playerMovementSpeed, 0f, 40f);

        playerZPosition = transform.position.z;

        forward = Vector3.forward * Time.deltaTime * playerMovementSpeed;

        if (onAndroid == false)
        {
            horizontalInput = Input.GetAxis("Horizontal");
            HorizontalMovement(horizontalInput);
        }

        Vector3 newPos = new Vector3(Mathf.Clamp(transform.position.x, -4.5f, 4.5f),transform.position.y,transform.position.z);
        transform.position = newPos;

        if (onAndroid == false)
        {
            Jump();
        }

        animator.SetFloat("JumpVelocity", playerRb.velocity.y);
    }


    public void OnTriggerEnter(Collider other)
    {

        splitManager.SetNextLevel(other);

        powerupManager.ActivatePowerup(other);

        obstacleCollisionManager.ObstacleCollision(other);

    }

    public void HorizontalMovement(float horizontalInput)
    {
        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * playerStrafeSpeed + forward);
    }

    public void Jump()
    {
        if (jump == false)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                playerRb.AddForce(new Vector3(0, 12, 0), ForceMode.Impulse);

                float rand = Random.Range(1, 10);
                if (rand <= 5)
                {
                    jump1Audio.Play();
                }
                else if(rand >5)
                {
                    jump2Audio.Play();
                }
  
            }
        }
    }

}




    
