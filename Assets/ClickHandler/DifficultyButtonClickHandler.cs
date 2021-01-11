using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultyButtonClickHandler : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetDifficulty(string difficulty)
    {
        switch (difficulty)
        {
            case "easy":
                DifficultyManager.Instance.DifficultyEasy();
                break;
            case "medium":
                DifficultyManager.Instance.DifficultyMedium();
                break;
            case "hard":
                DifficultyManager.Instance.DifficultyHard();
                break;
            case "nightmare":
                DifficultyManager.Instance.DifficultyNightmare();
                break;
            default:
                Debug.LogError("[DifficultyButtonClickListener::SetDifficulty] Schwierigkeitsgrad " + difficulty + " nicht definiert!");
                break;
        }
        
    }
}
