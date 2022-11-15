using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MainMenuController : MonoBehaviour
{
        public GameObject resumeGameButton;

    // Start is called before the first frame update
    void Start()
    {
         if(!PlayerPrefs.HasKey("CurrentDifficulty") || PlayerPrefs.GetInt("CurrentDifficulty") == 0){
            resumeGameButton.SetActive(false);
        }
        
    }
    // Update is called once per frame
    void Update()
    {
       
    }

    public void StartGame(){
        SceneManager.LoadScene("Arms Race");
    }

    public void StartNewGame(){
        PlayerPrefs.SetInt("CurrentDifficulty",0);
        SceneManager.LoadScene("Arms Race");
    }
    
}
