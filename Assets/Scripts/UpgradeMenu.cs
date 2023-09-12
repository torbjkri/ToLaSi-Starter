using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using System;
using TMPro;


// TODO: Make the upgrade buttons fixed, instead enable/disable them for the number of upgrades.
public class UpgradeMenu : MonoBehaviour
{
    class ButtonData {

        public ButtonData(GameObject game_object_)
        {
            game_object = game_object_;
            text = game_object.GetComponentInChildren<TextMeshProUGUI>();
            OnClicked = null;
            game_object.GetComponent<Button>().onClick.AddListener(Reaction);
            game_object.SetActive(false);
        }
        public GameObject game_object;
        public TextMeshProUGUI text;
        void Reaction()
        {
            if (OnClicked != null)
                OnClicked();
        }

        public delegate void OnClickedDelegate();
        public OnClickedDelegate OnClicked;
    }
    [SerializeField] private GameStateSO game_state;

    [SerializeField] private UpgradeStorageSO player_upgrades;
    [SerializeField] private UpgradeDatabaseSO upgrade_db;

    [SerializeField] private List<ButtonData> upgrade_buttons = new List<ButtonData>();

    private System.Random random;

    // Start is called before the first frame update
    void Awake()
    {
        var buttons = GetComponentsInChildren<Button>();
        foreach (var button in buttons) {
            upgrade_buttons.Add(new ButtonData(button.gameObject));
        }

        random = new System.Random();
    }

    void OnEnable()
    {
        LoadUpgrades();
    }

    void OnDisable()
    {
        foreach (var button in upgrade_buttons) {
            button.game_object.SetActive(false);
        }
    }

    public void LoadUpgrades()
    {
        var choices = GetChoices();
        if (choices.Count() == 0)
            SkipUpgrading();

        for (int i = 0; i < choices.Count(); i++) {
            upgrade_buttons[i].game_object.SetActive(true);
            upgrade_buttons[i].text.text = choices[i].upgradeName;
            var upgrade = choices[i];
            upgrade_buttons[i].OnClicked = () => {FinishUpgrading(upgrade);};

        }
    }

    List<UpgradeSO> GetChoices()
    {
        //Finds eligible upgrades and populates the 3 buttons with them
        var eligibleUpgrades = new List<UpgradeSO>();
        // code to get the eligible upgrades
        
        foreach (UpgradeSO upgrade in upgrade_db.upgrades)
        {
            if(!player_upgrades.upgradeSOs.Contains(upgrade))
                eligibleUpgrades.Add(upgrade);
        }
        return eligibleUpgrades.Distinct().OrderBy(x => random.Next()).Take(upgrade_buttons.Count).ToList();
    }

    void FinishUpgrading(UpgradeSO upgrade)
    {
        player_upgrades.upgradeSOs.Add(upgrade);
        game_state.game_state = GameStateType.FinishedLevel;
    }

    void SkipUpgrading()
    {
        game_state.game_state = GameStateType.FinishedLevel;
    }

}
