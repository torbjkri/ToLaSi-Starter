using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuiController : MonoBehaviour
{

    [SerializeField] private GameStateSO game_state;

    [SerializeField] private GameObject pause_menu;
    // Start is called before the first frame update
    void Start()
    {
        game_state.OnGameStateUpdated += OnGameStateChanged;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnGameStateChanged(GameStateType state)
    {
        if (state == GameStateType.Paused)
            EnablePause();
        else
            EnablePlaying();
    }

    public void ResumeGame()
    {
        game_state.game_state = GameStateType.Playing;
    }

    void EnablePlaying()
    {
        pause_menu.SetActive(false);
    }

    void EnablePause()
    {
        pause_menu.SetActive(true);
    }
}
