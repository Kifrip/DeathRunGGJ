using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using JSAM;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;

public class CustomAudioManager : MonoBehaviour
{
    private float jokeTimer = 0f;
    private float interval = 10f; // Interval between jokes in seconds

    [SerializeField][Range(0, 1)] private float masterVolume = 1f;
    [SerializeField][Range(0, 1)] private float musicVolume = 1f;
    [SerializeField][Range(0, 1)] private float soundVolume = 1f;
    [SerializeField][Range(0, 1)] private float voiceVolume = 1f;
    [Header("Relative Volumes")]
    [SerializeField][Range(0, 1)] private float jokesVolume = 1f;
    [SerializeField][Range(0, 1)] private float deathSoundsVolume = 1f;

    private JSAM.SoundChannelHelper jokesHelper;
    private JSAM.SoundChannelHelper deathSoundsHelper;

    void Start()
    {
        // Start the jokeTimer
        jokeTimer = 0f;
    }

    void Update()
    {
        ChangeVolume();

        // don't execute anything on starting menu screen
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            return;
        }

        PlayJoke();
    }

    private void PlayJoke()
    {
        // Increment the jokeTimer
        jokeTimer += Time.deltaTime;
        // Check if the desired interval has passed
        if (jokeTimer >= interval)
        {
            // Reset the jokeTimer
            jokeTimer = 0f;

            jokesHelper = AudioManager.PlaySound(JSAM_librarySounds.allJokes);
            // Debug.Log("Jokes volume: " + jokesHelper.AudioFile.relativeVolume);
        }
    }
    public void PlayDeathSound()
    {
        deathSoundsHelper = AudioManager.PlaySound(JSAM_librarySounds.allDeathSounds);
        // Debug.Log("Death Sounds volume: " + deathSoundsHelper.AudioFile.relativeVolume);

    }
    private void ChangeVolume()
    {
        JSAM.AudioManager.MasterVolume = masterVolume;
        JSAM.AudioManager.MusicVolume = musicVolume;
        JSAM.AudioManager.SoundVolume = soundVolume;
        JSAM.AudioManager.VoiceVolume = voiceVolume;
        if (jokesHelper)
            jokesHelper.AudioFile.relativeVolume = jokesVolume;
        if (deathSoundsHelper)
            deathSoundsHelper.AudioFile.relativeVolume = deathSoundsVolume;
    }
}

