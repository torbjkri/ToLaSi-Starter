using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Player/Upgrade Storage", fileName = "UpgradeStorage")]
public class UpgradeStorageSO : ScriptableObject
{
    public List<int> upgrades;
    [SerializeField] public List<UpgradeSO> upgradeSOs;

    void OnEnable()
    {
        upgrades = new List<int>();
    }

    public List<DamageUpgradeSO> GetDamageUpgrades(){
            List<DamageUpgradeSO> damagepUpgrades = new List<DamageUpgradeSO>(); 
        foreach (UpgradeSO item in upgradeSOs)
        {
        if(item.GetType() == typeof(DamageUpgradeSO))   {
            damagepUpgrades.Add(item as DamageUpgradeSO);
        }
        }
        return damagepUpgrades;        
    }
}
