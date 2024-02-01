using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using JSAM;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;

public class CustomAudioManager : MonoBehaviour
{
    private float timer = 0f;
    private float interval = 10f; // Change this value to set the desired interval

    [SerializeField][Range(0, 1)] private float masterVolume = 1f;
    [SerializeField][Range(0, 1)] private float musicVolume = 1f;
    [SerializeField][Range(0, 1)] private float soundVolume = 1f;
    [SerializeField][Range(0, 1)] private float voiceVolume = 1f;
    [SerializeField][Range(0, 1)] private float jokesVolume = 1f;

    private JSAM.SoundChannelHelper soundHelper;
    void Start()
    {
        // Start the timer
        timer = 0f;
    }

    void Update()
    {
        ChangeVolume();
        // don't execute anything on starting menu screen
        // if (SceneManager.GetActiveScene().buildIndex == 0)
        // {
        //     return;
        // }

        // Increment the timer
        timer += Time.deltaTime;
        // Check if the desired interval has passed
        if (timer >= interval)
        {
            // Reset the timer
            timer = 0f;

            soundHelper = AudioManager.PlaySound(JSAM_librarySounds.allJokes);
            Debug.Log("Jokes volume: " + soundHelper.AudioFile.relativeVolume);
            // JSAM.MusicPlayer.FadeBehaviour.
        }
    }
    private void ChangeVolume()
    {
        JSAM.AudioManager.MasterVolume = masterVolume;
        JSAM.AudioManager.MusicVolume = musicVolume;
        JSAM.AudioManager.SoundVolume = soundVolume;
        JSAM.AudioManager.VoiceVolume = voiceVolume;
        if (soundHelper)
            soundHelper.AudioFile.relativeVolume = jokesVolume;
    }
}

