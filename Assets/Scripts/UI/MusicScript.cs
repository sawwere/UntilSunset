using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicScript : MonoBehaviour
{
    private TimeCycle timeCycle;
    private bool dayMusicIsPlaying;
    private AudioSource source;
    public AudioSource pauseSource;
    public AudioSource resSource;
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
        if (!isTutorial && !PauseMenu.GameIsWin)
        {
            if (timeCycle.GetIsDay() && !dayMusicIsPlaying)
            {
                SetLevelMusic(1);
                dayMusicIsPlaying = true;
            }

            else if (!timeCycle.GetIsDay() && dayMusicIsPlaying)
            {
                if (GameStats.Encounter < 2)
                    SetLevelMusic(0);
                else
                {
                    pauseSource.volume = 0;
                    source.clip = AudioCLips[3];
                    source.Play();
                }

                dayMusicIsPlaying = false;
            }
        }

        if (PauseMenu.GameIsPaused ^ isPaused) PauseAndPlayMusic();

        if (PauseMenu.GameIsWin)
            if (pauseSource.volume < 0.4f)
                pauseSource.volume += 0.0004f;
    }
    /// <summary>
    /// «адает соответсвующий времени суток саундтрек (Night - 0, Day - 1)
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
        if (!PauseMenu.GameIsWin)
        {
            if (PauseMenu.GameIsPaused)
            {
                pc.PauseWalkSound();
                foreach (var e in GameObject.FindGameObjectsWithTag("Enemy"))
                    e.GetComponent<EnemyCharacter>().PauseWalkSound();
                foreach (var e in GameObject.FindGameObjectsWithTag("Friend"))
                    e.GetComponent<EnemyCharacter>().PauseWalkSound();
                foreach (var e in GameObject.FindGameObjectsWithTag("Minion"))
                    e.GetComponent<Bat>().PauseFlappingSound();
                if (!isTutorial)
                {
                    resSource.Pause();
                    source.Pause();
                    pauseSource.Play();
                }
                isPaused = true;
            }
            else if (!PauseMenu.GameIsPaused)
            {
                pc.ContinueWalkSound();
                foreach (var e in GameObject.FindGameObjectsWithTag("Enemy"))
                    e.GetComponent<EnemyCharacter>().ContinueWalkSound();
                foreach (var e in GameObject.FindGameObjectsWithTag("Friend"))
                    e.GetComponent<EnemyCharacter>().ContinueWalkSound();
                foreach (var e in GameObject.FindGameObjectsWithTag("Minion"))
                    e.GetComponent<Bat>().ContinueFlappingSound();
                if (!isTutorial)
                {
                    source.Play();
                    pauseSource.Stop();
                }
                isPaused = false;
            }
        }
    }

    public void PlayLosingMusic()
    {
        source.Stop();
        source.PlayOneShot(AudioCLips[2], 1f);
        Debug.Log("PlayLosingMusic()");
    }

    public void PlayWinningMusic()
    {
        source.Stop();
        source.PlayOneShot(AudioCLips[3], 1f);
        Debug.Log("PlayWinningMusic()");
    }
}