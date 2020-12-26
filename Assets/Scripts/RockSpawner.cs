using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockSpawner : MonoBehaviour
{

    public GameObject rock;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnRock", 0.0f, 0.2f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void SpawnRock()
    {
        float pos = transform.position.x;

        float rand = Random.Range(pos - 1.5f, pos + 1.5f);
        Instantiate(rock,new Vector3(rand,transform.position.y,transform.position.z),transform.rotation);

    }


}
