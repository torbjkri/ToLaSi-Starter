using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    enum LevelState {
        Active,
        Loading
    }

    [SerializeField] private GameStateSO game_state_;

    [SerializeField] private UpgradeStorageSO player_upgrades_;
    private LevelState level_state;

    void Start()
    {
        DontDestroyOnLoad(this);
        level_state = LevelState.Loading;
        StartCoroutine(LoadScene(game_state_.CurrentLevel()));
        game_state_.OnGameStateUpdated += OnGameStateChanged;
    }

    // Update is called once per frame
    void Update()
    {
        if (level_state == LevelState.Loading)
            return;

        if (game_state_.game_state != GameStateType.Playing)
            return;

        if (IsLevelFinished()) {
            game_state_.game_state = GameStateType.Won;
        }
    }

    void OnGameStateChanged(GameStateType state)
    {
        if (level_state == LevelState.Loading)
            return;

        if (state == GameStateType.NewGame) {            
            player_upgrades_.ClearUpgrades();
            level_state = LevelState.Loading;
            StartCoroutine(LoadScene(game_state_.FirstLevel()));
        }

        if (state == GameStateType.FinishedLevel) {
            level_state = LevelState.Loading;
            StartCoroutine(LoadScene(game_state_.AdvanceLevel()));
        }

    }

    private IEnumerator LoadScene(string scene)
    {
        var res = SceneManager.LoadSceneAsync(scene);

        while (!res.isDone) {
            yield return null;
        }
        level_state = LevelState.Active;
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
