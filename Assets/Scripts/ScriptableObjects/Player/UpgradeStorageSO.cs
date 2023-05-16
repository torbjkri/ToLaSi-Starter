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

    public List<WeaponTypeUpgradeSO> GetWeaponTypeUpgrades(){
        List<WeaponTypeUpgradeSO> weaponTypeUpgrades = new List<WeaponTypeUpgradeSO>(); 
        foreach (UpgradeSO item in upgradeSOs)
        {
            if(item.GetType() == typeof(WeaponTypeUpgradeSO))   {
                weaponTypeUpgrades.Add(item as WeaponTypeUpgradeSO);
            }
        }
        return weaponTypeUpgrades; 
    }  

    public List<BulletUpgradeSO> GetBulletUpgrades(){
        List<BulletUpgradeSO> bulletUpgrades = new List<BulletUpgradeSO>(); 
    foreach (UpgradeSO item in upgradeSOs)
    {
        if(item.GetType() == typeof(BulletUpgradeSO))   {
            bulletUpgrades.Add(item as BulletUpgradeSO);
        }
    }
    return bulletUpgrades;     
    }
}
