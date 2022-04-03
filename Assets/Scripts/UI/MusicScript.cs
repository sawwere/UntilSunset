using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicScript : MonoBehaviour
{
    private TimeCycle timeCycle;
    private bool dayMusicIsPlaying;
    private AudioSource source;
    public AudioSource pauseSource;
    public AudioClip[] AudioCLips;
    private PlayerController pc;
    public bool isTutorial;
    private bool isPaused;

    void Start()
    {
        timeCycle = GameObject.Find("GameStatsObject").GetComponent<TimeCycle>();
        pc = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        source = GetComponent<AudioSource>();
        dayMusicIsPlaying = true;
        isPaused = false;
    }

    void Update()
    {
        if (!isTutorial)
        {
            if (timeCycle.GetIsDay() && !dayMusicIsPlaying)
            {
                SetLevelMusic(1);
                dayMusicIsPlaying = true;
            }

            else if (!timeCycle.GetIsDay() && dayMusicIsPlaying)
            {
                SetLevelMusic(0);
                dayMusicIsPlaying = false;
            }
        }

        if (PauseMenu.GameIsPaused ^ isPaused) PauseAndPlayMusic();
    }
    /// <summary>
    /// «адает соответсвующий времени суток саундтрек
    /// </summary>
    /// <param name="timeNum">Night - 0, Day - 1</param>
    private void SetLevelMusic(int timeNum)
    {
        source.Stop();
        source.clip = AudioCLips[timeNum];
        source.Play();
    }

    private void PauseAndPlayMusic()
    {
        Debug.Log("PauseAndPlayMusic()");
        if (!PauseMenu.GameIsWin)
        {
            if (PauseMenu.GameIsPaused && source.isPlaying)
            {
                pc.PauseWalkSound();
                foreach (var e in GameObject.FindGameObjectsWithTag("Enemy"))
                    e.GetComponent<EnemyCharacter>().PauseWalkSound();
                foreach (var e in GameObject.FindGameObjectsWithTag("Friend"))
                    e.GetComponent<EnemyCharacter>().PauseWalkSound();
                if (!isTutorial)
                {
                    source.Pause();
                    pauseSource.Play();
                }
                isPaused = true;
                Debug.Log("PAUSE");
            }
            else if (!PauseMenu.GameIsPaused && !source.isPlaying)
            {
                pc.ContinueWalkSound();
                foreach (var e in GameObject.FindGameObjectsWithTag("Enemy"))
                    e.GetComponent<EnemyCharacter>().ContinueWalkSound();
                foreach (var e in GameObject.FindGameObjectsWithTag("Friend"))
                    e.GetComponent<EnemyCharacter>().ContinueWalkSound();
                if (!isTutorial)
                {
                    source.Play();
                    pauseSource.Stop();
                }
                isPaused = false;
                Debug.Log("PLAY");
            }
        }
    }
}