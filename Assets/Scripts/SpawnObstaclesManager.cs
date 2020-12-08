using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SpawnObstaclesManager : MonoBehaviour
{

    public List<GameObject[]> obstacles;
    private List<GameObject> visibleObstacles;
    public GameObject[] levelOneObstacles;
    public GameObject[] levelTwoObstacles;
    public GameObject[] levelThreeObstacles;
    public GameObject[] levelFourObstacles;

    private int levelLength = 200;
    private float spawnPositionZ = 20;

    private LevelManager levelManager;
    private PlayerController playerController;
    

    // Start is called before the first frame update
    void Start()
    {
        levelManager = GameObject.Find("LevelManager").GetComponent<LevelManager>();
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();

        obstacles = new List<GameObject[]>();
        obstacles.Add(levelOneObstacles);
        obstacles.Add(levelOneObstacles);
        obstacles.Add(levelTwoObstacles);
        obstacles.Add(levelThreeObstacles);
        obstacles.Add(levelFourObstacles);

        visibleObstacles = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        if (spawnPositionZ <= levelLength*levelManager.playerLevel)
        {
            SpawnObstacle();
            DestroyFirstObstacle();
        }
    }


    private void SpawnObstacle()
    {
        int rand = Random.Range(0, obstacles[levelManager.playerLevel].Length);
        visibleObstacles.Add(Instantiate(obstacles[levelManager.playerLevel][rand], new Vector3(0,1.5f,spawnPositionZ), obstacles[levelManager.playerLevel][rand].transform.rotation));
        spawnPositionZ += 10;
    }

    // Remove first obstacle if unvisible
    private void DestroyFirstObstacle()
    {
        if (visibleObstacles != null && visibleObstacles.Count > 0)
        {
            GameObject firstObstacle = visibleObstacles.First();
            if (firstObstacle.transform.position.z < playerController.playerZPosition - 10)
            {
                visibleObstacles.Remove(firstObstacle);
                Destroy(firstObstacle);
            }
        }
    }
}
