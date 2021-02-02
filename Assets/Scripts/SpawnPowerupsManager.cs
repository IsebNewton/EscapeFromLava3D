using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SpawnPowerupsManager : MonoBehaviour
{
    public GameObject[] powerups;
    public float[] powerupProbabilities;

    private PlayerController playerController;
    private List<GameObject> visiblePowerups;

    public DifficultyManager difficultyManager;

    public LevelManager levelManager;

    // Start is called before the first frame update
    void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        visiblePowerups = new List<GameObject>();
        levelManager = GameObject.Find("LevelManager").GetComponent<LevelManager>();

        if (powerups != null && powerupProbabilities != null && powerups.Length != powerupProbabilities.Length)
        {
            throw new System.Exception("Die Länge des powerups-Arrays stimmt nicht mit der Länge des powerupAmounts-Arrays überein. Stelle die Mengen entsprechend der Powerups ein.");
        }

        difficultyManager = DifficultyManager.Instance;
        //Buch
        if(difficultyManager.difficulty == 1)
        {
            powerupProbabilities[3] *= 0.3f * (levelManager.playerLevel*0.2f);
        }
        if (difficultyManager.difficulty == 2.5)
        {
            powerupProbabilities[3] *= 0.5f * (levelManager.playerLevel * 0.2f);
        }
        if (difficultyManager.difficulty == 4)
        {
            powerupProbabilities[3] *= 0.7f * (levelManager.playerLevel * 0.2f);
        }
        if (difficultyManager.difficulty == 6)
        {
            powerupProbabilities[3] *= 1.0f * (levelManager.playerLevel * 0.2f);
        }
        //Blatt
        if (difficultyManager.difficulty == 1)
        {
            powerupProbabilities[4] *= 0.7f - (levelManager.playerLevel * 0.025f);
        }
        if (difficultyManager.difficulty == 2.5)
        {
            powerupProbabilities[4] *= 1.0f - (levelManager.playerLevel * 0.05f);
        }
        if (difficultyManager.difficulty == 4)
        {
            powerupProbabilities[4] *= 1.2f - (levelManager.playerLevel * 0.06f);
        }
        if (difficultyManager.difficulty == 6)
        {
            powerupProbabilities[4] *= 2.5f - (levelManager.playerLevel * 0.1f);
        }


    }

    // Update is called once per frame
    void Update()
    {
       
        //SpawnRandomPowerup();
    }

    public void SpawnPowerupsForLevel(int levelLength)
    {

        if (powerups != null)
        {
            for (int i = 0; i < powerups.Length; i++)
            {
                int rand = Random.Range(0, 100);
                if (rand < powerupProbabilities[i])
                {
                    int randX = Random.Range(-4, 4);
                    int randZ = Random.Range(0, levelLength - 10);
                    visiblePowerups.Add(Instantiate(powerups[i], new Vector3(randX, 1.5f, playerController.playerZPosition + randZ), powerups[i].transform.rotation));
                }

            }
        }
    }

    public void DestroyAllVisiblePowerups()
    {

        if (visiblePowerups != null)
        {
            for (int i = 0; i < visiblePowerups.Count; i++)
            {
                GameObject firstObstacle = visiblePowerups.First();
                visiblePowerups.Remove(firstObstacle);
                Destroy(firstObstacle);
            }
        }
    }
}