using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SpawnObstaclesManager : MonoBehaviour
{

    public List<GameObject[]> obstacles;
    public List<GameObject[]> obstaclesAlternative;
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
    public GameObject[] levelThirteenObstacles;//Farbe? feste Lava, paar Steinfallen und bisschen Lava, Normal Leve
    public GameObject[] levelFourteenObstacles;//Black Lava Mäßig, viel Lava, Normale Level
    public GameObject[] levelFifteenObstacles;//Black Lava Mäßig, viel Lava, Normale Level
    public GameObject[] levelSixteenObstacles;//Black Lava Mäßig, viel Lava, Normale Level
    public GameObject[] levelSeventeenObstacles;//Dunkel, Pilze, Pilzleuchtend, Normal Level
    public GameObject[] levelEigthteenObstacles;//Dunkel, Pilze, Pilzleuchtend, Normal Level
    public GameObject[] levelNineteenObstacles;//Dunkel, Pilze, Pilzleuchtend, Normal Level
    public GameObject[] levelTwentyObstacles;//Farbe?, Lava und Pilze, Normal Level
    public GameObject[] levelTwentyoneObstacles;//Farbe?, Lava und Pilze, Normal Level
    public GameObject[] levelTwentytwoObstacles;//Farbe?, Dunkel, Hard Leve
    public GameObject[] levelTwentythreeObstacles;//Farbe?, Lava und Pilze, Normal Level
    public GameObject[] levelTwentyfourObstacles;//??
    public GameObject[] levelTwentyfiveObstacles;//??
    public GameObject[] levelTwentysixObstacles;//??
    public GameObject[] levelTwentysevenObstacles;//Hellgrau, Steinfall, Normal Level
    public GameObject[] levelTwentyeigthObstacles;//Hellgrau, Steinfall, Normal Level
    public GameObject[] levelTwentynineObstacles;//Hellgrau, Grasfarbig, Normal Level
    public GameObject[] levelThirtyObstacles;//Hellgrau, Grasfarbig, Normal Level


    public GameObject[] levelOneObstaclesAlternative;
    public GameObject[] levelTwoObstaclesAlternative;
    public GameObject[] levelThreeObstaclesAlternative;
    public GameObject[] levelFourObstaclesAlternative;
    public GameObject[] levelFiveObstaclesAlternative;
    public GameObject[] levelSixObstaclesAlternative;
    public GameObject[] levelSevenObstaclesAlternative;
    public GameObject[] levelEigthObstaclesAlternative;
    public GameObject[] levelNineObstaclesAlternative;
    public GameObject[] levelTenObstaclesAlternative;
    public GameObject[] levelElevenObstaclesAlternative;
    public GameObject[] levelTwelveObstaclesAlternative;
    public GameObject[] levelThirteenObstaclesAlternative;
    public GameObject[] levelFourteenObstaclesAlternative;
    public GameObject[] levelFifteenObstaclesAlternative;
    public GameObject[] levelSixteenObstaclesAlternative;
    public GameObject[] levelSeventeenObstaclesAlternative;
    public GameObject[] levelEigthteenObstaclesAlternative;
    public GameObject[] levelNineteenObstaclesAlternative;
    public GameObject[] levelTwentyObstaclesAlternative;
    public GameObject[] levelTwentyoneObstaclesAlternative;
    public GameObject[] levelTwentytwoObstaclesAlternative;
    public GameObject[] levelTwentythreeObstaclesAlternative;
    public GameObject[] levelTwentyfourObstaclesAlternative;
    public GameObject[] levelTwentyfiveObstaclesAlternative;
    public GameObject[] levelTwentysixObstaclesAlternative;
    public GameObject[] levelTwentysevenObstaclesAlternative;
    public GameObject[] levelTwentyeigthObstaclesAlternative;
    public GameObject[] levelTwentynineObstaclesAlternative;
    public GameObject[] levelThirtyObstaclesAlternative;


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


        obstaclesAlternative = new List<GameObject[]>();
        obstaclesAlternative.Add(levelOneObstaclesAlternative);
        obstaclesAlternative.Add(levelTwoObstaclesAlternative);
        obstaclesAlternative.Add(levelThreeObstaclesAlternative);
        obstaclesAlternative.Add(levelFourObstaclesAlternative);
        obstaclesAlternative.Add(levelFiveObstaclesAlternative);
        obstaclesAlternative.Add(levelSixObstaclesAlternative);
        obstaclesAlternative.Add(levelSevenObstaclesAlternative);
        obstaclesAlternative.Add(levelEigthObstaclesAlternative);
        obstaclesAlternative.Add(levelNineObstaclesAlternative);
        obstaclesAlternative.Add(levelTenObstaclesAlternative);
        obstaclesAlternative.Add(levelElevenObstaclesAlternative);
        obstaclesAlternative.Add(levelTwelveObstaclesAlternative);
        obstaclesAlternative.Add(levelThirteenObstaclesAlternative);
        obstaclesAlternative.Add(levelFourteenObstaclesAlternative);
        obstaclesAlternative.Add(levelFifteenObstaclesAlternative);
        obstaclesAlternative.Add(levelSixteenObstaclesAlternative);
        obstaclesAlternative.Add(levelSeventeenObstaclesAlternative);
        obstaclesAlternative.Add(levelEigthteenObstaclesAlternative);
        obstaclesAlternative.Add(levelNineteenObstaclesAlternative);
        obstaclesAlternative.Add(levelTwentyObstaclesAlternative);
        obstaclesAlternative.Add(levelTwentyObstaclesAlternative);
        obstaclesAlternative.Add(levelTwentyObstaclesAlternative);
        obstaclesAlternative.Add(levelTwentyObstaclesAlternative);
        obstaclesAlternative.Add(levelTwentyObstaclesAlternative);
        obstaclesAlternative.Add(levelTwentyObstaclesAlternative);
        obstaclesAlternative.Add(levelTwentyObstaclesAlternative);
        obstaclesAlternative.Add(levelTwentyObstaclesAlternative);
        obstaclesAlternative.Add(levelTwentyObstaclesAlternative);
        obstaclesAlternative.Add(levelTwentyObstaclesAlternative);
        obstaclesAlternative.Add(levelThirtyObstaclesAlternative);



        visibleObstacles = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {

        difficulty = ((levelManager.difLevel * 0.25f) * startDifficulty) * levelManager.hardLevel;

        obstacleDistance = 15 - difficulty;
        obstacleDistance = Mathf.Clamp(obstacleDistance, 3f, 15f);

        if (currentPlayerLevel != levelManager.playerLevel)
        {
            currentPlayerLevel = levelManager.playerLevel;
            if (spawned == false)
            {
                
                DestroyAllVisibleObstacles();
                SpawnObstaclesForLevel(currentPlayerLevel-1);
                
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
            //GameObject[] currentLevelObstacles = obstacles[level];
            if (levelManager.alternateLevel == false) {
                GameObject[] currentLevelObstacles = obstacles[level];


                for (float i = (int)playerController.playerZPosition + firstObstacleInLevelPosition; i < playerController.playerZPosition + levelLength - splitDifference; i += obstacleDistance)
                {
                    int rand = Random.Range(0, currentLevelObstacles.Length);
                    float randX = Random.Range(-4.5f, 4.5f);
                    visibleObstacles.Add(Instantiate(currentLevelObstacles[rand], new Vector3(randX, 1.5f, i), currentLevelObstacles[rand].transform.rotation));
                  
                }

            }
            if (levelManager.alternateLevel == true)
            {
                GameObject[] currentLevelObstacles = obstaclesAlternative[level];


                for (float i = (int)playerController.playerZPosition + firstObstacleInLevelPosition; i < playerController.playerZPosition + levelLength - splitDifference; i += obstacleDistance)
                {
                    int rand = Random.Range(0, currentLevelObstacles.Length);
                    float randX = Random.Range(-4.5f, 4.5f);
                    visibleObstacles.Add(Instantiate(currentLevelObstacles[rand], new Vector3(randX, 1.5f, i), currentLevelObstacles[rand].transform.rotation));
                   
                }

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
