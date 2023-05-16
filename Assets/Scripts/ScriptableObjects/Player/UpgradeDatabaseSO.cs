using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Player/Upgrade Database", fileName = "UpgradeDatabase")]
public class UpgradeDatabaseSO : ScriptableObject
{

    // TODO: Split weapon upgrades and weapon type upgrade
    [SerializeField] public List<UpgradeSO> upgrades;

}
