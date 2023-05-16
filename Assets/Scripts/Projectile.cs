using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    //todo calculate from upgrades
    float velocity_force = 20.0f;

    // TODO: Should be given the current upgrades by the weapon or something
    [SerializeField] public UpgradeStorageSO playerUpgrades;
    float damage = 10;
    int bounceCount = 1;
    Rigidbody2D rigidbody2d;
    Vector3 startPosition;


    private void Start()
    {
        gameObject.layer = 7;
        Physics2D.IgnoreLayerCollision(7, 6);
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.AddForce(transform.up * velocity_force, ForceMode2D.Impulse);
        damage = CalculateDamage(playerUpgrades);
    }

    void Awake()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
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
        // Debug.Log("Bullet hitm something " + collision.gameObject.tag);
        if (collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "Spawner")
        {
            // Debug.Log("Bullet hit enemy");
            //todo get damage from upgrades
            collision.gameObject.SendMessage("ApplyDamage", damage);
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

    private float CalculateDamage(UpgradeStorageSO upgrades){
        float additiveMultiplier = 1;
        foreach(DamageUpgradeSO damageupgrade in playerUpgrades.GetDamageUpgrades()){
            additiveMultiplier += damageupgrade.additiveMultiplier;
        }
        return damage * additiveMultiplier;
    }

}
