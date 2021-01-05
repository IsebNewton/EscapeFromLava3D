using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowingLava : MonoBehaviour
{

    public Vector3 offset;
    public GameObject player;
    public ProgressBar progressBar;

    public float distance;



    // Start is called before the first frame update
    void Start()
    {
        progressBar = GameObject.Find("ProgressBar").GetComponent<ProgressBar>();
    }

    // Update is called once per frame
    void Update()
    {

        float difference = progressBar.playerCurrent - progressBar.lavaCurrent;


        //Falls Formel einfällt, ersetzen
        if(difference < 0.1)
        {
            distance = 0;
        }
        if(difference > 0.1 && difference < 0.2)
        {
            distance = 0.2f;
        }
        if (difference > 0.2 && difference < 0.4)
        {
            distance = 0.4f;
        }
        if (difference > 0.4 && difference < 0.6)
        {
            distance = 0.6f;
        }
        if (difference > 0.6 && difference < 1)
        {
            distance = 0.8f;
        }
        if (difference > 1 && difference < 1.5)
        {
            distance = 1;
        }
        if (difference > 1.5 && difference < 2)
        {
            distance = 1.3f;
        }
        //if (difference > 2 && difference < 2.5)
        //{
        //    distance = 1.7f;
        //}
        //if (difference > 2.5 && difference < 3.5)
        //{
        //    distance = 2.3f;
        //}
        //if (difference > 3.5 && difference < 4.5)
        //{
        //    distance = 3;
        //}
        //if (difference > 4.5 && difference < 6)
        //{
        //    distance = 4;
        //}
        if (difference > 2)
        {
            distance = 2;
        }

       



        transform.position = new Vector3(0, 0, player.transform.position.z + offset.z - distance); //player.transform.position + offset;
    }
}
