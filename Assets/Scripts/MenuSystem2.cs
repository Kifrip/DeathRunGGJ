using System.Collections;
using System.Collections.Generic;
using StarterAssets;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.UI;
using UnityEngine.SceneManagement;

public class MenuSystem2 : MonoBehaviour
{
    public bool isGamePaused = false;
    [SerializeField] private GameObject canvasMenu;
    private void Start()
    {
        // don't execute anything on starting menu screen
        if (SceneManager.GetActiveScene().buildIndex == 0) // assuming StartMenu is the first scene
        {
            return;
        }
        ResumeGame();
    }
    private void Update()
    {
        if (Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            if (isGamePaused)
            {
                ResumeGame();
                Debug.Log("Game should NOT be paused rn");
            }
            else
            {
                PauseGame();
                Debug.Log("Game should be paused rn");
            }
        }
    }
    private void SetCursorState(bool isVisible)
    {
        Cursor.lockState = isVisible ? CursorLockMode.None : CursorLockMode.Locked;
        Cursor.visible = isVisible;
    }

    public void PauseGame()
    {
        Time.timeScale = 0f;
        isGamePaused = true;
        canvasMenu.SetActive(true);
        SetCursorState(true);

    }
    private void ResumeGame()
    {
        Time.timeScale = 1f;
        isGamePaused = false;
        canvasMenu.SetActive(false);
        SetCursorState(false);
    }


    public void SceneSwitch(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}