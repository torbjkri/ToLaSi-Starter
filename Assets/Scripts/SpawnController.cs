using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    public GameObject[] enemyPrefabs;
    public int spawnInterval;
    public int initialDelay = 0;
    public int spawnerHealth = 10;
    public Vector2 spawnPosition;
    private System.DateTime prevSpawnTime = System.DateTime.Now;
    // Start is called before the first frame update
    void Start()
    {
        prevSpawnTime.AddSeconds(initialDelay);
    }

    // Update is called once per frame
    void Update()
    {
        if(System.DateTime.Now > prevSpawnTime.AddSeconds(spawnInterval)){
            foreach(GameObject enemy in enemyPrefabs){
                GameObject enemyObject = Instantiate(enemy,
                 this.transform.position, 
                 Quaternion.identity);
            }
            prevSpawnTime = System.DateTime.Now;
            
        }
    }

    void ApplyDamage(int damage)
    {
        spawnerHealth -= damage;
        if (spawnerHealth <= 0) {
            Destroy(this.gameObject);
        }
    }
}
