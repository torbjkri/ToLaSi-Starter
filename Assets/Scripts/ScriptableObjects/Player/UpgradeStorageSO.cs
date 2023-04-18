using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Player/Upgrade Storage", fileName = "UpgradeStorage")]
public class UpgradeStorageSO : ScriptableObject
{
    public List<int> upgrades;

    void OnEnable()
    {
        upgrades = new List<int>();
    }
}
