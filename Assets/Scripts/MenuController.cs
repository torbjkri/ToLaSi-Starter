using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{

    [SerializeField] private GameStateSO game_state_;

    [SerializeField] private GameObject pause_menu_;
    [SerializeField] private GameObject upgrade_menu_;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        switch(game_state_.game_state) {
            case GameStateType.Paused:
                DisableUpgradeMenu();
                EnablePauseMenu();
                break;
            case GameStateType.Upgrading:
                DisablePauseMenu();
                EnableUpgradeMenu();
                break;
            default:
                DisablePauseMenu();
                DisableUpgradeMenu();
                break;
        }
    }

    void EnablePauseMenu()
    {
        pause_menu_.SetActive(true);
    }

    void DisablePauseMenu()
    {
        pause_menu_.SetActive(false);
    }

    void EnableUpgradeMenu()
    {
        upgrade_menu_.SetActive(true);
    }

    void DisableUpgradeMenu()
    {
        upgrade_menu_.SetActive(false);
    }
}
