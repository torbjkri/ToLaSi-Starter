using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


// TODO: Make the upgrade buttons fixed, instead enable/disable them for the number of upgrades.
public class UpgradeMenu : MonoBehaviour
{
    public GameObject upgradeButtonPrefab;
    public Transform upgradeButtonParent;

    [SerializeField] private GameManagerSO game_manager_;

    [SerializeField] private UpgradeStorageSO playerUpgrades;
    [SerializeField] private UpgradeDatabaseSO upgradeDB;

    private GameObject[] buttons = new GameObject[2];

    // Start is called before the first frame update
    void Start()
    {
        //gameManager = GameManager.Instance;
        LoadUpgrades();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadUpgrades(){
        //Finds eligible upgrades and populates the 3 buttons with them
        List<UpgradeSO> allUpgrades = upgradeDB.upgrades;
        var eligibleUpgrades = new List<UpgradeSO>();
        // code to get the eligible upgrades
        
        foreach (UpgradeSO upgrade in allUpgrades)
        {
            if(!playerUpgrades.upgradeSOs.Contains(upgrade)){
                Debug.Log(upgrade.upgradeName + " was added to eligible");
                eligibleUpgrades.Add(upgrade);
            }else{
                Debug.Log(upgrade.upgradeName + " is already taken");
            }
        }
        // shuffle the eligible upgrades
        // code to instantiate the upgrade buttons
        float xPosition = 200;
        float xSpacing = 200;
        int amountOfChoices = Mathf.Min(3, eligibleUpgrades.Count);
        for (int i = 0; i < amountOfChoices; i++)
        {
            buttons[i] = Instantiate(upgradeButtonPrefab, upgradeButtonParent);
            RectTransform rectTransform = buttons[i].GetComponent<RectTransform>();
            rectTransform.localPosition = new Vector3(xPosition,0, 0);
            xPosition -= xSpacing;
            Debug.Log("eligible lef " + eligibleUpgrades.Count);
            int upgradeIndex = Random.Range(0, eligibleUpgrades.Count);
            UpgradeSO upgrade = eligibleUpgrades[upgradeIndex];
            buttons[i].GetComponentInChildren<Text>().text = upgrade.upgradeName;            
            eligibleUpgrades.RemoveAt(upgradeIndex);            
            // add a click listener to the button
            buttons[i].GetComponent<Button>().onClick.AddListener(() => PickUpgrade(upgrade));
            Debug.Log(upgrade.upgradeName + " Was added to list");
        }
        Debug.Log("eligible left after loop " + eligibleUpgrades.Count);
    }

    public void PickUpgrade(UpgradeSO upgradeNo){
        playerUpgrades.upgradeSOs.Add(upgradeNo);
        for (int i = 0; i < buttons.Length; i++)
        {
            Destroy(buttons[i]);
        }
        LoadUpgrades();
        game_manager_.FinishUpgrading();

    }
}
