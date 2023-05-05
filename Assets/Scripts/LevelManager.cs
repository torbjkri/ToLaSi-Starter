using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private GameStateSO game_state_;

    void Start()
    {
        DontDestroyOnLoad(this);
        StartCoroutine(LoadScene(game_state_.CurrentLevel()));
    }

    // Update is called once per frame
    void Update()
    {
        if (game_state_.game_state ==  GameStateType.Loading)
            return;

        if (IsLevelFinished()) {
            StartCoroutine(LoadScene(game_state_.AdvanceLevel()));
        }
    }

    private IEnumerator LoadScene(string scene)
    {
        game_state_.game_state = GameStateType.Loading;
        var res = SceneManager.LoadSceneAsync(scene);

        while (!res.isDone) {
            yield return null;
        }
        game_state_.game_state = GameStateType.Playing;
    }

    private bool IsLevelFinished()
    {
        if (GameObject.FindGameObjectsWithTag("Spawner").Length == 0)
        {
            Debug.Log("YOU WON");
            return true;
        }
        return false;
    }
}
