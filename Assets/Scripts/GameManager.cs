using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] private ConfigsSO game_config;

    private bool isPaused;
    // Start is called before the first frame update
    void Start()
    {
        LoadCurrentLevel();
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
        if (LevelManager.Instance.IsLevelFinished())
        {
            LoadNextLevel();
        }
    }

    private void LoadNextLevel()
    {
        game_config.current_level = LevelManager.Instance.LoadLevel(game_config.current_level + 1);
    }

    private void LoadCurrentLevel()
    {
        game_config.current_level = LevelManager.Instance.LoadLevel(game_config.current_level);
    }

}
