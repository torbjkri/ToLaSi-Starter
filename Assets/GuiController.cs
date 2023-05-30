using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuiController : MonoBehaviour
{

    [SerializeField] private GameStateSO game_state;

    [SerializeField] private GameObject pause_menu;
    [SerializeField] private GameObject upgade_menu;
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
        else if (state == GameStateType.Won)
            EnableUpgrading();
        else if (state == GameStateType.Playing)
            EnablePlaying();
    }

    public void ResumeGame()
    {
        game_state.game_state = GameStateType.Playing;
    }

    void EnablePlaying()
    {
        upgade_menu.SetActive(false);
        pause_menu.SetActive(false);
    }

    void EnablePause()
    {
        upgade_menu.SetActive(false);
        pause_menu.SetActive(true);
    }

    void EnableUpgrading()
    {
        upgade_menu.SetActive(true);
        pause_menu.SetActive(false);
    }
}
