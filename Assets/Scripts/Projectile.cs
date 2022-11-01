using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    int damage = 10;
    Rigidbody2D rigidbody2d;
    Vector3 startPosition;

    private void Start()
    {
        gameObject.layer = 7;
        Physics2D.IgnoreLayerCollision(7, 6);
    }

    void Awake()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
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
    public void Launch(Vector2 direction, float force)
    {
        rigidbody2d.AddForce(direction * force);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Bullet hitm something " + collision.gameObject.tag);
        if (collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "Spawner")
        {
            Debug.Log("Bullet hit enemy");
            collision.gameObject.SendMessage("ApplyDamage", damage);
            Destroy(gameObject);
        }
    }

}
