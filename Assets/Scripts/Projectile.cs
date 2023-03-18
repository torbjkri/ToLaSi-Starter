using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    int damage = 10;
    float velocity_force = 20.0f;
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
        Vector2 relativePosition = transform.position - startPosition;
        if (relativePosition.magnitude > 10.0f)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "Spawner")
        {
            collision.gameObject.SendMessage("ApplyDamage", damage);
            Destroy(gameObject);
        }
    }

}
