using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameMenuController : MonoBehaviour
{
    
    public static bool gameIsPaused;
    public enum GameStates { ACTIVE, PAUSED, WON, LOST, COMPLETED, ENDLESSDONE};
    public GameObject pauseMenuUI;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Awake()
    {
        Resume();
    }
    // Update is called once per frame
    void Update()
    {
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;
    }

     public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;
    }
    private void OnPause()
    {
        Debug.Log("Called pause!");
         if (gameIsPaused)
         {
             Resume();
         }
         else
         {
             Pause();
         }
    }
}
