using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 3.0f;
    Rigidbody2D body;

    Rigidbody2D player;

    bool chase = true;

    public int health = 10;
    public int damage = 10;
    float attackCooldown = 3.0f;
    float lastAttackTimeStamp = 0.0f;

    void Start()
    {
        gameObject.tag = "Enemy";
        gameObject.layer = 8;
        body = GetComponent<Rigidbody2D>();

        GameObject playerObject = GameObject.Find("Player");
        player = playerObject.GetComponent<Rigidbody2D>();
        
    }


    void FixedUpdate()
    {
        SetHeading();
        if (chase)
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

    void ApplyDamage(int damage)
    {
        health -= damage;
        if (health <= 0) {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            chase = false;
            float now = Time.time;
            float timeSinceLastAttack = now - lastAttackTimeStamp;
            if (timeSinceLastAttack > attackCooldown)
            {
                // Debug.Log("Enemy hit player");
                collision.gameObject.SendMessage("ApplyDamage", damage);
                lastAttackTimeStamp = now;
            }
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        
        if (collision.gameObject.tag == "Player")
        {
            float now = Time.time;
            float timeSinceLastAttack = now - lastAttackTimeStamp;
            if (timeSinceLastAttack > attackCooldown)
            {
                // Debug.Log("Enemy hit player");
                collision.gameObject.SendMessage("ApplyDamage", damage);
                lastAttackTimeStamp = now;
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            chase = true;
        }
    }
}
