using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [Header("Keybinds")]
    public KeyCode pauseKey = KeyCode.Escape;

    [Header("Game Objects")]
    public GameObject pauseUI;

    [Header("Testing Vars")]
    public bool paused;    
    public bool canPause;


    void Start()
    {
        pauseUI.SetActive(false);

        paused = false;
        canPause = true;
    }

    
    void Update()
    {
        if (Input.GetKeyDown(pauseKey) && !paused && canPause)
        {
            PauseGame();
        } else if (Input.GetKeyDown(pauseKey) && paused && canPause)
        {
            ResumeGame();
        }
    }

    public void PauseGame()
    {
        pauseUI.SetActive(true);
        //Time.timeScale = 0;
        paused = true;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
    }

    public void ResumeGame()
    {
        pauseUI.SetActive(false);
        //Time.timeScale = 1;
        paused = false;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
}
