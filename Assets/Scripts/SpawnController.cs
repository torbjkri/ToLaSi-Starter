using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    public GameObject[] enemyPrefabs;
    public Transform position;
    public int spawnInterval;
    private static System.DateTime prevSpawnTime = System.DateTime.Now;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(System.DateTime.Now > prevSpawnTime.AddSeconds(spawnInterval)){
            Debug.Log("Spawn");
            foreach(GameObject enemy in enemyPrefabs){
                GameObject boulderObject = Instantiate(enemy,
                 this.transform.position, 
                 Quaternion.identity);
            }
            
            prevSpawnTime = System.DateTime.Now;
            
        }
    }
}
