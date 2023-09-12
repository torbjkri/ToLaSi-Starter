using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameStateType {
    Playing,
    Paused,
    Upgrading,
    Loading,
    Won,
    FinishedLevel,
    MainMenu,
    NewGame
};

[CreateAssetMenu(menuName = "Player/State")]
public class GameStateSO : ScriptableObject
{
    [SerializeField] List<string> levels = new List<string>();
    [SerializeField] private int current_level = 0;

    public delegate void OnGameStateUpdatedDelegate(GameStateType state);
    public OnGameStateUpdatedDelegate OnGameStateUpdated;

    private GameStateType previous_state_ = GameStateType.Playing;
    private GameStateType game_state_;
    public GameStateType game_state {
        get {return game_state_;}
        set {
            previous_state_ = game_state_;
            game_state_ = value;
            if (OnGameStateUpdated != null)
                OnGameStateUpdated(game_state_);
        }
    }

    public void Initialize()
    {
        OnGameStateUpdated += OnGameStateChanged;
    }

    void OnGameStateChanged(GameStateType state)
    {
        Debug.Log(state.ToString());
    }

    public void TogglePause()
    {
        if (game_state == GameStateType.Paused)
            game_state = previous_state_;
        else
            game_state = GameStateType.Paused;
    }

    public string FirstLevel(){
        return levels[0];
    }
    public string CurrentLevel()
    {
        return levels[current_level];
    }

    public string AdvanceLevel()
    {
        current_level++;
        Debug.Log(string.Format("current level {0}, count {1}", current_level, levels.Count));
        if (current_level == levels.Count)
            current_level = 0;
        
        return levels[current_level];
    }
}
