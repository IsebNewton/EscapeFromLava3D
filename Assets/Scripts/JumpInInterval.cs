using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpInInterval : MonoBehaviour
{

    private Rigidbody rb;


    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        InvokeRepeating("Jump", 2.0f, 3.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Jump()
    {
        rb.AddForce(new Vector3(0, 7, 0), ForceMode.Impulse);
    }



}
