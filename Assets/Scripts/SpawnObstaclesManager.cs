using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SpawnObstaclesManager : MonoBehaviour
{

    public List<GameObject[]> obstacles;
    private List<GameObject> visibleObstacles;
    public GameObject[] levelOneObstacles;//Black, Normal Level
    public GameObject[] levelTwoObstacles;//Black, Normal Level
    public GameObject[] levelThreeObstacles;//Black, Normal Level

    public GameObject[] levelFourObstacles;//Brown, Hard Level

    public GameObject[] levelFiveObstacles;//Brown, Normal Level
    public GameObject[] levelSixObstacles;//Brown, Normal Level

    public GameObject[] levelSevenObstacles;//Brown?, Stollen Normal Level
    public GameObject[] levelEigthObstacles;//Brown?, Stollen Normal Level
    public GameObject[] levelNineObstacles;//Brown?, Stollen Normal Level

    public GameObject[] levelTenObstacles;//Farbe?, Viele Steinfallen, Hard Level

    public GameObject[] levelElevenObstacles;//Farbe? feste Lava, paar Steinfallen und bisschen Lava, Normal Level

    public GameObject[] levelTwelveObstacles;//Farbe?, Viele Steinfallen, Hard Level

    public GameObject[] levelThirteenObstacles;//Farbe? feste Lava, paar Steinfallen und bisschen Lava, Normal Level

    public GameObject[] levelFourteenObstacles;//Black Lava Mäßig, viel Lava, Normale Level
    public GameObject[] levelFifteenObstacles;//Black Lava Mäßig, viel Lava, Normale Level
    public GameObject[] levelSixteenObstacles;//Black Lava Mäßig, viel Lava, Normale Level

    public GameObject[] levelSeventeenObstacles;//Dunkel, Pilze, Pilzleuchtend, Normal Level
    public GameObject[] levelEigthteenObstacles;//Dunkel, Pilze, Pilzleuchtend, Normal Level
    public GameObject[] levelNineteenObstacles;//Dunkel, Pilze, Pilzleuchtend, Normal Level

    public GameObject[] levelTwentyObstacles;//Farbe?, Lava und Pilze, Normal Level
    public GameObject[] levelTwentyoneObstacles;//Farbe?, Lava und Pilze, Normal Level

    public GameObject[] levelTwentytwoObstacles;//Farbe?, Dunkel, Hard Level

    public GameObject[] levelTwentythreeObstacles;//Farbe?, Lava und Pilze, Normal Level

    public GameObject[] levelTwentyfourObstacles;//??
    public GameObject[] levelTwentyfiveObstacles;//??
    public GameObject[] levelTwentysixObstacles;//??

    public GameObject[] levelTwentysevenObstacles;//Hellgrau, Steinfall, Normal Level
    public GameObject[] levelTwentyeigthObstacles;//Hellgrau, Steinfall, Normal Level

    public GameObject[] levelTwentynineObstacles;//Hellgrau, Grasfarbig, Normal Level
    public GameObject[] levelThirtyObstacles;//Hellgrau, Grasfarbig, Normal Level


    private int levelLength = 200;
    private int firstObstacleInLevelPosition = 20;
    public float obstacleDistance;
    private int splitDifference = 10;

    private LevelManager levelManager;
    private SpawnPowerupsManager spawnPowerupsManager;
    private PlayerController playerController;
    private int currentPlayerLevel = -1;

    public DifficultyManager difficultyManager;
    public float startDifficulty = 1;
    public float difficulty;

    public bool spawned = false;

    // Start is called before the first frame update
    void Start()
    {
 
        levelManager = GameObject.Find("LevelManager").GetComponent<LevelManager>();
        spawnPowerupsManager = GameObject.Find("SpawnPowerupsManager").GetComponent<SpawnPowerupsManager>();
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        difficultyManager = DifficultyManager.Instance;

        startDifficulty = difficultyManager.difficulty;

        Debug.Log("difficulty: " + startDifficulty);



        obstacles = new List<GameObject[]>();
        obstacles.Add(levelOneObstacles);
        obstacles.Add(levelTwoObstacles);
        obstacles.Add(levelThreeObstacles);
        obstacles.Add(levelFourObstacles);
        obstacles.Add(levelFiveObstacles);
        obstacles.Add(levelSixObstacles);
        obstacles.Add(levelSevenObstacles);
        obstacles.Add(levelEigthObstacles);
        obstacles.Add(levelNineObstacles);
        obstacles.Add(levelTenObstacles);
        obstacles.Add(levelElevenObstacles);
        obstacles.Add(levelTwelveObstacles);
        obstacles.Add(levelThirteenObstacles);
        obstacles.Add(levelFourteenObstacles);
        obstacles.Add(levelFifteenObstacles);
        obstacles.Add(levelSixteenObstacles);
        obstacles.Add(levelSeventeenObstacles);
        obstacles.Add(levelEigthteenObstacles);
        obstacles.Add(levelNineteenObstacles);
        obstacles.Add(levelTwentyObstacles);
        obstacles.Add(levelTwentyObstacles);
        obstacles.Add(levelTwentyObstacles);
        obstacles.Add(levelTwentyObstacles);
        obstacles.Add(levelTwentyObstacles);
        obstacles.Add(levelTwentyObstacles);
        obstacles.Add(levelTwentyObstacles);
        obstacles.Add(levelTwentyObstacles);
        obstacles.Add(levelTwentyObstacles);
        obstacles.Add(levelTwentyObstacles);
        obstacles.Add(levelThirtyObstacles);



        visibleObstacles = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {

        difficulty = ((levelManager.difLevel * 0.25f) * startDifficulty) * levelManager.hardLevel;

        obstacleDistance = 15 - difficulty;
        Mathf.Clamp(obstacleDistance, 3f, 15f);

        if (currentPlayerLevel != levelManager.playerLevel)
        {
            currentPlayerLevel = levelManager.playerLevel;
            if (spawned == false)
            {
                
                DestroyAllVisibleObstacles();
                SpawnObstaclesForLevel(currentPlayerLevel);
                Debug.Log("Aufruf Test");
                spawnPowerupsManager.DestroyAllVisiblePowerups();
                spawnPowerupsManager.SpawnPowerupsForLevel(levelLength);
                spawned = true;
                Invoke("SetSpawnedFalse", 2f);
            }
        }


        
    }
    private void SpawnObstaclesForLevel(int level)
    {
        if (obstacles != null && obstacles.Count > level)
        {
            GameObject[] currentLevelObstacles = obstacles[level];

            for (float i = (int)playerController.playerZPosition + firstObstacleInLevelPosition; i < playerController.playerZPosition + levelLength - splitDifference; i += obstacleDistance)
            {
                int rand = Random.Range(0, currentLevelObstacles.Length);
                int randX = Random.Range(-5, 5);
                visibleObstacles.Add(Instantiate(currentLevelObstacles[rand], new Vector3(randX, 1.5f, i), currentLevelObstacles[rand].transform.rotation));
            }
        }
    }

    private void DestroyAllVisibleObstacles()
    {
        if (visibleObstacles != null)
        {
            for (int i = 0; i < visibleObstacles.Count; i++)
            {
                GameObject firstObstacle = visibleObstacles.First();
                visibleObstacles.Remove(firstObstacle);
                Destroy(firstObstacle);
            }
        }
    }

    public void SetSpawnedFalse()
    {
        spawned = false;
    }


}
