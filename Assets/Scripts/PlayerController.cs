using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float playerZPosition;

    public float playerMovementSpeed; //= 10;
    public float jumpStrength = 12;
    public float jumpVelocity = 150f;


    public Vector3 forward;

    public float playerStrafeSpeed = 7;
    private float horizontalInput;

    public bool jump = false;
    public bool jumpBlocking = false;

    public Rigidbody playerRb;

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

    public GameObject player;

    public ParticleSystem dustExplosion;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");

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

        dustExplosion.Stop();

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


            //if (horizontalInput == 0)
            //{
            //    Debug.Log(player.transform.rotation.z);
            //    if (player.transform.rotation.z > 0.0f)
            //    {
            //        player.transform.Rotate(new Vector3(0, 0, -0.1f));
            //        Debug.Log("Ich drehe rechts");

            //    }
            //    if (player.transform.rotation.z < 0.0f)
            //    {
            //        player.transform.Rotate(new Vector3(0, 0, 0.1f));
            //        Debug.Log("Ich drehe links");
            //    }
            //}
            //if (horizontalInput == 1)
            //{
            //    //right
            //    if (player.transform.rotation.z < 0.025f)
            //    {
            //        player.transform.Rotate(new Vector3(0, 0, -0.5f));
            //    }
            //}
            //if (horizontalInput == -1)
            //{
            //    //left
            //    if (player.transform.rotation.z > -0.025f)
            //    {
            //        player.transform.Rotate(new Vector3(0, 0, 0.5f));
            //    }
            //}
            //Debug.Log(player.transform.rotation.z);



            HorizontalMovement(horizontalInput);
        }

        Vector3 newPos = new Vector3(Mathf.Clamp(transform.position.x, -4.5f, 4.5f), Mathf.Clamp(transform.position.y, 0.0f, 6.0f), transform.position.z);
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
        if (jump == false && jumpBlocking == false)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                playerRb.AddForce(new Vector3(0, jumpStrength, 0), ForceMode.Impulse);

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




    
