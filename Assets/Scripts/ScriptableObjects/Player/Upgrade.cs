using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// TODO: Can be made into SOs as well

[System.Serializable]
public class Upgrade
{
    public int id;
    public string name;
    public string description;
    //passive stat bonus, projectile spawn modifier, fire rate, projectile behaviour, 
    public string type;
    public int[] preRequisites;
    public int[] excludedUpgrades;
    // Start is called before the first frame update
    public Upgrade (int id, string name, string description, string type, int[] preRequisites, int[] excludedUpgrades){
        this.id = id;
        this.name = name;
        this.description = description;
        this.type = type;
        this.preRequisites = preRequisites;
        this.excludedUpgrades = excludedUpgrades;
    }
}
