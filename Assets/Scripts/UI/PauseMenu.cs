using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;


public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public static bool GameIsLosed= false;
    public static bool GameIsWin = false;
    public GameObject pauseMenuUI;
    public GameObject loseMenuUI;
    public GameObject winMenuUI;
    public GameObject SettingsMenu;
 
    public bool SettingsIsOpened = false; //Открыто ли меню настроек

    private void Awake()
    {
        GameIsLosed = false;
        GameIsPaused = false;
        GameIsWin = false;
        SettingsIsOpened = false;
        Time.timeScale = 1f;
        winMenuUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !GameIsLosed && !GameIsWin)
        {
                if (GameIsPaused)
                {
                    if (SettingsIsOpened)
                    {
                        BackToPauseMenu();
                    }
                    else
                        Resume();
                }
                else
                {
                    Pause();
                }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f ;
        GameIsPaused = false;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void LoadMenu()
    {
        Debug.Log("Load");
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

    public void Lose()
    {
        Time.timeScale = 0f;
        GameIsLosed = true;
        loseMenuUI.SetActive(true);
    }

    public void RestartGame()
    {
        Debug.Log("Restart");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1f;
    }

    public void Win()
    {
        Time.timeScale = 0f;
        winMenuUI.SetActive(true);
        GameIsWin = true;
    }
    public void Level1Pressed()
    {
        winMenuUI.SetActive(false);
        Time.timeScale = 1f;
        SceneManager.LoadScene("Level_1_Scene");
       
    }

    public void Level2Pressed()
    { 
        Time.timeScale = 1f;
        SceneManager.LoadScene("Level_2_Scene");
       
    }

    public void Level3Pressed()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Level_3_Scene");
        
    }

    // =======================================================================
    // Меню настроек
    // =======================================================================

    public void SettingsPressed()
    {
        pauseMenuUI.SetActive(false);
        SettingsMenu.SetActive(true);
        SettingsIsOpened = true;
    }

    public void BackToPauseMenu()
    {
        pauseMenuUI.SetActive(true);
        SettingsMenu.SetActive(false);
        SettingsIsOpened = false;
    }

}
