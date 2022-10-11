using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    public GameObject[] enemyPrefabs;
    public int spawnInterval;
    public int spawnerHealth = 10;
    private System.DateTime prevSpawnTime = System.DateTime.Now;
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
            spawnerHealth--;
            prevSpawnTime = System.DateTime.Now;
            
        }

        if(spawnerHealth < 1){
            Object.Destroy(this.gameObject);
        }
    }
}
