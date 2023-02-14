using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MainMenuController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
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
