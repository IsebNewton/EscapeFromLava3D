using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficulyManager : MonoBehaviour
{

    public float difficulty = 1;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }



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
        difficulty = 10;
    }










}
