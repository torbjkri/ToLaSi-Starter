using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject bulletPrefab;

    public float bulletForce = 20f;
    // Update is called once per frame
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
        switch (mode)
        {
            case 1:
                Shotgun();
                break;
            case 2:
                Normal();
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
