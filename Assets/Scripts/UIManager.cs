using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : Singleton<UIManager>
{
    public GameObject pauseMenu;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EnablePauseMenu()
    {
        pauseMenu.SetActive(true);
    }

    public void DisablePauseMenu()
    {
        pauseMenu.SetActive(false);
    }

}
