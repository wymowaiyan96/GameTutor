using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    public static bool GameIsPaused = false;

    public GameObject pauseMenuUI;

    //Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                resumeGame();
            }

            else
            {
                pauseMenu();
            }
        }
    }



    public void resumeGame()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f; //normale time scale
        GameIsPaused = false;
    }

    public void pauseMenu()
    {
        pauseMenuUI.SetActive(true); //showing the Pause Menu UI
        Time.timeScale = 0f; //completely freeze the game
        GameIsPaused = true;
    }

    public void mainMenu()
    {
        Time.timeScale = 1f; //to make sure the game is not freeze
        SceneManager.LoadScene("Menu");
    }

    public void quitGame()
    {
        Application.Quit();
    }

}