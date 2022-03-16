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

    public bool SettingsIsOpened = false; //Открыто ли меню настроек
    public float volume = 0; //Громкость
    public int quality = 0; //Качество
    public bool isFullscreen = false; //Полноэкранный режим
    public AudioMixer audioMixer; //Регулятор громкости
    public Dropdown resolutionDropdown; //Список с разрешениями для игры
    private Resolution[] resolutions; //Список доступных разрешений
    private int currResolutionIndex = 0; //Текущее разрешение
    public GameObject SettingsMenu;



    private void Awake()
    {
        GameIsLosed = false;
        GameIsPaused = false;
        GameIsWin = false;
        SettingsIsOpened = false;
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

    public void ChangeVolume(float val) 
    {
        volume = val;
    }

    public void ChangeResolution(int index) 
    {
        currResolutionIndex = index;
    }

    public void ChangeFullscreenMode(bool val) 
    {
        isFullscreen = val;
    }

    public void ChangeQuality(int index) 
    {
        quality = index;
    }

}
