using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    //todo calculate from upgrades
    int damage = 10;
    float velocity_force = 20.0f;
    int bounceCount = 1;
    Rigidbody2D rigidbody2d;
    Vector3 startPosition;

    private void Start()
    {
        gameObject.layer = 7;
        Physics2D.IgnoreLayerCollision(7, 6);
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.AddForce(transform.up * velocity_force, ForceMode2D.Impulse);
        startPosition = transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        //todo get range from upgrades
        float range = 10.0f;
        Vector2 relativePosition = transform.position - startPosition;
        if (relativePosition.magnitude > range)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "Spawner")
        {
            Debug.Log("Bullet hit enemy");
            //todo get damage from upgrades
            float damageUpgrades = 1.1f;
            float damageAfterUpgrades = damage * damageUpgrades;
            collision.gameObject.SendMessage("ApplyDamage", damageAfterUpgrades);
            //todo get bounce from upgrade
            var bulletMod = "bounce";
            switch (bulletMod)
            {
                case "bounce":
                    var maxBounce = 2;
                    if(bounceCount >= maxBounce){
                        Destroy(gameObject);
                    }else{
                        bounceCount++;
                    }
                    break;
                default:
                    Destroy(gameObject);
                    break;
            }
            
        }
    }

}
