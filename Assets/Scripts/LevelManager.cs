using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{

    private GameObject player;
    public int playerLevel = 1;
    public GameObject[] levels;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
         
        if(player.transform.position.z >= (playerLevel * 100) * 2)
        {
            playerLevel++;
            Object.Instantiate(levels[playerLevel-1], new Vector3(0, 0, (playerLevel*100) * 2), levels[playerLevel].transform.rotation);
        }


    }
}
