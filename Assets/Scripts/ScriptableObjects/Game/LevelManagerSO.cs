using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Game/Level Manager", fileName = "LevelManager")]
public class LevelManagerSO : ScriptableObject
{
    
    [SerializeField] List<LevelSO> levels = new List<LevelSO>();

    void Awake()
    {
        
    }

    public int LoadLevel(int next_level)
    {
        if (next_level >= levels.Count)
        {
            next_level = 0;
        }

        SpawnLevel(next_level);
        return next_level;
    }

    private void SpawnLevel(int level)
    {
        foreach(LocatedSpawner spawner in levels[level].spawners)
        {
            Vector3 position = new Vector3(spawner.position.x, spawner.position.y, 0.0f);
            Instantiate(spawner.spawner, position, new Quaternion());
        }
    }

    public bool IsLevelFinished()
    {
        if(GameObject.FindGameObjectsWithTag("Spawner").Length <= 0){
            Debug.Log("Victory");
            return true;
        }
        return false;
    }
}
