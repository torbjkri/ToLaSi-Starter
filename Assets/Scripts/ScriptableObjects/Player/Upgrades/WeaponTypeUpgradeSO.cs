using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Player/WeaponTypeUpgrade")]
public class WeaponTypeUpgradeSO : UpgradeSO
{
    [SerializeField]public string weaponType;

    [SerializeField]public int impact;
    //passive stat bonus, projectile spawn modifier, fire rate, projectile behaviour,

}
