using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
// using TMPro;



public class UpgradeMenu : MonoBehaviour
{
    public GameObject upgradeDB;
    public GameObject upgradeButtonPrefab;
    public Transform upgradeButtonParent;

    // Start is called before the first frame update
    void Start()
    {
        LoadUpgrades();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadUpgrades(){
        //Finds eligible upgrades and populates the 3 buttons with them
        Upgrade[] allUpgrades = upgradeDB.GetComponent<UpgradeDatabase>().upgrades;
        var eligibleUpgrades = new List<int>();
        // code to get the eligible upgrades
        
        foreach (Upgrade upgrade in allUpgrades)
        {
            bool eligible = true;
            // check if the player already has this upgrade or its prerequisites
            // check if this upgrade is excluded by any of the player's upgrades
            if (eligible)
            {
                eligibleUpgrades.Add(upgrade.id);
            }
        }
        // shuffle the eligible upgrades
        // code to instantiate the upgrade buttons
        float yPosition = 0;
        float ySpacing = 50;

        for (int i = 0; i < Mathf.Min(3, eligibleUpgrades.Count); i++)
        {
            GameObject button = Instantiate(upgradeButtonPrefab, upgradeButtonParent);
            RectTransform rectTransform = button.GetComponent<RectTransform>();
            rectTransform.localPosition = new Vector3(0, yPosition, 0);
            yPosition -= ySpacing;
            int upgradeId = eligibleUpgrades[i];
            Upgrade upgrade = allUpgrades[upgradeId];
            // button.GetComponentInChildren<TMP_Text>().text = upgrade.name;
            // add a click listener to the button
            int index = i;
            button.GetComponent<Button>().onClick.AddListener(() => PickUpgrade(index));
        }
    }

    public void PickUpgrade(int upgradeNo){
        //Add the upgrade to player upgrades

    }
}
