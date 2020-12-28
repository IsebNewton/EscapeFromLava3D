﻿using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SpawnPowerupsManager : MonoBehaviour
{
    public GameObject[] powerups;
    public int[] powerupProbabilities;

    private PlayerController playerController;
    private List<GameObject> visiblePowerups;

    // Start is called before the first frame update
    void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        visiblePowerups = new List<GameObject>();

        if (powerups != null && powerupProbabilities != null && powerups.Length != powerupProbabilities.Length)
        {
            throw new System.Exception("Die Länge des powerups-Arrays stimmt nicht mit der Länge des powerupAmounts-Arrays überein. Stelle die Mengen entsprechend der Powerups ein.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("playerController.playerZPosition: " + playerController.playerZPosition);
        //SpawnRandomPowerup();
    }

    public void SpawnPowerupsForLevel(int levelLength)
    {
        Debug.Log("SpawnPowerupsForLevel...");
        if (powerups != null)
        {
            for (int i = 0; i < powerups.Length; i++)
            {
                int rand = Random.Range(0, 100);
                if (rand < powerupProbabilities[i])
                {
                    int randX = Random.Range(-5, 5);
                    int randZ = Random.Range(0, levelLength - 10);
                    visiblePowerups.Add(Instantiate(powerups[i], new Vector3(randX, 1.5f, playerController.playerZPosition + randZ), powerups[i].transform.rotation));
                }

            }
        }
    }

    public void DestroyAllVisiblePowerups()
    {
        Debug.Log("Destroy...");
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