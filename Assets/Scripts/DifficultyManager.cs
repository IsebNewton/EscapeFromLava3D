using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class DifficultyManager
{
    private static readonly DifficultyManager instance = new DifficultyManager();

    static DifficultyManager()
    {
    }

    private DifficultyManager()
    {
    }

    public static DifficultyManager Instance
    {
        get
        {
            return instance;
        }
    }

    public float difficulty = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }




    public void DifficultyEasy()
    {
        difficulty = 1;
    }

    public void DifficultyMedium()
    {
        difficulty = 1.25f;
    }

    public void DifficultyHard()
    {
        difficulty = 1.5f;
    }

    public void DifficultyNightmare()
    {
        difficulty = 3;
    }










}
