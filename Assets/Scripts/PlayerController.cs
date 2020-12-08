using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float playerZPosition;

    public float playerMovementSpeed = 10;
    public float jumpVelocity;

    public float playerStrafeSpeed = 7;
    private float horizontalInput;

    private bool touchingWall = false;
    public bool jump = false;

    private Rigidbody playerRb;
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        playerZPosition = transform.position.z;

        Vector3 forward = Vector3.forward * Time.deltaTime * playerMovementSpeed;

            horizontalInput = Input.GetAxis("Horizontal");
            transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * playerStrafeSpeed + forward); //Vector von push forward einfach addieren, X variable anlegen und clampen und diese dann einsetzen

        Vector3 newPos = new Vector3(Mathf.Clamp(transform.position.x, -4.5f, 4.5f),transform.position.y,transform.position.z);
        transform.position = newPos;

        if(jump == false)
        if (Input.GetKeyDown(KeyCode.Space))
        {
            playerRb.AddForce(Vector3.up * jumpVelocity, ForceMode.Impulse);
            jump = true;
        }
        if(transform.position.y <= 0.5)
        {
            jump = false;
        }

    }

}




    
