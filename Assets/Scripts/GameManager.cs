using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] private ConfigsSO game_config;

    private bool isPaused;
    // Start is called before the first frame update
    void Start()
    {
        LoadCurrentLevel();
        isPaused = false;
    }
     
    public void TogglePause()
    {
        isPaused = !isPaused;
        ToggleTimeScale();

        if (isPaused)
        {
            UIManager.Instance.EnablePauseMenu();
        }
        else
        {
            UIManager.Instance.DisablePauseMenu();
        }
    }

    public bool IsGamePaused()
    {
        return isPaused;
    }

    private void ToggleTimeScale()
    {
        if (isPaused)
        {
            Time.timeScale = 0.0f;
        }
        else
        {
            Time.timeScale = 1.0f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (LevelManager.Instance.IsLevelFinished())
        {
            LoadNextLevel();
        }
    }

    private void LoadNextLevel()
    {
        game_config.current_level = LevelManager.Instance.LoadLevel(game_config.current_level + 1);
    }

    private void LoadCurrentLevel()
    {
        game_config.current_level = LevelManager.Instance.LoadLevel(game_config.current_level);
    }
}

// TODO: Sort out how to reconcile these 2

// using UnityEngine.SceneManagement;
// using UnityEngine;

// public class GameManager : MonoBehaviour
// {
//     public static GameManager Instance { get; private set; }
//     public GameObject upgradeMenu;
//     private string gameState = "playing";

//     void Awake()
// {
//     if(Instance == null) // If there is no instance already
//     {
//         DontDestroyOnLoad(gameObject); // Keep the GameObject, this component is attached to, across different scenes
//         Instance = this;
//     } else if(Instance != this) // If there is already an instance and it's not `this` instance
//     {
//         Destroy(gameObject); // Destroy the GameObject, this component is attached to
//     }
// }

//     // Start is called before the first frame update
//     void Start()
//     {
        
//     }

//  // Update is called once per frame
//     void Update()
//     {
//         // Debug.Log(spawners.);
//         //Check lose/win conditions
//         if(GameObject.FindGameObjectsWithTag("Spawner").Length <= 0 && gameState != "won"){
//             Debug.Log("Victory");
//             gameState = "won";          
            
//             //Victory         
//             //Show upgrade canvas before loading next round
//             LoadUpgradeMenu();
//             //Load next round from upgrade canvas?
//             //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);   
//         }       


//     }

//     public void LoadNextLevel(){
//         int currentLevel = PlayerPrefs.GetInt("CurrentDifficulty");
//         GameObject levelSelector = GameObject.Find("LevelSelector");
//         if(currentLevel < levelSelector.GetComponent<LevelSelector>().levels.Count -1) 
//             PlayerPrefs.SetInt("CurrentDifficulty",currentLevel +1);
//         SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
//     }

//     public void LoadUpgradeMenu(){
//         upgradeMenu.SetActive(true);
//         // Time.timeScale = 1f;
//         // gameIsPaused = false;
//     }

//     public void OnUpgradeSelected(){

//         LoadNextLevel();
//     }
// }
