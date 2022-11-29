using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : Singleton<GameManager>
{

    private bool isPaused;
    // Start is called before the first frame update
    void Start()
    {
        isPaused = false;
    }
     
    public void TogglePause()
    {
        isPaused = !isPaused;
        ToggleTimeScale();

        if (isPaused)
        {
            UIManager.Instance.EnablePauseMenu();
        }
        else
        {
            UIManager.Instance.DisablePauseMenu();
        }
    }

    public bool IsGamePaused()
    {
        return isPaused;
    }

    private void ToggleTimeScale()
    {
        if (isPaused)
        {
            Time.timeScale = 0.0f;
        }
        else
        {
            Time.timeScale = 1.0f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
