using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InputHandler
{
    public Vector2 movement_direction;

    public void Update()
    {
        movement_direction.x = Input.GetAxisRaw("Horizontal");
        movement_direction.y = Input.GetAxisRaw("Vertical");
    }
}

class MovementHandler
{
    Rigidbody2D rigid_body;
    float move_speed = 5.0f;

    public MovementHandler(Rigidbody2D rb)
    {
        rigid_body = rb;
    }
    
    public void Move(Vector2 movement_direction, Vector2 mouse_position)
    {
        rigid_body.MovePosition(rigid_body.position + movement_direction * move_speed * Time.fixedDeltaTime);
        Vector2 lookDir = mouse_position - rigid_body.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        rigid_body.rotation = angle;
    }

}

public class PlayerController : MonoBehaviour
{
    public GameObject projectilePrefab;

    public float moveSpeed = 5f;
    public Camera cam;

    Vector2 mousePos;
    InputHandler input_handler = new InputHandler();
    MovementHandler movement_handler;

    public int health = 100;
    // Start is called before the first frame update
    void Start()
    {
        movement_handler = new MovementHandler(GetComponent<Rigidbody2D>());
        gameObject.layer = 6;
    }

    // Update is called once per frame
    void Update()
    {
        input_handler.Update();

        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
    }

    private void FixedUpdate()
    {
        movement_handler.Move(input_handler.movement_direction, mousePos);
    }
    void ApplyDamage(int damage)
    {
        health -= damage;
        if (health <= 0) {
            Destroy(gameObject);
            Debug.Log("Lost");
            PlayerPrefs.SetInt("CurrentDifficulty",0);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); 
        }
    }

}
