using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeftRight : MonoBehaviour
{


    public bool left = true, right = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    
        if(left == true)
        {

            transform.Translate(new Vector3(-2 *Time.deltaTime,0,0));



            if(transform.position.x <= -4)
            {
                left = false;
                right = true;
            }


        }

        if(right == true)
        {


            transform.Translate(new Vector3(2 * Time.deltaTime, 0, 0));



            if (transform.position.x >= 4)
            {
                left = true;
                right = false;
            }

        }




    }

}
