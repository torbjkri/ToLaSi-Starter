using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class UpgradeSaveData {
    public List<int> upgrades;

    public UpgradeSaveData(List<int> upgrades) {
        this.upgrades = upgrades;
    }
}