using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour
{

    public int score = 0;
    public Text scoreText;
    private GameObject player;
    

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerPrefs.GetString("Language") == "German")
        {
            scoreText.text = "Punkte : " + score;
        }
        else if (PlayerPrefs.GetString("Language") == "English")
        {
            scoreText.text = "Score: " + score;
        }
    }
}
