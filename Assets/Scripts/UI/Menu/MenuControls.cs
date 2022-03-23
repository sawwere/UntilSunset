using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuControls : MonoBehaviour
{
    public GameObject Play;
    public GameObject Level1;
    public GameObject Level2;
    public GameObject Level3;
    public GameObject Tutorial;
    public void PlayPressed()
    {
        Play.SetActive(false);
        Level1.SetActive(true);
        Level2.SetActive(true);
        Level3.SetActive(true);
        Tutorial.SetActive(true);
    }

    public void Level1Pressed()
    {
        SceneManager.LoadScene("Level_1_Scene");
    }

    public void Level2Pressed()
    {
        SceneManager.LoadScene("Level_2_Scene");
    }

    public void Level3Pressed()
    {
        SceneManager.LoadScene("Level_3_Scene");
    }

    public void TutorialPressed()
    {
        SceneManager.LoadScene("Tutorial");
    }
    public void ExitPressed()
    {
        Application.Quit();
        Debug.Log("Exit pressed!");
    }
}
