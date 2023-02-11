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
    private float prevSpawnTime = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        prevSpawnTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        float timeSinceSpawn = Time.time - prevSpawnTime;
        if(timeSinceSpawn > spawnInterval){
            foreach(GameObject enemy in enemyPrefabs){
                GameObject enemyObject = Instantiate(enemy,
                 this.transform.position, 
                 Quaternion.identity);
            }
            prevSpawnTime = Time.time;
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
