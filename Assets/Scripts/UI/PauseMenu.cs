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
    public  GameObject ChooseText;
    public GameObject NoBloodText;
    public PlayerController PlayerController;
    public static bool SpawnClick = false;
    public static bool TurningClick = false;

    public bool SettingsIsOpened = false; //������� �� ���� ��������

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
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().PauseWalkSound();
        foreach (var e in GameObject.FindGameObjectsWithTag("Enemy"))
            e.GetComponent<EnemyCharacter>().PauseWalkSound();
        foreach (var e in GameObject.FindGameObjectsWithTag("Friend"))
            e.GetComponent<EnemyCharacter>().PauseWalkSound();
        foreach (var e in GameObject.FindGameObjectsWithTag("Minion"))
            e.GetComponent<Bat>().PauseFlappingSound();

        GameObject.Find("ResSounds").GetComponent<AudioSource>().Stop();
        GameObject.Find("PauseMusic").GetComponent<AudioSource>().Stop();
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<MusicScript>().PlayLosingMusic();
        GameObject.Find("PauseMusic").GetComponent<AudioSource>().volume = 0.4f;
        GameObject.Find("PauseMusic").GetComponent<AudioSource>().Play();
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
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().PauseWalkSound();
        foreach (var e in GameObject.FindGameObjectsWithTag("Enemy"))
            e.GetComponent<EnemyCharacter>().PauseWalkSound();
        foreach (var e in GameObject.FindGameObjectsWithTag("Friend"))
            e.GetComponent<EnemyCharacter>().PauseWalkSound();
        foreach (var e in GameObject.FindGameObjectsWithTag("Minion"))
            e.GetComponent<Bat>().PauseFlappingSound();

        GameObject.Find("ResSounds").GetComponent<AudioSource>().Stop();
        GameObject.Find("PauseMusic").GetComponent<AudioSource>().Stop();
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<MusicScript>().PlayWinningMusic();
        GameObject.Find("PauseMusic").GetComponent<AudioSource>().volume = 0.4f;
        GameObject.Find("PauseMusic").GetComponent<AudioSource>().Play();
    }
    public void Level1Pressed()
    {
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

    public void SpawnBatPressed()
    {
        if (!PlayerController.isBat && PlayerController.timeCycle.GetIsDay())
            {
            SpawnClick = true;
            PlayerController.SpawnBat();
            SpawnClick = false;
            Debug.Log("Spawn");
        }
    }

    public void SubdueEnemyPressed()
    {
        if (PlayerController.timeCycle.GetIsDay() && GameStats.Henchman >= 5)
        {
            ChooseText.SetActive(true);
            Debug.Log("Subdue");
        }
        else if (PlayerController.timeCycle.GetIsDay() && GameStats.Henchman < 5)
        {
           NoBloodText.SetActive(true);
           Invoke("DeactiveText",3f);
        }
    }

    public void DeactiveText()
    {
        NoBloodText.SetActive(false);
    }

    public void TurningPressed()
    {
        if  (!PlayerController.isTurning && !PlayerController.isLeaving)
        {
            TurningClick = true;
            PlayerController.Turning();
            Debug.Log("Turning");
            TurningClick = false;
        }
    }

    // =======================================================================
    // ���� ��������
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

    private IEnumerator WaitForSeconds(float value)
    {
        yield return new WaitForSeconds(value);
    }

}
