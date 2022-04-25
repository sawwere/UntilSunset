using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuControls : MonoBehaviour
{
    public GameObject Exit;
    public GameObject Back;
    public GameObject Play;
    public GameObject Level1;
    public GameObject Level2;
    public GameObject Level3;
    public GameObject Tutorial;

    public GameObject LockLevel2;
    public GameObject LockLevel3;

    public GameObject InfoBut;
    public GameObject ScrollInfo;
    public Text MenuLogo;
    public int Level;

 

    private void Awake()
    {
        if(!PlayerPrefs.HasKey("Level"))
            PlayerPrefs.SetInt("Level", 1);
        else
            Level = PlayerPrefs.GetInt("Level");
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !Play.activeInHierarchy && !ScrollInfo.activeInHierarchy)
        {
            BackToMain();
        }

    }

    public void PlayPressed()
    {
        Level = PlayerPrefs.GetInt("Level");
        Exit.SetActive(false);
        Play.SetActive(false);
        Level1.SetActive(true);
        if (Level > 1)
        {
            Level2.SetActive(true);
            LockLevel2.SetActive(false);
        }
        else
        {
            Level2.SetActive(false);
            LockLevel2.SetActive(true);
        }
        if (Level > 2)
        {
            Level3.SetActive(true);
            LockLevel3.SetActive(false);
        }
        else
        {
            Level3.SetActive(false);
            LockLevel3.SetActive(true);
        }
        Tutorial.SetActive(true);
        InfoBut.SetActive(false);
        Back.SetActive(true);
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
        MenuLogo.text = "Об Игре";
    }
    public void CloseInfo()
    {
        Play.SetActive(true);
        InfoBut.SetActive(true);
        ScrollInfo.SetActive(false);
        MenuLogo.text = "Меню";
    }

    public void BackToMain()
    {
        Exit.SetActive(true);
        Play.SetActive(true);
        Level1.SetActive(false);
        Level2.SetActive(false);
        Level3.SetActive(false);
        LockLevel2.SetActive(false);
        LockLevel3.SetActive(false);
        Tutorial.SetActive(false);
        InfoBut.SetActive(true);
        Back.SetActive(false);
    }

}
