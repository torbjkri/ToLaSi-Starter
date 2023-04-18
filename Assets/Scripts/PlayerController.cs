using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

class MovementHandler
{
    private Rigidbody2D rigid_body_;
    private float move_speed = 5.0f;
    private Camera camera_;

    private Vector2 direction_;

    public MovementHandler(Rigidbody2D rb)
    {
        rigid_body_ = rb;
        camera_ = Camera.main;
    }

    public void SetMoveDirection(Vector2 direction)
    {
        direction_ = direction;
    }
    
    public void Move()
    {

        Vector2 mouse_position = camera_.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        rigid_body_.MovePosition(rigid_body_.position + direction_ * move_speed * Time.fixedDeltaTime);
        Vector2 lookDir = mouse_position - rigid_body_.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        rigid_body_.rotation = angle;
    }

}

public class PlayerController : MonoBehaviour
{
    //[SerializeField] private BulletSO bulletSpawner;

    [SerializeField] private GameManagerSO game_manager_;
    MovementHandler movement_handler;

    public PlayerInput playerInput;

    private WeaponBehaviour weapon;

    [SerializeField] private PlayerHealthSO healthSO_;
    // Start is called before the first frame update
    void Start()
    {
        movement_handler = new MovementHandler(GetComponent<Rigidbody2D>());
        gameObject.layer = 6;
        weapon = transform.Find("Weapon").GetComponent<WeaponBehaviour>();

    }

    // Update is called once per frame
    void Update()
    {
    }

    private void FixedUpdate()
    {
        movement_handler.Move();
    }
    void ApplyDamage(int damage)
    {
        healthSO_.Health -= damage;
        if (healthSO_.Health <= 0) {
            Destroy(gameObject);
            Debug.Log("Lost");
            PlayerPrefs.SetInt("CurrentDifficulty", 0);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    void OnFire()
    {
        weapon.Attack();
    }

    void OnMove(InputValue input)
    {
        movement_handler.SetMoveDirection(input.Get<Vector2>());
    }

    private void OnPause()
    {
        TogglePause();
    }

    public void TogglePause()
    {
        game_manager_.TogglePause();
        ToggleInputMap();
    }

    void ToggleInputMap()
    {
        if (game_manager_.IsGamePaused())
            playerInput.SwitchCurrentActionMap("UI");
        else
            playerInput.SwitchCurrentActionMap("Player");
    }

}
