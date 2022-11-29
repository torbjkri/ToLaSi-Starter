using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class InputHandler
{
    public Vector2 movement_direction;
    public Vector2 mouse_position;

    public void SetMovementDirection(Vector2 direction)
    {
        movement_direction = direction;
    }

    public void Update()
    {
        Vector2 move = new Vector2(0.0f, 0.0f);
        mouse_position = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
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

    MovementHandler movement_handler;
    InputHandler input_handler;

    public PlayerInput playerInput;

    public int health = 100;
    // Start is called before the first frame update
    void Start()
    {
        movement_handler = new MovementHandler(GetComponent<Rigidbody2D>());
        gameObject.layer = 6;
        input_handler = new InputHandler();

    }

    // Update is called once per frame
    void Update()
    {
    }

    private void FixedUpdate()
    {
        input_handler.Update();
        movement_handler.Move(input_handler.movement_direction, input_handler.mouse_position);
    }
    void ApplyDamage(int damage)
    {
        health -= damage;
        if (health <= 0) {
            Destroy(gameObject);
            Debug.Log("Lost");
            PlayerPrefs.SetInt("CurrentDifficulty", 0);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    void OnFire()
    {
        Debug.Log("FIRE IND A HOLE");
        GameObject bullet = Instantiate(projectilePrefab, transform.position + 0.5f * transform.up, transform.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        // 20 is magic force number
        rb.AddForce(transform.up * 20.0f, ForceMode2D.Impulse);
    }

    void OnMove(InputValue input)
    {
        input_handler.SetMovementDirection(input.Get<Vector2>());
    }

    private void OnPause()
    {
        TogglePause();
    }

    public void TogglePause()
    {
        GameManager.Instance.TogglePause();
        ToggleInputMap();
    }

    void ToggleInputMap()
    {
        if (GameManager.Instance.IsGamePaused())
            playerInput.SwitchCurrentActionMap("UI");
        else
            playerInput.SwitchCurrentActionMap("Player");
    }

}
