using System.Collections;
using System.Collections.Generic;
using StarterAssets;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.UI;
using UnityEngine.SceneManagement;

public class MenuSystem : MonoBehaviour
{

public bool isGamePaused = false;
private GameObject canvasMenu;
// private GameObject eventSystem;
// private UICanvasControllerInput input;
private InputSystemUIInputModule input;

private void Start()
{
    // don't execute anything on starting menu screen
    if (SceneManager.GetActiveScene().name == "StartMenu")
    {
        return;
    }
    Time.timeScale = 1f;
    isGamePaused = false;
    canvasMenu = GameObject.Find("CanvasMenu");
    canvasMenu.SetActive(false);

    Cursor.lockState = CursorLockMode.Locked;
    Cursor.visible = false;
}

    private void Update()
    {
        if (Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            if (isGamePaused)
            {
                ContinueGame();
                Debug.Log("Game should NOT be paused rn");
            }
            else
            {
                PauseGame();
                Debug.Log("Game should be paused rn");
            }
        }
    }

    public void PauseGame()
    {
        Time.timeScale = 0f;
        isGamePaused = true;
        canvasMenu.SetActive(true);
        
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

    }


    public void ContinueGame()
    {
        Time.timeScale = 1f;
        isGamePaused = false;
        canvasMenu.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
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
// Combine Menu scripts. Just add the if statement which check what is the name of the scene and don't load during startmenu scene
