using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class LocatedSpawner
{
    public GameObject spawner;
    public Vector2 position;
}

[CreateAssetMenu(menuName = "Enemies/Level")]
public class LevelSO : ScriptableObject
{
    [SerializeField] public List<LocatedSpawner> spawners =  new List<LocatedSpawner>();
    void Start()
    {
        
    }

}
