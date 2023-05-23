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
        
        float angle_step = 60.0f / (bulletCount + 1);
        for (int i = 0; i < bulletCount; i++)
        {
            var current_quaternion = transform.rotation;
            var euler = current_quaternion.eulerAngles;
            euler.z += (i + 1) * angle_step - 30.0f;
            current_quaternion.eulerAngles = euler;
            GameObject bullet = Instantiate(bullet_type_, transform.position, current_quaternion);
            bullet.GetComponent<Projectile>().playerUpgrades = player_upgrades_;
        }        
    }

    void Normal(){
        GameObject bullet = Instantiate(bullet_type_, transform.position, transform.rotation);
        bullet.GetComponent<Projectile>().playerUpgrades = player_upgrades_;
    
    }
}
