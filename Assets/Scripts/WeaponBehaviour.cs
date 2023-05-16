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
        if((player_upgrades_ != null && player_upgrades_.upgrades != null && 
            player_upgrades_.upgrades.Contains(5))) mode = 2;
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
        for (int i = 0; i < 5; i++)
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
