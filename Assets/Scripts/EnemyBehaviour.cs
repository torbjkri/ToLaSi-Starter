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
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        objectCollider = GetComponent<BoxCollider2D>();

        GameObject playerObject = GameObject.Find("Player");
        player =playerObject.GetComponent<Rigidbody2D>();
        playerCollider = playerObject.GetComponent<BoxCollider2D>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        CheckCollisionWithPlayer();
        SetHeading();
        UpdatePosition();
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

    void CheckCollisionWithPlayer()
    {
        if (objectCollider.bounds.Intersects(playerCollider.bounds))
        {
            Debug.Log("Touching");
        }
    }
}
