using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialSounds : MonoBehaviour
{
    private bool gip;

    void Start()
    {
        gip = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!gip)
            {
                GameObject.Find("PlayerTutorial").GetComponent<PlayerController>().PauseWalkSound();
                foreach (var e in GameObject.FindGameObjectsWithTag("Enemy"))
                    e.GetComponent<EnemyCharacter>().PauseWalkSound();
                foreach (var e in GameObject.FindGameObjectsWithTag("Friend"))
                    e.GetComponent<EnemyCharacter>().PauseWalkSound();
                gip = true;
            }
            else
            {
                GameObject.Find("PlayerTutorial").GetComponent<PlayerController>().ContinueWalkSound();
                foreach (var e in GameObject.FindGameObjectsWithTag("Enemy"))
                    e.GetComponent<EnemyCharacter>().ContinueWalkSound();
                foreach (var e in GameObject.FindGameObjectsWithTag("Friend"))
                    e.GetComponent<EnemyCharacter>().ContinueWalkSound();
                gip = false;
            }
        }
    }
}
