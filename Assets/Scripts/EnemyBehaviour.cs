using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 3.0f;
    Rigidbody2D body;
    Collider2D objectCollider;


    Rigidbody2D player;
    Collider2D playerCollider;

    public int health = 10;

    void Start()
    {
        gameObject.tag = "Enemy";
        gameObject.layer = 8;
        body = GetComponent<Rigidbody2D>();
        objectCollider = GetComponent<CircleCollider2D>();

        GameObject playerObject = GameObject.Find("Player");
        player =playerObject.GetComponent<Rigidbody2D>();
        playerCollider = playerObject.GetComponent<CircleCollider2D>();

    }


    void FixedUpdate()
    {
        SetHeading();
        if (!IsCollidingWithPlayer())
        {
            UpdatePosition();
        }
    }

    void UpdatePosition()
    {
        Vector2 position = body.position;
        Vector2 player_postion = player.position;

        float delta = speed * Time.deltaTime;
        position = Vector2.MoveTowards(position, player_postion, delta);

        body.MovePosition(position);
    }

    void SetHeading()
    {
        Vector2 position = body.position;
        Vector2 player_postion = player.position;
        Vector2 direction = player_postion - position;

        body.transform.right = direction;
    }

    bool IsCollidingWithPlayer()
    {
        return objectCollider.IsTouching(playerCollider);
    }

    void ApplyDamage(int damage)
    {
        health -= damage;
        if (health <= 0) {
            Destroy(gameObject);
        }
    }
}
