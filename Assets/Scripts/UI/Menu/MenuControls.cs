using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuControls : MonoBehaviour
{
    public GameObject Play;
    public GameObject Level1;
    public GameObject Level2;
    public GameObject Level3;
    public GameObject Tutorial;
    public GameObject InfoBut;
    public GameObject ScrollInfo;
    public Text MenuLogo;

    public void PlayPressed()
    {
        Play.SetActive(false);
        Level1.SetActive(true);
        Level2.SetActive(true);
        Level3.SetActive(true);
        Tutorial.SetActive(true);
        InfoBut.SetActive(false);
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
    public void OpenInfo()
    {
        Play.SetActive(false);
        InfoBut.SetActive(false);
        ScrollInfo.SetActive(true);
        MenuLogo.text = "ќб »гре";
    }
    public void CloseInfo()
    {
        Play.SetActive(true);
        InfoBut.SetActive(true);
        ScrollInfo.SetActive(false);
        MenuLogo.text = "ћеню";
    }
}
