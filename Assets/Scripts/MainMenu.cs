using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor.SceneManagement;

public class MainMenu : MonoBehaviour {

    public Text highscoreText;

// Use this for initialization
void Start () {
        //display High Score retrieving from the registry
        highscoreText.text = "Highscore : " + (int)PlayerPrefs.GetFloat("HighScore");
	}
	

    public void ToGame()
    {
        EditorSceneManager.LoadScene("Play");   
    }

}
