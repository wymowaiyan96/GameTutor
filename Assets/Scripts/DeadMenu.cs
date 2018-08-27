using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DeadMenu : MonoBehaviour {

    public Text scoreText;
   // public Text coinText;
    public Image backgroundImage;
    private bool isShowned = false;
    private float transition = 0.0f;

   

	// Use this for initialization
	void Start () {
        gameObject.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
        if (!isShowned)
            return;
        //animation fade to dark
        transition += Time.deltaTime;
        backgroundImage.color = Color.Lerp(new Color(0, 0, 0, 0), Color.black, transition);
	}

    public void ToggleEndMenu(float score, int coinTotal)
    {                    
            gameObject.SetActive(true);
            scoreText.text = ((int)score).ToString();
           // coinText.text =  ((int)coinTotal).ToString();
            isShowned = true;
            
     }    


    public void restartGame()
    {//loading the current scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void menu()
    {
        SceneManager.LoadScene("Menu");
    }
}
