using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.InputSystem;

public enum GameStateType {
    Playing,
    Paused,
    Upgrading
};


[CreateAssetMenu(menuName = "Game/Game Manager", fileName = "GameManager")]
public class GameManagerSO : ScriptableObject
{
    [SerializeField] private ConfigsSO game_config;
    [SerializeField] private LevelManagerSO level_manager_;

    public GameStateType GameState {get; private set;}
    private bool isPaused;
    // Start is called before the first frame update
    void Awake()
    {
    }

    public void StartGame()
    {
        Debug.Log("Game manager awake");
        if(SceneManager.GetSceneByName("MainMenu") == SceneManager.GetActiveScene())
            SceneManager.LoadScene("Arms Race");
        LoadCurrentLevel();
        isPaused = false;
        GameState = GameStateType.Playing;
    }

    public void UpdateGameState()
    {
        if (level_manager_.IsLevelFinished())
        {
            LoadNextLevel();
            GameState = GameStateType.Upgrading;
            ToggleTimeScale();
        }
    }
     
    public void TogglePause()
    {
        isPaused = !isPaused;
        ToggleTimeScale();

        if (isPaused)
        {
            GameState = GameStateType.Paused;
        }
        else
        {
            GameState = GameStateType.Playing;
        }
    }

        public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void FinishUpgrading()
    {
        GameState = GameStateType.Playing;
        ToggleTimeScale();
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

    private void LoadNextLevel()
    {
        game_config.current_level = level_manager_.LoadLevel(game_config.current_level + 1);
    }

    private void LoadCurrentLevel()
    {
        game_config.current_level = level_manager_.LoadLevel(game_config.current_level);
    }

}
