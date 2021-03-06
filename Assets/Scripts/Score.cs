﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {
    public float score = 0.0f;

    public Text scoreText, highScore;
    private int diffLevel = 1;
    private int maxDiff = 10;
    private int scoreToNextLev = 10;
    private bool isDead = false;
    public static int coinTotal = 0;

    public DeadMenu deathMenu;

    
	
	// Update is called once per frame
	void Update () {
        //if the state of the player is dead, don't update the score

        highScore.text = "Highscore : " + (int)PlayerPrefs.GetFloat("HighScore");

        if (isDead)
            return;

        if (score >= scoreToNextLev)
        {
            LevelUP();
        }
        //score is every seconds
        if (isDead == false)
        {
            score += (Time.deltaTime * diffLevel);
            scoreText.text = ((int)score).ToString();
            
        }
    }

    //implementing in progress <tuto9>
    //increase difficulty 10,20,40,80...
    void LevelUP()
    {
        if (diffLevel == maxDiff)
            return;

        scoreToNextLev *= 2;
        diffLevel++;
        GetComponent<PlayerMovement>().SetSpeed(diffLevel);
        Debug.Log(diffLevel);
    }

    public void OnDeath()
    {
        isDead = true;

        //if highscore is registry is less than current higher score
        if (PlayerPrefs.GetFloat("HighScore") < score)
        {
            PlayerPrefs.SetFloat("HighScore", score);  //Storing the current score
        }
      
        deathMenu.ToggleEndMenu(score,coinTotal);
    }
}
