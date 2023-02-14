using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeDatabase : MonoBehaviour
{
    public Upgrade[] upgrades = new Upgrade[]{
        new Upgrade(0, "Damage +1", "passive", null, null),
        new Upgrade(1, "Damage +2", "passive", new int[] {0}, null)
    };

    public Upgrade upgrade1;
    public Upgrade upgrade2;

    
    // Start is called before the first frame update
    void Start()
    {
        upgrade1 = CreateUpgrade(0, "Damage +1", "passive", null, null);
        upgrade2 = CreateUpgrade(1, "Damage +2", "passive", new int[] {0}, null);
    }

    private Upgrade CreateUpgrade(int id, string name, string type, int[] preRequisites, int[] excludedUpgrades){
        var upgrade = new Upgrade( id,  name,  type, preRequisites, excludedUpgrades);
        return upgrade;
    }
    
}
