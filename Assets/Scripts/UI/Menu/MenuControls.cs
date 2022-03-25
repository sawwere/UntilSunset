using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuControls : MonoBehaviour
{
    public GameObject Exit;
    public GameObject Back;
    public GameObject Play;
    public GameObject Level1;
    public GameObject Level2;
    public GameObject Level3;
    public GameObject Tutorial;
<<<<<<< HEAD
    public GameObject InfoBut;
    public GameObject ScrollInfo;
    public Text MenuLogo;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !Play.activeInHierarchy && !ScrollInfo.activeInHierarchy)
        {
            BackToMain();
        }

    }




=======
>>>>>>> parent of e57661d (Squashed commit of the following:)
    public void PlayPressed()
    {
        Exit.SetActive(false);
        Play.SetActive(false);
        Level1.SetActive(true);
        Level2.SetActive(true);
        Level3.SetActive(true);
        Tutorial.SetActive(true);
<<<<<<< HEAD
        InfoBut.SetActive(false);
        Back.SetActive(true);
=======
>>>>>>> parent of e57661d (Squashed commit of the following:)
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
<<<<<<< HEAD
    public void OpenInfo()
    {
        Play.SetActive(false);
        InfoBut.SetActive(false);
        ScrollInfo.SetActive(true);
        MenuLogo.text = "Îá Èãðå";
    }
    public void CloseInfo()
    {
        Play.SetActive(true);
        InfoBut.SetActive(true);
        ScrollInfo.SetActive(false);
        MenuLogo.text = "Ìåíþ";
    }

    public void BackToMain()
    {
        Exit.SetActive(true);
        Play.SetActive(true);
        Level1.SetActive(false);
        Level2.SetActive(false);
        Level3.SetActive(false);
        Tutorial.SetActive(false);
        InfoBut.SetActive(true);
        Back.SetActive(false);
    }
=======
>>>>>>> parent of e57661d (Squashed commit of the following:)
}
