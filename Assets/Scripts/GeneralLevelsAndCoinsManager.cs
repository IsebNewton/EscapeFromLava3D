using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneralLevelsAndCoinsManager : MonoBehaviour
{

    private static readonly GeneralLevelsAndCoinsManager instance = new GeneralLevelsAndCoinsManager();

    static GeneralLevelsAndCoinsManager()
    {
    }

    private GeneralLevelsAndCoinsManager()
    {
    }

    public static GeneralLevelsAndCoinsManager Instance
    {
        get
        {
            return instance;
        }
    }

    

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void LevelFinish(float difficulty,float score)
    {
        float generalCoins = PlayerPrefs.GetFloat("GeneralCoins");
        float playerMaxLevel = PlayerPrefs.GetFloat("MaxLevel");

        if(playerMaxLevel == difficulty)
        {
            //Do Nothing
        }
        else if(playerMaxLevel > difficulty)
        {
            //Do Nothing
        }
        else if (playerMaxLevel < difficulty)
        {
            PlayerPrefs.SetFloat("MaxLevel", difficulty);
        }

        generalCoins += score;

        PlayerPrefs.SetFloat("GeneralCoins", generalCoins);
    }

    public void LevelDied(float score) 
    {
        float generalCoins = PlayerPrefs.GetFloat("GeneralCoins");
        Debug.Log(PlayerPrefs.GetFloat("GeneralCoins"));
        generalCoins += score;

        PlayerPrefs.SetFloat("GeneralCoins", generalCoins);
    }


}
