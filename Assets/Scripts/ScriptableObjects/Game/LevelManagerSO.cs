using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

class CoroutineRunner : MonoBehaviour
{
    public void RunCoroutine(IEnumerator coroutine)
    {
        StartCoroutine(coroutine);
    }
}

[CreateAssetMenu(menuName = "Game/Level Manager", fileName = "LevelManager")]
public class LevelManagerSO : ScriptableObject
{

    [SerializeField] private string sceneName = "Level_1";
    private string loaded_scene_ = null;
    private bool is_level_loaded_ = false;

    public void LoadLevel(int next_level)
    {
        is_level_loaded_ = false;
        CoroutineRunner coroutineRunner = new GameObject("CoroutineRunner").AddComponent<CoroutineRunner>();

        if (loaded_scene_ != null)
            SceneManager.UnloadSceneAsync(loaded_scene_);
        coroutineRunner.RunCoroutine(LoadSceneAsync());
    }

    private IEnumerator LoadSceneAsync()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);

        while (!asyncLoad.isDone)
        {
            yield return null;
        }

        SceneManager.SetActiveScene(SceneManager.GetSceneByName(sceneName));
        is_level_loaded_ =  true;
    }

    private IEnumerator UnLoadSceneAsync()
    {
        AsyncOperation asyncLoad = SceneManager.UnloadSceneAsync(loaded_scene_);

        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }

    public bool IsLevelFinished()
    {
        if (!is_level_loaded_)
            return false;

        return GameObject.FindGameObjectsWithTag("Spawner").Length == 0;
    }

}
