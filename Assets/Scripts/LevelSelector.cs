using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelector : MonoBehaviour
{
    public List<GameObject> levels = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        if(!PlayerPrefs.HasKey("CurrentDifficulty")) PlayerPrefs.SetInt("CurrentDifficulty",0);
        GameObject levelObject = Instantiate(levels[PlayerPrefs.GetInt("CurrentDifficulty")],
                 new Vector2(0,0), 
                 Quaternion.identity);
        ;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
