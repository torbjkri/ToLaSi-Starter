using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

using UnityEngine;

public class LevelController : MonoBehaviour
{
    
    public GameObject[] spawners;
    //For picking random level based on difficulty
    public int difficulty = 1;

    private List<GameObject> spawnObjects = new List<GameObject>();

    private string gameState = "playing";

    // Start is called before the first frame update
    void Start()
    {
        //Init spawners
        foreach(GameObject spawner in spawners){
                GameObject spawnerObject = Instantiate(spawner,
                 spawner.GetComponent<SpawnController>().spawnPosition, 
                 Quaternion.identity);
            }
    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log(spawners.);
        //Check lose/win conditions
        if(GameObject.FindGameObjectsWithTag("Spawner").Length <= 0 && gameState != "won"){
            Debug.Log("Victory");
            gameState = "won";
            int currentLevel = PlayerPrefs.GetInt("CurrentDifficulty");
            GameObject levelSelector = GameObject.Find("LevelSelector");
            if(currentLevel < levelSelector.GetComponent<LevelSelector>().levels.Count -1) 
                PlayerPrefs.SetInt("CurrentDifficulty",currentLevel +1);
            //Victory         
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);   
        }
        


    }
}
