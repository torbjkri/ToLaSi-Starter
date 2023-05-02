using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


[CreateAssetMenu(menuName = "Game/Level Manager", fileName = "LevelManager")]
public class LevelManagerSO : ScriptableObject
{

    [SerializeField] private string scene_name_ = "Level_1";
    void OnEnable()
    {
    }

    public void LoadLevel(int next_level)
    {
        SceneManager.LoadSceneAsync(scene_name_);
    }

    public bool IsLevelFinished()
    {


        if (GameObject.FindGameObjectsWithTag("Spawner").Length == 0)
        {
            Debug.Log("YOU WON");
            return true;
        }
        return false;
    }

}
