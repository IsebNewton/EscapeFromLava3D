using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{

    public GameObject player;
    public Vector3 offset = new Vector3(0, 3, -4);

    public float positionX;
    public float positionY;
    public float positionZ;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (player.transform.position.x < -4)
        {
            positionX = -4 + offset.x;
        }
        else if (player.transform.position.x > 4)
        {
            positionX = 4 + offset.x;
        }
        else
        {
            positionX = player.transform.position.x + offset.x;
        }

        if(player.transform.position.y < 3)
        {
            positionY = player.transform.position.y + offset.y;
        }
        else
        {
            positionY = 3 + offset.y;
        }
            
        float positionZ = player.transform.position.z + offset.z;

        transform.position = new Vector3(positionX,positionY,positionZ);//player.transform.position + offset;
    }
}
