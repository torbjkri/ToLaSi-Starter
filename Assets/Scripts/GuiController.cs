using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GuiController : MonoBehaviour
{

    [SerializeField] private GameStateSO game_state;

    [SerializeField] private GameObject main_menu;
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
        else if (state == GameStateType.MainMenu)
            LoadMainMenu();
    }

    public void ResumeGame()
    {
        game_state.game_state = GameStateType.Playing;
    }

        public void NewGame()
    {
        game_state.game_state = GameStateType.NewGame;
    }

    public void MainMenu(){
        game_state.game_state = GameStateType.MainMenu;
    }

    public void QuitGame(){
        Application.Quit();
    }

    void EnablePlaying()
    {
        upgade_menu.SetActive(false);
        pause_menu.SetActive(false);
        main_menu.SetActive(false);
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

    void LoadMainMenu(){
        pause_menu.SetActive(false);
        upgade_menu.SetActive(false);
        main_menu.SetActive(true);
    }        
    
}
