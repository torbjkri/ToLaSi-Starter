using System.IO;
using System.Collections.Generic;
using UnityEngine;

public static class SaveSystem {
    private static string savePath = Application.persistentDataPath + "/upgrades.save";
    private static string currentLevelPath = Application.persistentDataPath + "/currentLevel.save";

    public static void SaveUpgrades(List<int> upgrades) {
        UpgradeSaveData saveData = new UpgradeSaveData(upgrades);
        string json = JsonUtility.ToJson(saveData);
        File.WriteAllText(savePath, json);
    }

    public static UpgradeSaveData LoadUpgrades() {
        Debug.Log(savePath);
        if (File.Exists(savePath)) {
            string json = File.ReadAllText(savePath);
            return JsonUtility.FromJson<UpgradeSaveData>(json);
        }else{
            List<int> noUpgrades = new List<int>();
            SaveSystem.SaveUpgrades(noUpgrades);
        }
        return null;
    }

    public static void SaveCurrentLevel(int currentLevel) {
        string json = JsonUtility.ToJson(currentLevel);
        File.WriteAllText(currentLevelPath, json);
    }

    public static int LoadCurrentLevel() {
        if (File.Exists(currentLevelPath)) {
            string json = File.ReadAllText(currentLevelPath);
            return JsonUtility.FromJson<int>(json);
        }
        return 1;
    }
}