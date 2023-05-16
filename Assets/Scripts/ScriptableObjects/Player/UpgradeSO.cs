using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Player/Upgrade")]
public class UpgradeSO : ScriptableObject
{

    [SerializeField]public int id;
    [SerializeField]public string upgradeName;
    [SerializeField]public string description;
    //passive stat bonus, projectile spawn modifier, fire rate, projectile behaviour, 
    [SerializeField]public string type;
    [SerializeField]public UpgradeSO[] preRequisites;
    [SerializeField]public int[] excludedUpgrades;


}
