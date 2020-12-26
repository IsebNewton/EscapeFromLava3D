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
    private int firstObstacleInLevelPosition = 20;
    public float obstacleDistance;
    private int splitDifference = 10;

    private LevelManager levelManager;
    private PlayerController playerController;
    private int currentPlayerLevel = -1;

    public DifficulyManager difficulyManager;
    public float startDifficulty = 1;
    public float difficulty;


    // Start is called before the first frame update
    void Start()
    {
        levelManager = GameObject.Find("LevelManager").GetComponent<LevelManager>();
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        difficulyManager = GameObject.FindGameObjectWithTag("DifficultyManager").GetComponent<DifficulyManager>();

        startDifficulty = difficulyManager.difficulty;

        

        obstacles = new List<GameObject[]>();
        obstacles.Add(levelOneObstacles);
        obstacles.Add(levelTwoObstacles);
        obstacles.Add(levelThreeObstacles);
        obstacles.Add(levelFourObstacles);
        obstacles.Add(levelFourObstacles);

        visibleObstacles = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {

        difficulty = (levelManager.difLevel * 0.25f) * startDifficulty;


        if (currentPlayerLevel != levelManager.playerLevel)
        {
            currentPlayerLevel = levelManager.playerLevel;
            DestroyAllVisibleObstacles();
            SpawnObstaclesForLevel(currentPlayerLevel);
        }

        obstacleDistance = 10 - difficulty;
    }
    private void SpawnObstaclesForLevel(int level)
    {
        GameObject[] currentLevelObstacles = obstacles[level];
        for (float i = (int)playerController.playerZPosition + firstObstacleInLevelPosition; i < playerController.playerZPosition + levelLength - splitDifference; i+= obstacleDistance)
        {
            int rand = Random.Range(0, currentLevelObstacles.Length);
            int randX = Random.Range(-5, 5);
            visibleObstacles.Add(Instantiate(currentLevelObstacles[rand], new Vector3(randX, 1.5f, i), currentLevelObstacles[rand].transform.rotation));
        }
    }

    private void DestroyAllVisibleObstacles()
    {
        for (int i = 0; i < visibleObstacles.Count; i++)
        {
            GameObject firstObstacle = visibleObstacles.First();
            visibleObstacles.Remove(firstObstacle);
            Destroy(firstObstacle);
        }
    }




}
