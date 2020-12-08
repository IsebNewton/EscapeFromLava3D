﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour
{

    private int score = 0;
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

        scoreText.text = "Score: " + score;

        score = Mathf.RoundToInt(player.transform.position.z);


    }
}
