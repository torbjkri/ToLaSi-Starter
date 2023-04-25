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
    // Start is called before the first frame update
    void Awake()
    {
    }

    public void StartGame()
    {
        Debug.Log("Game manager awake");
        LoadCurrentLevel();
        GameState = GameStateType.Playing;
    }

    public void UpdateGameState()
    {
        if (level_manager_.IsLevelFinished())
        {
            LoadNextLevel();
            //GameState = GameStateType.Upgrading;
            //ToggleTimeScale();
        }
    }
     
    public void TogglePause()
    {
        if (IsGamePaused())
        {
            GameState = GameStateType.Playing;
            ToggleTimeScale();
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
        return GameState == GameStateType.Paused;
    }

    private void ToggleTimeScale()
    {
        if (IsGamePaused())
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
        level_manager_.LoadLevel(game_config.current_level + 1);
    }

    private void LoadCurrentLevel()
    {
        level_manager_.LoadLevel(game_config.current_level);
    }

}
