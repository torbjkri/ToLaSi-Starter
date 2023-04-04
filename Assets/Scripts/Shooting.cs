using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject bulletPrefab;

    UpgradeSaveData playerUpgrades;

    public float bulletForce = 20f;
    // Update is called once per frame

    void Start(){
        playerUpgrades = SaveSystem.LoadUpgrades();
        Debug.Log(playerUpgrades);
    }
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            //Find weapon
            //weapon.shoot()

            Shoot();
        }
    }

    void Shoot()
    {
        //Todo check what mode from upgrades

        var mode = 1;
        // Debug.Log(playerUpgrades.upgrades);
        if((playerUpgrades != null && playerUpgrades.upgrades.Contains(5))) mode = 2;
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
            GameObject bullet = Instantiate(bulletPrefab, transform.position + 0.5f * transform.up, transform.rotation);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(transform.up * bulletForce, ForceMode2D.Impulse);
        }        
    }

    void Normal(){
        GameObject bullet = Instantiate(bulletPrefab, transform.position + 0.5f * transform.up, transform.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(transform.up * bulletForce, ForceMode2D.Impulse);
    }

}
