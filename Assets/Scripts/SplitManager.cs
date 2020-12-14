using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplitManager : MonoBehaviour
{
    private GameObject player;
    private LevelManager levelManager;
    public float grenze = 0;
    public GameObject split;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        levelManager = GameObject.Find("LevelManager").GetComponent<LevelManager>();
    }

    // Update is called once per frame
    void Update()
    {

        if (player.transform.position.z > grenze)
        {
            Instantiate(split, new Vector3(0, 5, grenze + 195), split.transform.rotation);
            grenze += 200;
            Debug.Log("Yes");
        }


    }



    public void SetNextLevel(Collider other)
    {

        if(other.tag == "SplitLeft")
        {
            if(levelManager.playerLevel == 1)
            {
                //Do Nothing, load level 2

            }









        }

        if (other.tag == "SplitRight")
        {
            if (levelManager.playerLevel == 1)
            {
                levelManager.playerLevel = 2;

            }









        }

    }


}
