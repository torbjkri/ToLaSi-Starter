using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class UpgradeMenu : MonoBehaviour
{
    public GameObject upgradeDB;
    public GameObject upgradeButtonPrefab;
    public Transform upgradeButtonParent;

    private GameManager gameManager;

    UpgradeSaveData playerUpgrades;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameManager.Instance;
        LoadUpgrades();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadUpgrades(){
        //Finds eligible upgrades and populates the 3 buttons with them
        Upgrade[] allUpgrades = upgradeDB.GetComponent<UpgradeDatabase>().upgrades;
        playerUpgrades = SaveSystem.LoadUpgrades();
        var eligibleUpgrades = new List<int>();
        // code to get the eligible upgrades
        
        foreach (Upgrade upgrade in allUpgrades)
        {
            bool eligible = true;
            // check if the player already has this upgrade or its prerequisites
            if(playerUpgrades.upgrades.Contains(upgrade.id)){
                eligible = false;
            }
            // check if this upgrade is excluded by any of the player's upgrades
            // if(playerUpgrades.upgrades.Exists(x=>)){
            //     eligible = false;
            // }
            if (eligible)
            {
                eligibleUpgrades.Add(upgrade.id);
            }
        }
        // shuffle the eligible upgrades
        // code to instantiate the upgrade buttons
        float xPosition = 200;
        float xSpacing = 200;

        for (int i = 0; i < Mathf.Min(3, eligibleUpgrades.Count); i++)
        {
            GameObject button = Instantiate(upgradeButtonPrefab, upgradeButtonParent);
            RectTransform rectTransform = button.GetComponent<RectTransform>();
            rectTransform.localPosition = new Vector3(xPosition,0, 0);
            xPosition -= xSpacing;
            int upgradeIndex = Random.Range(0, eligibleUpgrades.Count);
            int upgradeId = eligibleUpgrades[upgradeIndex];
            Upgrade upgrade = allUpgrades[upgradeId];
            button.GetComponentInChildren<Text>().text = upgrade.name;            
            eligibleUpgrades.Remove(upgradeIndex);
            
            // add a click listener to the button
            int index = i;
            button.GetComponent<Button>().onClick.AddListener(() => PickUpgrade(upgradeId));
        }
    }

    public void PickUpgrade(int upgradeNo){
        //Add the upgrade to player upgrades
        playerUpgrades.upgrades.Add(upgradeNo);
        SaveSystem.SaveUpgrades(playerUpgrades.upgrades);
        gameManager.LoadNextLevel();

    }
}
