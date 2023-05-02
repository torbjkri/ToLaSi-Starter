using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    [SerializeField] private GameManagerSO game_manager_;
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this);
        game_manager_.StartGame();
    }

    // Update is called once per frame
    void Update()
    {
        game_manager_.UpdateGameState();   
    }
}
