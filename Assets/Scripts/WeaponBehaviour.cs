using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponBehaviour : MonoBehaviour
{
    [SerializeField] private UpgradeStorageSO player_upgrades_;
    [SerializeField] private GameObject bullet_type_;
    // Start is called before the first frame update
    void Start()
    {
        transform.localPosition = new Vector3(0.0f, 0.6f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Attack()
    {        
        //Todo check what mode from upgrades

        var mode = 1;
        if(player_upgrades_.GetWeaponTypeUpgrades().Find(x=>x.weaponType == "Shotgun")) mode = 2;
        switch (mode)
        {
            case 1:
                Normal();
                break;
            case 2:
                Shotgun();
                break;
        }
        
    }

    void Shotgun(){
        int bulletCount = 0;
        foreach (var item in player_upgrades_.GetWeaponTypeUpgrades())
        {
            if(item.weaponType == "Shotgun")
                bulletCount += item.impact;
        }
        ;
        for (int i = 0; i < bulletCount; i++)
        {
            GameObject bullet = Instantiate(bullet_type_, transform.position, transform.rotation);
            bullet.GetComponent<Projectile>().playerUpgrades = player_upgrades_;
        }        
    }

    void Normal(){
        GameObject bullet = Instantiate(bullet_type_, transform.position, transform.rotation);
        bullet.GetComponent<Projectile>().playerUpgrades = player_upgrades_;
    
    }
}
