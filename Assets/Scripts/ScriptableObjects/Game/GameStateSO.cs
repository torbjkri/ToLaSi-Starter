using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameStateType {
    Playing,
    Paused,
    Upgrading,
    Loading,
};

[CreateAssetMenu(menuName = "Player/State")]
public class GameStateSO : ScriptableObject
{
    [SerializeField] List<string> levels = new List<string>();
    [SerializeField] private int current_level = 0;
    [SerializeField] public GameStateType game_state  = GameStateType.Paused;

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
