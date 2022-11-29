using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PauseMenu : MonoBehaviour
{
    private InputAction menu;

    [SerializeField] private GameObject pauseUI;
    [SerializeField] private bool isPaused;

    private void Awake()
    {
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnPause()
    {
        Debug.Log("WE ARE PAUSING");
    }
}
