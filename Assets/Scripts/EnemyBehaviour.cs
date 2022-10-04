using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 3.0f;
    Rigidbody2D body;
    Vector2 lookDirection = new Vector2(1, 0);
    Rigidbody2D player;
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        player = GameObject.Find("Player")
                    .GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        Vector2 position = body.position;
        Vector2 player_postion = player.position;
        Vector2 direction = player_postion - position;
        if (direction.magnitude > 1.0f)
        {
            direction.Normalize();
        }

        position += speed * direction * Time.deltaTime;
        body.MovePosition(position);
    }
}
