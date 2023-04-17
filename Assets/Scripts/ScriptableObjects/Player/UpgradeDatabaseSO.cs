using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Player/Upgrade Database", fileName = "UpgradeDatabase")]
public class UpgradeDatabaseSO : ScriptableObject
{

    // TODO: Split weapon upgrades and weapon type upgrade
    public Upgrade[] upgrades = new Upgrade[]{
        new Upgrade(0, "Damage +1", "Increases damage by one", "passive", null, null),
        new Upgrade(1, "Damage +2", "Increases damage by one more", "passive", new int[] {0}, null),
        new Upgrade(2, "Damage +3", "Increases damage by one more","passive", new int[] {1}, null),
        new Upgrade(3, "Bounce 1", "Allows projectile to bounce one time before disappearing","projectile", null, null),
        new Upgrade(4, "Bounce 2", "Allows projectile to bounce two times before disappearing","projectile", new int[] {3}, null),
        new Upgrade(5, "Shotgun", "Fires multiple bullets at once","firemode", null, null),
        


    };

    private Upgrade CreateUpgrade(int id, string name,string description, string type, int[] preRequisites, int[] excludedUpgrades){
        var upgrade = new Upgrade( id,  name,description, type, preRequisites, excludedUpgrades);
        return upgrade;
    }
}
