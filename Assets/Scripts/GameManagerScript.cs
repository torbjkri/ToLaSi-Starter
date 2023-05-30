using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class GameManagerScript : MonoBehaviour
{
    [SerializeField] private GameStateSO game_state_;
    [SerializeField] private UpgradeStorageSO player_upgrades_;

    // Start is called before the first frame update
    void Start()
    {
        player_upgrades_.ClearUpgrades();
        game_state_.Initialize();
        game_state_.OnGameStateUpdated += OnGameStateChanged;
        DontDestroyOnLoad(this);
        game_state_.game_state = GameStateType.Playing;
    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnGameStateChanged(GameStateType state)
    {
        if (state == GameStateType.Paused || state == GameStateType.Upgrading)
            TurnOffTime();
        else
            TurnOnTime();
    }


    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
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
