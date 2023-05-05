using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class GameManagerScript : MonoBehaviour
{
    [SerializeField] private GameStateSO game_state_;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this);
    }

    // Update is called once per frame
    void Update()
    {
        if (game_state_.game_state == GameStateType.Loading)
            return;

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

}
