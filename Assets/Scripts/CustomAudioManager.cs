using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using JSAM;
using TMPro;
using Unity.VisualScripting;

public class CustomAudioManager : MonoBehaviour
{
    // Add a reference to the sound you want to play
    // public JSAM_librarySounds soundToPlay;

    // Start is called before the first frame update
    private float timer = 0f;
    private float interval = 10f; // Change this value to set the desired interval
    private List<JSAM_librarySounds> sounds;
    private List<JSAM.BaseAudioFileObject> jokes;


    void Start()
    {
        // Start the timer
        timer = 0f;
        sounds = new List<JSAM_librarySounds>()
        {
            JSAM_librarySounds.joke_1,
            JSAM_librarySounds.joke_2,
            JSAM_librarySounds.joke_3,
            JSAM_librarySounds.joke_4,
            JSAM_librarySounds.joke_5,
            JSAM_librarySounds.joke_6,
            JSAM_librarySounds.joke_7,
            JSAM_librarySounds.joke_8,
            JSAM_librarySounds.joke_9,
            JSAM_librarySounds.joke_10
        };
    }

    void Update()
    {
        // Increment the timer
        timer += Time.deltaTime;

        // Check if the desired interval has passed
        if (timer >= interval)
        {
            // Reset the timer
            timer = 0f;
            // Pick a random sound from the list
            int randomIndex = Random.Range(0, sounds.Count);
            JSAM.AudioManager.PlaySound(sounds[randomIndex]);

            // BaseAudioFileObject audioFileObject = JSAM.AudioManager.PlaySound(sounds[randomIndex]).gameObject.GetComponent<BaseAudioFileObject>();

            // audioFileObject.pitchShift = Random.Range(0.5f, 1.5f);
            // JSAM_librarySounds.joke_1.pitch = Random.Range(0.5f, 1.5f);
            
            // Execute your code here
            // JSAM.AudioManager.PlaySound(JSAM_librarySounds.allJokes);
            // JSAM.AudioManager.PlaySoundLoop(soundToPlay);
        }
    }


}

