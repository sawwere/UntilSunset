using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public static bool GameIsLosed= false;
    public GameObject pauseMenuUI;
    public GameObject loseMenuUI;

    
    private void Start()
    {
        GameIsLosed = false;
        GameIsPaused = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !GameIsLosed)
        {
                if (GameIsPaused)
                {
                for (int i = 0; i <pauseMenuUI.transform.childCount; i++)
                {
                    GameObject child = pauseMenuUI.transform.GetChild(i).gameObject;
                    Animator animator = child.GetComponent<Animator>();
                    animator.CrossFade("Normal", 0f);
                    animator.Update(0f);
                }
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

   
}
