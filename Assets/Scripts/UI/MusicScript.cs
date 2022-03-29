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

    void Start()
    {
        timeCycle = GameObject.Find("GameStatsObject").GetComponent<TimeCycle>();
        source = GetComponent<AudioSource>();
        source.loop = false;
        dayMusicIsPlaying = true;
    }

    void Update()
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

        if (Input.GetKeyDown(KeyCode.Escape))
            PauseAndPlayMusic();
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
        if (source.isPlaying)
        {
            source.Pause();
            pauseSource.Play();
            Debug.Log("PAUSE");
        }
        else
        {
            source.Play();
            pauseSource.Stop();
            Debug.Log("PLAY");
        }
    }
}