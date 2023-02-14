using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public GameObject upgradeMenu;
    private string gameState = "playing";
    // Start is called before the first frame update
    void Start()
    {
        
    }

 // Update is called once per frame
    void Update()
    {
        // Debug.Log(spawners.);
        //Check lose/win conditions
        if(GameObject.FindGameObjectsWithTag("Spawner").Length <= 0 && gameState != "won"){
            Debug.Log("Victory");
            gameState = "won";          
            
            //Victory         
            //Show upgrade canvas before loading next round
            LoadUpgradeMenu();
            //Load next round from upgrade canvas?
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);   
        }       


    }

    public void LoadNextLevel(){
        int currentLevel = PlayerPrefs.GetInt("CurrentDifficulty");
        GameObject levelSelector = GameObject.Find("LevelSelector");
        if(currentLevel < levelSelector.GetComponent<LevelSelector>().levels.Count -1) 
            PlayerPrefs.SetInt("CurrentDifficulty",currentLevel +1);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void LoadUpgradeMenu(){
        upgradeMenu.SetActive(true);
        // Time.timeScale = 1f;
        // gameIsPaused = false;
    }

    public void OnUpgradeSelected(){

        LoadNextLevel();
    }
}
