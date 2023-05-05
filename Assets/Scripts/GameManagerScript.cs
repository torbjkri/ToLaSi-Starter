using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class GameManagerScript : MonoBehaviour
{
    [SerializeField] private GameStateSO game_state_;
    [SerializeField] private LevelManagerSO level_manager_;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this);

        Debug.Log("Game manager awake");
        LoadCurrentLevel();

        game_state_.game_state = GameStateType.Playing;
    }

    // Update is called once per frame
    void Update()
    {
        if (level_manager_.IsLevelFinished())
        {
            LoadNextLevel();
            //GameState = GameStateType.Upgrading;
            //ToggleTimeScale();
        }

        if (IsGamePaused())
            TurnOffTime();

    }


        public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void FinishUpgrading()
    {
        game_state_.game_state = GameStateType.Playing;
        TurnOnTime();
    }

    public bool IsGamePaused()
    {
        return game_state_.game_state == GameStateType.Paused;
    }

    private void TurnOffTime()
    {
        Time.timeScale = 0.0f;
    }

    private void TurnOnTime()
    {
        Time.timeScale = 1.0f;
    }


    private void LoadNextLevel()
    {
        level_manager_.LoadLevel(game_state_.current_level + 1);
    }

    private void LoadCurrentLevel()
    {
        level_manager_.LoadLevel(game_state_.current_level);
    }

}
