using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameStateType {
    Playing,
    Paused,
    Upgrading
};

[CreateAssetMenu(menuName = "Player/State")]
public class GameStateSO : ScriptableObject
{
    [SerializeField] public int current_level = 0;
    [SerializeField] public GameStateType game_state  = GameStateType.Paused;
}
